using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonAppliWeb.Models.DAO
{
    public class DAOSR
    {
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

        public 
    }
}