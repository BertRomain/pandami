using MonAppliWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
//using Member = MonAppliWeb.Models.Member;

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

                        //Requête permettant de faire correspondre une demande -- Le but est de sélectionner le premier membre correspondant à tous les critères
                        var test =
                            from mb in dc.member
                            from k in dc.dailyPref
                            from k2 in dc.days
                                // mb.servicePrefFK = sr.ServiceFK > Quand l'une des préférences de services du membre correspond au service demandé
                                // k.dailyPrefID = mb.dailyPrefFK > On vient récupé la table des pref correspondand à celle du membre
                                // k.dayFK == k2.dayID > Joint les id correspondants entre les la table pref et day
                                // k2.dayID == (int)sr.ServiceStartDate.DayOfWeek > Quand le jour pref correspond au jour du service
                            where mb.servicePrefFK == sr.ServiceFK
                                    && k.dailyPrefID == mb.dailyPrefFK
                                    && k.dayFK == k2.dayID
                                    && k2.dayID == (int)sr.ServiceStartDate.DayOfWeek
                            select mb;

                            //OU

                        //Test requête avec join -- Si cette requête marche, à adapter dans les autres méthodes (notamment dans membre)
                        var test2 = from mb in dc.member
                                    where mb.servicePrefFK == sr.ServiceFK
                                    join k in dc.dailyPref on mb.dailyPrefFK equals k.dailyPrefID
                                    join c in dc.days on k.dayFK equals c.dayID
                                    where c.dayID == (int)sr.ServiceStartDate.DayOfWeek
                                    select mb;
                        member selectMemberBdd = test2.FirstOrDefault();

                        //Condition dans le cas où il séléctionne comme volontaire le bénéficiaire
                        if (sr.MemberFK == selectMemberBdd.memberID)
                        {
                            //Refaire la requête en excluant ce membre
                            //Pas trouver comment faire
                        }
                        //Sinon
                        //Association à la ServiceRequest l'ID du volontaire
                        sr.VoluntaryMemberFK = selectMemberBdd.memberID;
                        //Remplissage de voluntaryMemberFK avec l'ID dans la base de données --> A vérifier !
                        //Comment ajouter dans la base de donnée, le voluntaryID à la table ServiceRequest ?
                        dc.SubmitChanges();

                        




                    //Ancienne Version de la méthode
                        //fetch des informations de la demande de service 
                        //var req2 = from volontaire in dc.member where volontaire.servicePrefFK == sr.ServiceFK  select volontaire;
                        //member selectedMemberBDD = req2.FirstOrDefault();

                        //int key = (int)selectedMemberBDD.dailyPrefFK;

                        //var req3 = from jour in dc.dailyPref where jour.dailyPrefID == key select jour;
                        //dailyPref dailyPrefBdd = req3.FirstOrDefault();

                        //int key2 = dailyPrefBdd.dayFK;

                        //if (selectedMemberBDD.cityFK == ServiceCityFK)
                        //{
                        //    if (key2 == (int)ServiceStartDate.DayOfWeek)
                        //    {
                        //        VoluntaryMemberFK = selectedMemberBDD.memberID;
                        //        serviceRequestBdd.voluntaryMemberFK = VoluntaryMemberFK;
                        //    }
                        //}
                        //dc.SubmitChanges();
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
