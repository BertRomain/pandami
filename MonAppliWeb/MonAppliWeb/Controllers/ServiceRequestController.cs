using Microsoft.Ajax.Utilities;
using MonAppliWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MonAppliWeb.Controllers
{
    public class ServiceRequestController : Controller
    {
        // GET: Request -- Affichage des demandes de services
        [HttpGet]
        public ActionResult ListServiceRequest()
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                //Récupération des demandes de services présentes dans la BDD dans une liste
                var dbServices = dm.serviceRequest.ToList();
                var requests = new List<ServiceRequest>();

                foreach(var dbService in dbServices)
                {
                    var dbMemberBen = dm.member.FirstOrDefault(x => x.memberID == dbService.memberFK);
                    // var dbMemberVol = dm.member.FirstOrDefault(x => x.memberID == dbService.voluntaryMemberFK);
                    var dbServiceName = dm.serviceNames.FirstOrDefault(x => x.serviceID == dbService.serviceFK);
                    var dbCity = dm.city.FirstOrDefault(x => x.cityID == dbService.serviceCityFK);
                    requests.Add(new ServiceRequest
                    {
                        ServiceRequestID = dbService.serviceRequestID,
                        ServiceStartDate = dbService.serviceStartDate,
                        ServiceName = dbServiceName.serviceName,
                        MemberFK = dbService.memberFK,
                        BeneficiaryFName = dbMemberBen.firstName,
                        BeneficiaryLName = dbMemberBen.lastName,
                        VoluntaryMemberFK = dbService.memberFK,
                        //VoluntaryFName = dbMemberVol.firstName,
                        //VoluntaryLName = dbMemberVol.lastName,
                        ServiceAddress = dbService.serviceAddress,
                        ServiceCityName = dbCity.cityName,
                    }) ;
                }
                return View(requests);
            }
           
        }

        public ActionResult Matching()
        {
            using (BddMemberDataContext dc = new BddMemberDataContext())
            {

                var dbServices = dc.serviceRequest.ToList();
                var requests = new List<ServiceRequest>();

                foreach (var dbService in dbServices)
                {
                    var dbMemberBen = dc.member.FirstOrDefault(x => x.memberID == dbService.memberFK);
                    // var dbMemberVol = dm.member.FirstOrDefault(x => x.memberID == dbService.voluntaryMemberFK);
                    var dbServiceName = dc.serviceNames.FirstOrDefault(x => x.serviceID == dbService.serviceFK);
                    var dbCity = dc.city.FirstOrDefault(x => x.cityID == dbService.serviceCityFK);
                    requests.Add(new ServiceRequest
                    {
                        ServiceRequestID = dbService.serviceRequestID,
                        ServiceStartDate = dbService.serviceStartDate,
                        ServiceName = dbServiceName.serviceName,
                        MemberFK = dbService.memberFK,
                        BeneficiaryFName = dbMemberBen.firstName,
                        BeneficiaryLName = dbMemberBen.lastName,
                        VoluntaryMemberFK = dbService.memberFK,
                        //VoluntaryFName = dbMemberVol.firstName,
                        //VoluntaryLName = dbMemberVol.lastName,
                        ServiceAddress = dbService.serviceAddress,
                        ServiceCityName = dbCity.cityName,
                    });
                }

                foreach (var ServiceRequest in requests)
                {
                    if (ServiceRequest.VoluntaryMemberFK == null)
                    {
                        ServiceRequest sr = new ServiceRequest();

                        var test =
                            from mb in dc.member
                            from k in dc.dailyPref
                            where mb.servicePrefFK == sr.ServiceFK && k.dailyPrefID == mb.dailyPrefFK && k


                        //fetch des informations de la demande de service 
                        var req2 = from volontaire in dc.member where volontaire.servicePrefFK == sr.ServiceFK  select volontaire;
                        member selectedMemberBDD = req2.FirstOrDefault();

                        int key = (int)selectedMemberBDD.dailyPrefFK;

                        var req3 = from jour in dc.dailyPref where jour.dailyPrefID == key select jour;
                        dailyPref dailyPrefBdd = req3.FirstOrDefault();

                        int key2 = dailyPrefBdd.dayFK;

                        if (selectedMemberBDD.cityFK == ServiceCityFK)
                        {
                            if (key2 == (int)ServiceStartDate.DayOfWeek)
                            {
                                VoluntaryMemberFK = selectedMemberBDD.memberID;
                                serviceRequestBdd.voluntaryMemberFK = VoluntaryMemberFK;
                            }
                        }
                        dc.SubmitChanges();
                    }
                }               
            }
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
