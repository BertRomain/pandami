using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonAppliWeb.Models;

namespace MonAppliWeb.Controllers
{
    public class ConnexionController : Controller
    {
        // GET: Connexion
        public ActionResult Inscription()
        {
            //Appelle méthode inscription


            return View();
        }
    }
}