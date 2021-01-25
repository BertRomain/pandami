using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonAppliWeb.Models
{
    public class Member
    {
        public int MemberID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        
        public string Email { get; set; }

        public int Phone { get; set; }

        public string Address { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string City { get; set; }

        public int ZipCode { get; set; }

        //Création d'un membre
        void CreateMember(string firstname, string lastname, DateTime birthdate, string email, int phone, string address, string login, string city, string password)
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                //Récupation du ZipCode

                //Villes selon CP -> récup

                //Récupération du CityID à partir du string city et + du zipCode
                var reqC = from ville in dm.city where ville.cityName == city select ville;
                city CityBdd = reqC.FirstOrDefault();
                int CityFK = CityBdd.cityID;

                // Création dans la BDD du membre
                member newMb = new member() {
                    firstName = firstname, 
                    lastName = lastname, 
                    birthdate = birthdate,
                    email = email,
                    phone = phone, address = address,
                    login = login,
                    cityFK = CityFK,
                    password = password};
              
                dm.member.InsertOnSubmit(newMb);
            }
        }

        /*public int FetchFkId (string table, int FK, int PK, string Link)
        {
            var req = from element in dm.table where element.Link == table select element;
            table tableBdd = req.FirstOrDefault();
            int FK = tableBdd.PK;
            return FK;
        }*/

        //méthode private récupération


        public Member()
        {

        }

        /*Chargement d'un membre
        void LoadMember(int IDmember)
        {
            using (BddMemberDataContext dc = new BddMemberDataContext())
            {
                // Récupération de la vue "profilmembre" : 
                var req = from mb in dc.member where mb.memberID == IDmember select mb;
                
                member memberBdd = req.FirstOrDefault();
                if (req.Count() > 0)
                {
                    FirstName = memberBdd.firstName;
                    LastName = memberBdd.lastName;
                    BirthDate = memberBdd.birthdate;
                    Email = memberBdd.email;
                    Address = memberBdd.address;
                    int villeFK = memberBdd.cityFK;


                    City = memberBdd.cityFK;
                    Login = memberBdd.login;
                    Password = memberBdd.password;
                }
            }
        }*/

        public int Connection(string log, string pass)
        {
            using (BddMemberDataContext dc = new BddMemberDataContext())
            {
                var req = from mb in dc.member where mb.login == log select mb;
                member memberBdd = req.FirstOrDefault();
                int i = 0;
                if (pass != memberBdd.password)
                {
                    //TO DO : A revoir
                    do
                    {
                        // "Mot de passe incorrect !";
                        i++;
                    } while (pass != memberBdd.password && i < 4);
                    //Penser à mettre fnct quand mdp erroné i > 4
                }
                //> autre méthode ou ouvrir sur vue accueil
                return MemberID;

            }
        }

    }

    
}