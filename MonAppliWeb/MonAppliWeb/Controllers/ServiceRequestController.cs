using MonAppliWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonAppliWeb.Views.ServiceRequest
{
    public class ServiceRequestController : Controller
    {
        // GET: Request -- Affichage des demandes de services
        [HttpGet]
        public ActionResult ListServiceRequest()
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                //Récuparation des demandes de services présentes dans la BDD dans une liste
                var dbServices = dm.serviceRequest.ToList();
                var requests = new List<serviceRequest>();

                foreach(var dbService in dbServices)
                {
                    var dbMemberBen = dm.member.FirstOrDefault(x => x.memberID == dbService.memberFK);
                    var dbMemberVol = dm.member.FirstOrDefault(x => x.memberID == dbService.voluntaryMemberFK);
                    requests.Add(new serviceRequest
                    {
                        serviceRequestID = dbService.serviceRequestID,
                        serviceStartDate = dbService.serviceStartDate,

                    });
                }
            }
            return View();
        }

        // GET: Request/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Request/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Request/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Request/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Request/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Request/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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

        
    }
}
