using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace MonAppliWeb.Models
{
    public class ServiceRequest
    {
        public ServiceRequest()
        {

        }

        public int ServiceRequestID { get; set; }

        [Display(Name = "ID du service")]
        public int ServiceFK { get; set; }

        [Display(Name = "Nom du service")]
        public int ServiceName { get; set; }

        [Display(Name = "Date du service")]
        [Required]
        public DateTime ServiceStartDate { get; set; }

        [Display(Name = "Date de fin du service")]
        public DateTime ServiceEndDate { get; set; }

        [Display(Name = "Date de création de la demande")]
        public DateTime ServiceRequestCreationDate { get; set; }

        [Display(Name = "Date d'annulation")]
        public DateTime CancelDate { get; set; }

        [Display(Name = "ID du bénéficiaire")]
        public int MemberFK { get; set; }

        [Display(Name = "Nom du bénéficiaire")]
        public string BeneficiaryLName { get; set; }

        [Display(Name = "Prénom du bénéficiaire")]
        public string BeneficiaryFName { get; set; }

        [Display(Name = "ID du volontaire")]
        public int VoluntaryMemberFK { get; set; }

        [Display(Name = "Nom du volontaire")]
        public string VoluntaryLName { get; set; }

        [Display(Name = "Prénom du volontaire")]
        public string VoluntaryFName { get; set; }

        [Display(Name = "ID de la ville où est effectué le service")]
        public int ServiceCityFK { get; set; }

        [Display(Name = "Adresse du service")]
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