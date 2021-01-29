using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonAppliWeb.Models;
using MonAppliWeb.Models.DAO;

namespace MonAppliWeb.Controllers
{
    public class MemberController : Controller
    {
        // GET: Profil -- Affichage des membres
        [HttpGet]
        public ActionResult Index()
        {
            //Appelle de la DAO contenant la méthode renvoyant la liste des membres
            DAOMember daoM = new DAOMember();
           return View(daoM.GetAllMembers()); 
        }
        
        //Dans la DAO, le return ne fonctionne pas > à revoir
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                //récupération du membre avec identifiants id (parametre)
                var dbMember = dm.member.SingleOrDefault(n => n.memberID == id);
                var dbCity = dm.city.FirstOrDefault(x => x.cityID == dbMember.cityFK);
                var dbZipCode = dm.zipCodes.FirstOrDefault(x => x.zipCodeID == dbCity.zipCodeFK);
                var member = new Member
                {
                    Address = dbMember.address,
                    BirthDate = dbMember.birthdate,
                    CityName = dbCity.cityName,
                    CityFK = dbMember.cityFK,
                    Email = dbMember.email,
                    FirstName = dbMember.firstName,
                    LastName = dbMember.lastName,
                    MemberID = dbMember.memberID,
                    Phone = dbMember.phone,
                    ZipCode = dbZipCode.zipCode
                };
                return View(member);
            }
        }

    }

  
}