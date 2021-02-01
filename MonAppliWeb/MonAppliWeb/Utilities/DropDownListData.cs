using MonAppliWeb.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonAppliWeb.Utilities
{
    public static class DropDownListData
    {
        public static List<SelectListItem> GetAllMembers()
        {
            var daoMember = new DAOMember();
            var listMembers = daoMember.GetAllMembers();
            var dropdownList = new List<SelectListItem>();
            foreach(var member in listMembers)
            {
                dropdownList.Add(new SelectListItem
                {
                    Value = member.MemberID.ToString(),
                    Text = $"{member.FirstName} {member.LastName} (ID : {member.MemberID})"
                });
            }
            return dropdownList;
        }

        public static List<SelectListItem> GetAllServices()
        {
            var daoSR = new DAOSR();
            var services = daoSR.GetAllServices();
            var dropdownList = new List<SelectListItem>();
            foreach(var service in services)
            {
                dropdownList.Add(new SelectListItem
                {
                    Value = service.serviceID.ToString(),
                    Text = service.serviceName1.ToString()
                });
            }
            return dropdownList;
        }
    }
}