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
    }

    public Member()
    {

    }

    void MemberCharge(int noMb)
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
                City = memberBdd.city;
                Login = memberBdd.login;
                Password = memberBdd.password;
            }
        }
    }
}