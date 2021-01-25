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

            return View();
        }
    }
}