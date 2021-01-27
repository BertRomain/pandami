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
            Member NewMember = new Member();
            return View(NewMember);
        }

        [HttpPost]
        public ActionResult SaveMbToBdd(Member member)
        {      
            bool rez = member.CreateMember();
            if (!rez) //condition affichage message d'erreur
            {  
                ViewBag.message = "Erreur lors de la création du membre";
                return View(member);
            } 
            //Problème !!!
            return View("~/Views/Home/Index");

        }
    }
}