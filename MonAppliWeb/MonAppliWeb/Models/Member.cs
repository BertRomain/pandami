﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

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
        public bool CreateMember()
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                // Récupération de cityFK
                int townFK = 0;


                var req = from villes in dm.zipCodes where villes.zipCode == ZipCode select villes;
                zipCodes zipCodesBdd = req.FirstOrDefault();
                int key = zipCodesBdd.zipCodeID;

                var req2 = from element in dm.city where element.zipCodeFK == key select element;
                city cityBdd = req2.FirstOrDefault();
                string town = cityBdd.cityName;
                if (town == City)
                {
                    townFK = cityBdd.cityID;
                }

                // Création dans la BDD du membre
                member newMb = new member() {
                    firstName = FirstName,
                    lastName = LastName,
                    birthdate = BirthDate,
                    email = Email,
                    phone = Phone,
                    address = Address,
                    cityFK = townFK,
                    login = Login,
                    password = Password};
              
                dm.member.InsertOnSubmit(newMb);
                return true;
            }
        }

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

        public string AfficherVilles(int codepostal)
        {
            using(BddMemberDataContext dc = new BddMemberDataContext())
            {
                var req = from villes in dc.zipCodes where villes.zipCode == codepostal select villes;
                zipCodes zipCodesBdd = req.FirstOrDefault();
                int key = zipCodesBdd.zipCodeID;
               
                var req2 = from elmt in dc.city where elmt.zipCodeFK == key select elmt;
                city cityBdd = req2.FirstOrDefault();
                    return cityBdd.cityName;
                
            }
        }

      /*  public string TestVilles(int code)
        {
            using (DataClasses1DataContext df = new DataClasses1DataContext())
            {
                df.GetCityZipCode();
                
                return 
            }
        }*/

    }

    
}