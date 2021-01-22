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

        public int City { get; set; }

        //Création d'un membre
        void CreateMember()
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                
            }
        }

        public Member()
        {

        }

        //Chargement d'un membre
        void LoadMember(int IDmember)
        {
            using (BddMemberDataContext dc = new BddMemberDataContext())
            {
                // Récupération de la vue "profilmembre" : 
                var req = from mb in dc.member where mb.memberID == noMb select mb;
                member memberBdd = req.FirstOrDefault();
                if (req.Count() > 0)
                {
                    FirstName = memberBdd.firstName;
                    LastName = memberBdd.lastName;
                    BirthDate = memberBdd.birthdate;
                    Email = memberBdd.email;
                    Address = memberBdd.address;
                    City = memberBdd.cityFK;
                    Login = memberBdd.login;
                    Password = memberBdd.password;
                }
            }
        }

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