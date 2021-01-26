using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonAppliWeb.Models;

namespace MonAppliWeb.Controllers
{
    public class AuthentificationController : Controller
    {
        // GET: Connexion
        public ActionResult Inscription()
        {
            //Appelle méthode inscription
            Member NewMember = new Member();

            //Enregistrement du nouveau membre
            //NewMember.CreateMember(FNMb, LNMb, BDMb, MailMb, NumMb, AdMb, CityMb, LogMb, PWMb);

            return View(NewMember);
        }

        [HttpPost]
        public ActionResult SaveMbToBdd(Member member)
        {      
            bool rez = member.CreateMember();
            if (!rez) //condition affichage message d'erreur
            {  
                string message = "Erreur lors de la création du membre";
                return View(member);
            } 
            return View("~/Accueil");

        }
    }
}