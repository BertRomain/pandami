using MonAppliWeb.DAO;
using MonAppliWeb.Models;
using System.Linq;
using System.Web.Mvc;

namespace MonAppliWeb.Controllers
{
    public class MemberController : Controller
    {
        // GET: Profil -- Affichage des membres
        [HttpGet]
        public ActionResult Index()
        {
            //Appelle de la DAO contenant la méthode renvoyant la liste des membres
            DAOMember daoM = new DAOMember();
            return View(daoM.GetAllMembers());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Member());
        }

        [HttpPost]
        public ActionResult Create(Member member)
        {
            var daoMember = new DAOMember();
            var memberID = daoMember.CreateMember(member);
            if (!memberID.HasValue)
            {
                ViewBag.message = "Erreur lors de la création du membre";
                return View(member);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var daoMember = new DAOMember();
            var dbMember = daoMember.GetMember(id);
            var member = new Member
            {
                Address = dbMember.address,
                BirthDate = dbMember.birthdate,
                CityName = dbMember.city.cityName,
                CityFK = dbMember.cityFK,
                Email = dbMember.email,
                FirstName = dbMember.firstName,
                LastName = dbMember.lastName,
                MemberID = dbMember.memberID,
                Phone = dbMember.phone,
                ZipCode = dbMember.zipCodes.zipCode,
                ZipCodeFK = dbMember.zipCodeFK
            };
            return View(member);
        }

        [HttpPost]
        public ActionResult Edit(Member member)
        {
            var daoMember = new DAOMember();
            var success = daoMember.ModificationMember(member);
            if (!success)
            {
                ViewBag.message = "Erreur lors de la modification du membre";
                return View(member);
            }
            return RedirectToAction("Index");
        }
    }
}