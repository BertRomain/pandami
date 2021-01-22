using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonAppliWeb.Models;

namespace MonAppliWeb.Controllers
{
    public class MemberController : Controller
    {
        // GET: Profil
        public ActionResult Index()
        {
            return View();
        }
    }
}