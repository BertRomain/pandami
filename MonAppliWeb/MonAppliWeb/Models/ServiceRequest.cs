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
        public string ServiceName { get; set; }

        [Display(Name = "Date du service")]
        [Required]
        public DateTime ServiceStartDate { get; set; }

        public string ServiceStartDateToDisplay { get { return ServiceStartDate.ToString("dd/MM/yyyy"); } }
        
        [Display(Name = "Date de fin du service")]
        public DateTime? ServiceEndDate { get; set; }

        [Display(Name = "Date de création de la demande")]
        public DateTime ServiceRequestCreationDate { get; set; }

        [Display(Name = "Date d'annulation")]
        public DateTime? CancelDate { get; set; }

        public string CancelDateToDisplay { get { return CancelDate.HasValue ? CancelDate.Value.ToString("dd/MM/yyyy") : string.Empty; } }

        [Display(Name = "ID du bénéficiaire")]
        public int MemberFK { get; set; }

        [Display(Name = "Nom du bénéficiaire")]
        public string BeneficiaryLName { get; set; }

        [Display(Name = "Prénom du bénéficiaire")]
        public string BeneficiaryFName { get; set; }

        [Display(Name = "ID du volontaire")]
        public int? VoluntaryMemberFK { get; set; }

        [Display(Name = "Nom du volontaire")]
        public string VoluntaryLName { get; set; }

        [Display(Name = "Prénom du volontaire")]
        public string VoluntaryFName { get; set; }

        [Display(Name = "ID de la ville où est effectué le service")]
        public int ServiceCityFK { get; set; }

        [Display(Name = "Adresse du service")]
        public string ServiceAddress { get; set; }

        [Display(Name = "Ville du service")]
        public string ServiceCityName { get; set; }
    }
}