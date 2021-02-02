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

        public member GetMember(int memberId)
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                var dbMember = dm.member.FirstOrDefault(x => x.memberID == memberId);
                return dbMember;
            }
        }

        //Pb avec return > enlever mode com' quand pb résolu
        public bool ModificationMember(Member mb)
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                // Récupération du member
                var existingMember = this.GetMember(mb.MemberID);

                // Si Zipcode a été modifiée
                if (mb.ZipCode != existingMember.zipCodes.zipCode)
                {
                    // Récupérer la city a partir du nom
                    var daoZipcode = new DAOZipCode();
                    var zipCode = daoZipcode.GetZipCodeByCode(mb.ZipCode);
                    if (zipCode == null)
                    {
                        // Si n'existe pas, créer la city
                        var zipcodeID = daoZipcode.CreateZipCode(mb.ZipCode);
                        if (!zipcodeID.HasValue) return false;
                        mb.ZipCodeFK = zipcodeID.Value;
                    }
                    else
                    {
                        // Récupérer la city
                        mb.ZipCodeFK = zipCode.zipCodeID;
                    }
                }
                else
                {
                    // Garder la meme city
                    mb.ZipCodeFK = existingMember.zipCodeFK;
                }


                // Si City a été modifiée
                if (mb.CityName != existingMember.city.cityName)
                {
                    // Récupérer la city a partir du nom
                    var daoCity = new DAOCity();
                    var city = daoCity.GetCity(mb.CityName);
                    if (city == null)
                    {
                        // Si n'existe pas, créer la city
                        var cityId = daoCity.CreateCity(mb.CityName);
                        if(!cityId.HasValue) return false;
                        mb.CityFK = cityId.Value;
                    }
                    else
                    {
                        // Récupérer la city
                        mb.CityFK = city.cityID;
                    }
                }
                else
                {
                    // Garder la meme city
                    mb.CityFK = existingMember.cityFK;
                }

                existingMember.address = mb.Address;
                existingMember.birthdate = mb.BirthDate;
                existingMember.city = null;
                existingMember.cityFK = mb.CityFK;
                existingMember.email = mb.Email;
                existingMember.firstName = mb.FirstName;
                existingMember.lastName = mb.LastName;
                existingMember.phone = mb.Phone;
                existingMember.zipCodes = null;
                existingMember.zipCodeFK = mb.ZipCodeFK;

                dm.SubmitChanges();
                return true;
            }
        }

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
                    login = mb.Email,
                    password = string.IsNullOrWhiteSpace(mb.Password) ? "Password1" : mb.Password,
                    zipCodeFK = zipCodeId.Value
                };

                dm.member.InsertOnSubmit(newMb);
                dm.SubmitChanges();
                return newMb.memberID;
            }
        }
    }
}