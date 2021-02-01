using MonAppliWeb.DAO;
using MonAppliWeb.Models;
using System.Web.Mvc;

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
            DAOMember daoM = new DAOMember();
            var rez = daoM.CreateMember(member);
            if (!rez.HasValue) //condition affichage message d'erreur
            {  
                ViewBag.message = "Erreur lors de la création du membre";
                return View(member);
            } 
            return RedirectToAction("Index", "Member");
        }

        // A supprimer > plus d'utilité
        //[HttpPost]
        //public ActionResult Connexion(Member member)
        //{
        //    bool rez = member.Connection();
        //    if (!rez)
        //    {
        //        ViewBag.message = "Login et/ou Mot de Passe incorrect(s)";
        //        return View(member);
        //    }
        //    return View();
        //}
    }
}