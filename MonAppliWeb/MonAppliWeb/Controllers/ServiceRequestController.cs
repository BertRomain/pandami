using MonAppliWeb.DAO;
using MonAppliWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MonAppliWeb.Controllers
{
    public class ServiceRequestController : Controller
    {
        // GET: Request -- Affichage des demandes de services
        [HttpGet]
        public ActionResult ListServiceRequest()
        {
            DAOSR daoSR = new DAOSR();
            return View(daoSR.GetAllServiceRequests());
        }

        [HttpGet]
        public ActionResult Create()
        {
            // Instancier la classe ServiceRequest et passer a la vue
            
            return View(new ServiceRequest());
        }


        [HttpPost]
        public ActionResult Create(ServiceRequest service)
        {
            //Appelle de la DAO (qui permet l'appelle à la méthode)
            DAOSR daoSR = new DAOSR();
            var rez = daoSR.CreateServiceRequest(service);
            if (!rez.HasValue)
            {
                ViewBag.message = "Erreur lors de la création de la demande de service";
                return View(service);
            }
            return RedirectToAction("ListServiceRequest","ServiceRequest");
        }

        [HttpPost]
        public ActionResult CreateServiceBdd(ServiceRequest serviceRequest)
        {
            // Créer le serviceRequest dans la BDD

            // Utiliser serviceRequest pour appeler la méthode Matching

            // Créer une notification dans la BDD pour chaque memberID récupéré par la méthode Matching
            return View();
        }

        
        // GET: Request/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Request/Edit/5
        [HttpGet]
        public ActionResult Accept(int id, int srID)
        {
            DAOSR dao = new DAOSR();
            dao.VoluntaryAnswerAccceptation(id, srID);
            return RedirectToAction("ListServiceRequest", "ServiceRequest");
        }

        // GET: Request/Delete/5
        public ActionResult Refuse(int id, int srID)
        {
            DAOSR dao = new DAOSR();
            dao.VoluntaryAnswerRejection(id, srID);
            return RedirectToAction("ListServiceRequest", "ServiceRequest");
        }

        // POST: Request/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Matching(int id)
        {
            
            DAOSR dAOSRMatching = new DAOSR();

            ServiceRequest sr = new DAOSR().GetSRById(id);

            var matching = new Matching();
            matching.ServiceRequestID = id;

            matching.Members = dAOSRMatching.ReturnVoluntaryOfSR(sr);

            return View(matching);
        }
    }
}

