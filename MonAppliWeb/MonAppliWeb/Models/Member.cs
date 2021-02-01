using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MonAppliWeb.Models
{
    public class Member
    {
        public Member() //Convention de création de class
        {

        }

        public Member(string login, string password)
        {
            login = this.Login;
            password = this.Password;
        }

        public Member(string nom, string prenom, int ID)
        {
            nom = this.LastName;
            prenom = this.FirstName;
            ID = this.MemberID;
        }

        public int MemberID { get; set; }

        [Display(Name ="Prénom")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Nom")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Date de naissance")]
        [Required]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Téléphone")]
        public int Phone { get; set; }

        [Display(Name = "Adresse")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Login")]
        public string Login { get; set; }

        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Display(Name = "Ville")]
        [Required]
        public string CityName { get; set; }

        public int CityFK { get; set; }

        [Display(Name = "Code postal")]
        [Required]
        public int ZipCode { get; set; }

        public int ZipCodeFK { get; set; }

        /*Chargement d'un membre  -- Méthode inutilisé >> A SUP ?*/
        void LoadMember(int IDmember) // Appeler GetMember pour convention de nommage 
        {
            using (BddMemberDataContext dc = new BddMemberDataContext())
            {
                // Récupération de la vue "profilmembre" : 
                var req = from mb in dc.member where mb.memberID == IDmember select mb;
                member memberBdd = req.FirstOrDefault();
                if (req.Count() > 0)
                {
                    MemberID = memberBdd.memberID;
                    FirstName = memberBdd.firstName;
                    LastName = memberBdd.lastName;
                    BirthDate = memberBdd.birthdate;
                    Email = memberBdd.email;
                    Address = memberBdd.address;
                    Phone = memberBdd.phone;
                    CityFK = (int)memberBdd.cityFK;
                    Login = memberBdd.login;
                    Password = memberBdd.password;
                }
            }
        }

        //Méthode inutilisé >> A SUP ?
        //public bool Connection()
        //{
        //    using (BddMemberDataContext dc = new BddMemberDataContext())
        //    {
        //        var req = from mb in dc.member where mb.login == Login select mb;
        //        member memberBdd = req.FirstOrDefault();
        //        bool Connection = false;
        //            if (Password == memberBdd.password)
        //             {
        //            Connection = true;          
        //             }
        //        return Connection;

        //    }
        //}

        //Méthode inutilisé >> A SUP ?
        //public string AfficherVilles(int codepostal)
        //{
        //    using(BddMemberDataContext dc = new BddMemberDataContext())
        //    {
        //        var req = from villes in dc.zipCodes where villes.zipCode == codepostal select villes;
        //        zipCodes zipCodesBdd = req.FirstOrDefault();
        //        int key = zipCodesBdd.zipCodeID;
               
        //        var req2 = from elmt in dc.city where elmt.zipCodeFK == key select elmt;
        //        city cityBdd = req2.FirstOrDefault();
        //            return cityBdd.cityName;
                
        //    }
        //}


    }

    
}