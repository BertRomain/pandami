using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonAppliWeb.Models.DAO
{
    public class DAOMember
    {
        public List<Member> GetAllMembers()
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                //récupération des membres dans une liste
                var dbMembers = dm.member.ToList();
                var members = new List<Member>();

                foreach (var dbMember in dbMembers)
                {
                    var dbCity = dm.city.FirstOrDefault(x => x.cityID == dbMember.cityFK);
                    var dbZipCode = dm.zipCodes.FirstOrDefault(x => x.zipCodeID == dbCity.zipCodeFK);
                    members.Add(new Member
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
                    });
                }
                return members;
            }
        }

        //Pb avec return > enlever mode com' quand pb résolu
        //public member ModificationMember(int id)
        //{
        //    using (BddMemberDataContext dm = new BddMemberDataContext())
        //    {
        //        //récupération du membre avec identifiants id (parametre)
        //        var dbMember = dm.member.SingleOrDefault(n => n.memberID == id);
        //        var dbCity = dm.city.FirstOrDefault(x => x.cityID == dbMember.cityFK);
        //        var dbZipCode = dm.zipCodes.FirstOrDefault(x => x.zipCodeID == dbCity.zipCodeFK);
        //        var member = new Member
        //        {
        //            Address = dbMember.address,
        //            BirthDate = dbMember.birthdate,
        //            CityName = dbCity.cityName,
        //            CityFK = dbMember.cityFK,
        //            Email = dbMember.email,
        //            FirstName = dbMember.firstName,
        //            LastName = dbMember.lastName,
        //            MemberID = dbMember.memberID,
        //            Phone = dbMember.phone,
        //            ZipCode = dbZipCode.zipCode
        //        };
        //        return member;
        //    }
        //}

        public bool CreateMember(Member mb)
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                //Instanciation d'un membre
                
                // Récupération de cityFK
                int townFK = 0;

                var req = from villes in dm.zipCodes where villes.zipCode == mb.ZipCode select villes;
                zipCodes zipCodesBdd = req.FirstOrDefault();
                int key = zipCodesBdd.zipCodeID;

                var req2 = from element in dm.city where element.zipCodeFK == key select element;
                city cityBdd = req2.FirstOrDefault();
                string town = cityBdd.cityName;
                if (town == mb.CityName)
                {
                    townFK = cityBdd.cityID;
                }

                // Création dans la BDD du membre
                member newMb = new member()
                {
                    firstName = mb.FirstName,
                    lastName = mb.LastName,
                    birthdate = mb.BirthDate,
                    email = mb.Email,
                    phone = mb.Phone,
                    address = mb.Address,
                    cityFK = townFK,
                    login = mb.Login,
                    password = mb.Password
                };

                dm.member.InsertOnSubmit(newMb);
                dm.SubmitChanges();
                return true;
            }
        }

        

    }
}