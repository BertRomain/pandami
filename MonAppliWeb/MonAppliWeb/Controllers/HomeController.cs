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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Histoire()
        {
         

            return View();
        }
        /*
        public ActionResult GestionClient()
        {
            Client monClient = new Client();
            
            return View(monClient);
        }
        */
        
        public ActionResult GestionClient(string numClient)
        {
            int numCli;
            Client monClient;
            if (!Int32.TryParse(numClient, out numCli))
            {
                monClient = new Client();
            }
            else
            {
                monClient = new Client(numCli);
            }
            return View(monClient);
        }
    }
}