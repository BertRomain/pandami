using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonAppliWeb.Models;

namespace MonAppliWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Acceuil()
        {
            ViewBag.Message = "...";

            return View();
        }

        
        
      
    }
}