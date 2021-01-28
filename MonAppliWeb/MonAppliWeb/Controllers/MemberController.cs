using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonAppliWeb.Models;

namespace MonAppliWeb.Controllers
{
    public class MemberController : Controller
    {
        // GET: Profil -- Affichage des membres
        [HttpGet]
        public ActionResult Index()
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                //récupération des membres dans une liste
                var dbMembers = dm.member.ToList();
                var members = new List<Member>();

                foreach(var dbMember in dbMembers)
                {
                    var dbCity = dm.city.FirstOrDefault(x => x.cityID == dbMember.cityFK);
                    var dbZipCode = dm.zipCodes.FirstOrDefault(x => x.zipCodeID == dbCity.zipCodeFK);
                    members.Add(new Member { 
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
                    });
                }
                return View(members);
            }
        }
    
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

        //Création d'un membre    //Penser à passer les méthodes d'appel de données dans le MemberController
        //public bool CreateMember()
        //{
        //    using (BddMemberDataContext dm = new BddMemberDataContext())
        //    {
        //        // Récupération de cityFK
        //        int townFK = 0;

        //        var req = from villes in dm.zipCodes where villes.zipCode == ZipCode select villes;
        //        zipCodes zipCodesBdd = req.FirstOrDefault();
        //        int key = zipCodesBdd.zipCodeID;

        //        var req2 = from element in dm.city where element.zipCodeFK == key select element;
        //        city cityBdd = req2.FirstOrDefault();
        //        string town = cityBdd.cityName;
        //        if (town == City)
        //        {
        //            townFK = cityBdd.cityID;
        //        }

        //        // Création dans la BDD du membre
        //        member newMb = new member()
        //        {
        //            firstName = FirstName,
        //            lastName = LastName,
        //            birthdate = BirthDate,
        //            email = Email,
        //            phone = Phone,
        //            address = Address,
        //            cityFK = townFK,
        //            login = Login,
        //            password = Password
        //        };

        //        dm.member.InsertOnSubmit(newMb);
        //        newMb.memberID = MemberID;
        //        return true;
        //    }
        //}
    }

  
}