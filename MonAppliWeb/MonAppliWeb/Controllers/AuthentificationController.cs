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
            return View();
        }

        public string IActionInvokerFactory(int ZCMb)
        {
            Member NewMember = new Member();

            //Affichage des villes en focntions du code postal saisi
            return  NewMember.AfficherVilles(ZCMb);
        }
    }
}