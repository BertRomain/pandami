using MonAppliWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonAppliWeb.DAO
{
    public class DAOSR
    {
        public List<ServiceRequest> GetAllServiceRequests()
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                //Récupération des demandes de services présentes dans la BDD dans une liste
                var dbServices = dm.serviceRequest.ToList();
                var requests = new List<ServiceRequest>();

                foreach (var dbService in dbServices)
                {
                    var dbMemberBen = dm.member.FirstOrDefault(x => x.memberID == dbService.memberFK);
                    var dbMemberVol = dm.member.FirstOrDefault(x => x.memberID == dbService.voluntaryMemberFK);
                    var dbServiceName = dm.serviceName.FirstOrDefault(x => x.serviceID == dbService.serviceFK);
                    var dbCity = dm.city.FirstOrDefault(x => x.cityID == dbService.serviceCityFK);
                    requests.Add(new ServiceRequest
                    {
                        ServiceRequestID = dbService.serviceRequestID,
                        ServiceStartDate = dbService.serviceStartDate,
                        ServiceName = dbServiceName.serviceName1, //remettre serviceName dans BDD & mettre schéma à jour
                        MemberFK = dbService.memberFK,
                        BeneficiaryFName = dbMemberBen.firstName,
                        BeneficiaryLName = dbMemberBen.lastName,
                        VoluntaryMemberFK = dbService.memberFK,
                        VoluntaryFName = dbMemberVol != null ? dbMemberVol.firstName : string.Empty,
                        VoluntaryLName = dbMemberVol != null ? dbMemberVol.lastName : string.Empty,
                        ServiceAddress = dbService.serviceAddress,
                        ServiceCityName = dbCity.cityName,
                    });
                }
                return requests;
            }
        }

        public int? CreateServiceRequest(ServiceRequest sr)
        {
            using (BddMemberDataContext ds = new BddMemberDataContext())
            {
                // MemberFK déja dans l'objet ServiceRequest
                //Récupérer les infos du membre bénéficiaire (celui "qui créée la demande") à partir du prénom et du nom
                //var req1 = from ben in ds.member
                //           where ben.firstName == sr.BeneficiaryFName
                //              && ben.lastName == sr.BeneficiaryLName
                //           select ben;
                //member memberBDD = req1.FirstOrDefault();
                //int benID = memberBDD.memberID;

                // ServiceFK déja dans l'objet ServiceRequest
                //Récupérerer l'ID du service
                //var req2 = from ser in ds.serviceName
                //           where ser.serviceName1 == sr.ServiceName
                //           select ser;
                //serviceName serNBDD = req2.FirstOrDefault();
                //int serID = serNBDD.serviceID;

                //Récupérer l'ID de la ville
                //var req3 = from ville in ds.city
                //           where ville.cityName == sr.ServiceCityName
                //           select ville;
                //city cityBDD = req3.FirstOrDefault();
                //int citID = cityBDD.cityID;

                // Récupération de zipCode
                var daoZipCode = new DAOZipCode();
                var zipCode = daoZipCode.GetZipCodeByCode(sr.ServiceZipCode);
                // Si Zipcode existe, récupérer ID, sinon, créer et récupérer ID
                var zipCodeId = zipCode == null ? daoZipCode.CreateZipCode(sr.ServiceZipCode) : zipCode.zipCodeID;

                // Récupération de city
                var daoCity = new DAOCity();
                var city = daoCity.GetCity(sr.ServiceCityName);
                // Si Zipcode existe, récupérer ID, sinon, créer et récupérer ID
                var cityId = city == null ? daoCity.CreateCity(sr.ServiceCityName) : city.cityID;

                //Création de la demande de service
                serviceRequest newSR = new serviceRequest()
                {
                    serviceStartDate = sr.ServiceStartDate,
                    serviceEndDate = sr.ServiceEndDate,
                    serviceAddress = sr.ServiceAddress,
                    creationDate = sr.ServiceRequestCreationDate,
                    cancelDate = sr.CancelDate,
                    serviceFK = sr.ServiceFK,
                    serviceCityFK = cityId.Value,
                    memberFK = sr.MemberFK, 
                    serviceZipcodeFK = zipCodeId.Value
                };
                ds.serviceRequest.InsertOnSubmit(newSR);
                ds.SubmitChanges();
                return newSR.serviceRequestID;
            }
        }

        public List<member> ReturnVolsMatching(ServiceRequest serviceRequest)
        {
            using (BddMemberDataContext ds = new BddMemberDataContext())
            {
                var dayOfService = (int)serviceRequest.ServiceStartDate.DayOfWeek + 1;
               
                var dbmembers = ds.member.Where(x => x.dailyPref.Any(d => d.dayFK == dayOfService && !d.dailyPrefEndDate.HasValue)
                                    && x.servicePref.Any(s => s.serviceFK == serviceRequest.ServiceFK && !s.choiceEndDate.HasValue)
                                    && !x.requestAnswer.Any(ra => ra.serviceRFK == serviceRequest.ServiceRequestID && ra.memberFK == x.memberID)).ToList();
                return dbmembers;
            }
        }

        //Retourner la liste des volontaire matchés d'une service request
        public List<Member> ReturnVoluntaryOfSR(ServiceRequest Sr)
        {
            using (BddMemberDataContext ds = new BddMemberDataContext())
            {
                //Faire appel à la méthode ReturnIDsVolMatching
                DAOSR daoSR = new DAOSR();
                var voluntarys = new List<Member>();
                List<member> Vols = daoSR.ReturnVolsMatching(Sr);

                //Pour chaque ID dans la liste des IDs des volontaires
                foreach (member m in Vols)
                {
                    //Vient récuperer les informations du membre à partir de son ID
                    
                    voluntarys.Add(new Member
                    {
                        FirstName = m.firstName,
                        LastName = m.lastName,
                        MemberID = m.memberID,
                    });
                }
                return voluntarys;
            }
        }

        //Méthode d'accepation > Quand appuie sur le btn Accepter
        public void VoluntaryAnswerAccceptation(int MemberID, int ServiceRequestID)
        {
            //Ajout dans la bdd serviceRequest l'ID du volontaire et la date d'acceptation
            using (BddMemberDataContext ds = new BddMemberDataContext())
            {
                DAOSR dao = new DAOSR();
                ServiceRequest sr = dao.GetSRById(ServiceRequestID);
                sr.VoluntaryMemberFK = MemberID;
                //Sélectionne dans la BDD le service concerné
                var req = from ser in ds.serviceRequest where ser.serviceRequestID == sr.ServiceRequestID select ser;
                serviceRequest selectReq = req.FirstOrDefault();
                selectReq.voluntaryMemberFK = MemberID;

                //On récupère l'ID de "Oui" dans la table answer
                var req2 = from a in ds.answer where a.answer1 == "Oui" select a;
                answer resp = req2.FirstOrDefault();

                //Création dans la table requestAnswer
                requestAnswer Ranswer = new requestAnswer()
                {
                    acceptanceDate = DateTime.Now,
                    answerDate = DateTime.Now,
                    serviceRFK = sr.ServiceRequestID,
                    //On ajoute l'ID du volontaire
                    memberFK = MemberID,
                    answerFK = resp.answerID,
                };
                ds.SubmitChanges();
            }
        }

        //Méthode de refus > Quand on appuie sur le btn Refuser
        public void VoluntaryAnswerRejection(int MemberID, int ServiceRequestID)
        {
            using (BddMemberDataContext ds = new BddMemberDataContext())
            {
                               
                //On récupère l'ID de "Non" dans la table answer
                var req = from a in ds.answer where a.answer1 == "Non" select a;
                answer resp = req.FirstOrDefault();

                //Création dans la table Answer
                requestAnswer Ranswer = new requestAnswer()
                {
                    refusalDate = DateTime.Now,
                    answerDate = DateTime.Now,
                    serviceRFK = ServiceRequestID,
                    memberFK = MemberID,
                    answerFK = resp.answerID,
                };
                ds.SubmitChanges();
            }
        }

        public List<serviceName> GetAllServices()
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                //Récupération de la liste des services présents dans la BDD
                return dm.serviceName.ToList();
            }
        }

        internal ServiceRequest GetSRById(int id)
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                var dbSr = dm.serviceRequest.FirstOrDefault(x => x.serviceRequestID == id);
                ServiceRequest serviceR = new ServiceRequest()
                {
                    ServiceFK = dbSr.serviceFK,
                    ServiceRequestID = dbSr.serviceRequestID,
                    ServiceStartDate = dbSr.serviceStartDate,
                    ServiceEndDate = dbSr.serviceEndDate,
                    ServiceAddress = dbSr.serviceAddress,
                    ServiceRequestCreationDate = dbSr.creationDate,
                    CancelDate = dbSr.cancelDate,
                    ServiceCityFK = dbSr.serviceCityFK,
                    MemberFK = dbSr.memberFK,
                    VoluntaryMemberFK = dbSr.voluntaryMemberFK,
                };
                return serviceR;
            }
        }
    }
}