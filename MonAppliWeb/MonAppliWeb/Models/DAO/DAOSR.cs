using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonAppliWeb.Models.DAO
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
                    //Condition où s'il y a un volontaire associé à la serviceRequest
                    if(dbMemberVol != null)
                    {
                        requests.Add(new ServiceRequest
                        {
                            ServiceRequestID = dbService.serviceRequestID,
                            ServiceStartDate = dbService.serviceStartDate,
                            ServiceName = dbServiceName.serviceName1, //remettre serviceName dans BDD & mettre schéma à jour
                            MemberFK = dbService.memberFK,
                            BeneficiaryFName = dbMemberBen.firstName,
                            BeneficiaryLName = dbMemberBen.lastName,
                            VoluntaryMemberFK = dbService.memberFK,
                            VoluntaryFName = dbMemberVol.firstName,
                            VoluntaryLName = dbMemberVol.lastName,
                            ServiceAddress = dbService.serviceAddress,
                            ServiceCityName = dbCity.cityName,
                        });
                    }
                    requests.Add(new ServiceRequest
                    {
                        ServiceRequestID = dbService.serviceRequestID,
                        ServiceStartDate = dbService.serviceStartDate,
                        ServiceName = dbServiceName.serviceName1, //remettre serviceName dans BDD & mettre schéma à jour
                        MemberFK = dbService.memberFK,
                        BeneficiaryFName = dbMemberBen.firstName,
                        BeneficiaryLName = dbMemberBen.lastName,
                        VoluntaryMemberFK = dbService.memberFK,
                        ServiceAddress = dbService.serviceAddress,
                        ServiceCityName = dbCity.cityName,
                    });
                }
                return requests;
            }
        }

        public bool CreateServiceRequest(ServiceRequest sr)
        {
            using (BddMemberDataContext ds = new BddMemberDataContext())
            {
                //Récupérer les infos du membre bénéficiaire (celui "qui créée la demande") à partir du prénom et du nom
                var req1 = from ben in ds.member
                           where ben.firstName == sr.BeneficiaryFName
                              && ben.lastName == sr.BeneficiaryLName
                           select ben;
                member memberBDD = req1.FirstOrDefault();
                int benID = memberBDD.memberID;

                //Récupérerer l'ID du service
                var req2 = from ser in ds.serviceName
                           where ser.serviceName1 == sr.ServiceName
                           select ser;
                serviceName serNBDD = req2.FirstOrDefault();
                int serID = serNBDD.serviceID;

                //Récupérer l'ID de la ville
                var req3 = from ville in ds.city
                           where ville.cityName == sr.ServiceCityName
                           select ville;
                city cityBDD = req3.FirstOrDefault();
                int citID = cityBDD.cityID;

                //Création de la demande de service
                serviceRequest newSR = new serviceRequest()
                {
                    serviceStartDate = sr.ServiceStartDate,
                    serviceEndDate = sr.ServiceEndDate,
                    serviceAddress = sr.ServiceAddress,
                    creationDate = sr.ServiceRequestCreationDate,
                    cancelDate = sr.CancelDate,
                    serviceFK = serID,
                    serviceCityFK = citID,
                    memberFK = benID,
                };
                ds.serviceRequest.InsertOnSubmit(newSR);
                ds.SubmitChanges();
                return true;
            }
        }

        public List<int> ReturnIDsVolMatching(ServiceRequest serviceRequest)
        {
            using(BddMemberDataContext ds = new BddMemberDataContext())
            {
                var dayOfService = (int)serviceRequest.ServiceStartDate.DayOfWeek + 1;

                var dbmemberIDs = ds.member.Where(x => x.dailyPref.Any(d => d.dayFK == dayOfService && !d.dailyPrefEndDate.HasValue)
                                    && x.servicePref.Any(s => s.serviceFK == serviceRequest.ServiceFK && !s.choiceEndDate.HasValue)
                                    && !x.requestAnswer.Any(ra => ra.serviceRFK == serviceRequest.ServiceRequestID && ra.memberFK == x.memberID)).Select(x => x.memberID).ToList();
                return dbmemberIDs;
            } 
        }
        
        //Retourner la liste des volontaire matchés d'une service request
        public List<Member> ReturnVoluntaryOfSR(ServiceRequest Sr, List<int> VoluntaryIDs)
        {
            using (BddMemberDataContext ds = new BddMemberDataContext())
            {
                //Faire appel à la méthode ReturnIDsVolMatching
                DAOSR daoSR = new DAOSR();
                var voluntarys = new List<Member>();
                List<int> IDVols = daoSR.ReturnIDsVolMatching(Sr);

                //Pour chaque ID dans la liste des IDs des volontaires
                foreach (int IDVol in IDVols)
                {
                    //Vient récuperer les informations du membre à partir de son ID
                    var dbMember = ds.member.FirstOrDefault(x => x.memberID == IDVol);
                    voluntarys.Add(new Member
                    {
                        FirstName = dbMember.firstName,
                        LastName = dbMember.lastName,
                        MemberID = dbMember.memberID,
                    });
                }
                return voluntarys;
            }
        }

        //Méthode d'accepation > Quand appuie sur le btn Accepter
        public void VoluntaryAnswerAccceptation(int IDMember, ServiceRequest sr)
        {
            //Ajout dans la bdd serviceRequest l'ID du volontaire et la date d'acceptation
            using (BddMemberDataContext ds = new BddMemberDataContext())
            {
                sr.VoluntaryMemberFK = IDMember;
                //Sélectionne dans la BDD le service concerné
                var req = from ser in ds.serviceRequest where ser.serviceRequestID == sr.ServiceRequestID select ser;
                serviceRequest selectReq = req.FirstOrDefault();
                selectReq.voluntaryMemberFK = IDMember;

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
                    memberFK = IDMember,
                    answerFK = resp.answerID,
                };
                ds.SubmitChanges();
            }
        }

        //Méthode de refus > Quand on appuie sur le btn Refuser
        public void VoluntaryAnswerRejection(int IDMember, ServiceRequest sr)
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
                    serviceRFK =sr.ServiceRequestID,
                    memberFK = IDMember,
                    answerFK = resp.answerID,
                };
                ds.SubmitChanges();
            }
        }
    }
}