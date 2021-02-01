using MonAppliWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace MonAppliWeb.DAO
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
                    var dbZipCode = dm.zipCodes.FirstOrDefault(x => x.zipCodeID == dbMember.zipCodeFK);
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

        public int? CreateMember(Member mb)
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                // Récupération de zipCode
                var daoZipCode = new DAOZipCode();
                var zipCode = daoZipCode.GetZipCodeByCode(mb.ZipCode);
                // Si Zipcode existe, récupérer ID, sinon, créer et récupérer ID
                var zipCodeId = zipCode == null ? daoZipCode.CreateZipCode(mb.ZipCode) : zipCode.zipCodeID;

                // Récupération de city
                var daoCity = new DAOCity();
                var city = daoCity.GetCity(mb.CityName);
                // Si Zipcode existe, récupérer ID, sinon, créer et récupérer ID
                var cityId = city == null ? daoCity.CreateCity(mb.CityName) : city.cityID;

                // Création dans la BDD du membre
                member newMb = new member()
                {
                    firstName = mb.FirstName,
                    lastName = mb.LastName,
                    birthdate = mb.BirthDate,
                    email = mb.Email,
                    phone = mb.Phone,
                    address = mb.Address,
                    cityFK = cityId.Value,
                    login = mb.Login,
                    password = mb.Password,
                    zipCodeFK = zipCodeId.Value
                };

                dm.member.InsertOnSubmit(newMb);
                dm.SubmitChanges();
                return newMb.memberID;
            }
        }
    }
}