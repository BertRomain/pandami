using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonAppliWeb.Models
{
    public class ServiceRequest
    {
        public int ServiceRequestID { get; set; }

        public int ServiceFK { get; set; }

        public DateTime ServiceStartDate { get; set; }

        public DateTime ServiceEndDate { get; set; }

        public DateTime ServiceRequestCreationDate { get; set; }

        public DateTime CancelDate { get; set; }

        public int MemberFK { get; set; }

        public int VoluntaryMemberFK { get; set; }

        public int ServiceCityFK { get; set; }

        public string ServiceAddress { get; set; }

        //Méthode d'affiliation
        public int Matching(int ServiceRequest)
        {
            
            using (BddMemberDataContext dc = new BddMemberDataContext())
            {
                int voluntaryID = 0;
                //fetch des informations de la demande de service 
                var req = from element in dc.serviceRequest where element.serviceRequestID == ServiceRequest select element;
                serviceRequest serviceRequestBdd = req.FirstOrDefault();

                ServiceStartDate = serviceRequestBdd.serviceStartDate;
                ServiceFK = serviceRequestBdd.serviceFK;
                ServiceCityFK = (int)serviceRequestBdd.serviceCityFK;
                MemberFK = serviceRequestBdd.memberFK;

                var req2 = from volontaire in dc.member where volontaire.servicePrefFK == ServiceFK select volontaire;
                member selectedMemberBDD = req2.FirstOrDefault();

                int key = (int)selectedMemberBDD.dailyPrefFK;

                var req3 = from jour in dc.dailyPref where jour.dailyPrefID == key select jour;
                dailyPref dailyPrefBdd = req3.FirstOrDefault();

                int key2 = dailyPrefBdd.dayFK;

                if (selectedMemberBDD.cityFK == ServiceCityFK)
                {
                    if (key2 == (int)ServiceStartDate.DayOfWeek)
                    {
                        voluntaryID = selectedMemberBDD.memberID;
                    }
                }
                return voluntaryID;
            }
           //Envoyer la notification du matching


           //Charger les ServiceRequest en Bénéficiaire


           //Charger les ServiceRequest en Volontaire
           


        }



    }
}