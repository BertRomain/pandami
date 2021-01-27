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
        public void Matching()
        {

        }



    }
}