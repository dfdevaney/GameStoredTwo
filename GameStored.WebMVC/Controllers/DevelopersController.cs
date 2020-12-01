using GameStoredTwo.Models.Developer;
using GameStoredTwo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStored.WebMVC.Controllers
{
        [Authorize]
        public class DeveloperController: Controller
        {
            private DeveloperService CreateDeveloperService()
            {
                var service = new DeveloperService();
                return service;
            }

            // Get: Developer
            public ActionResult Index()
            {
                var service = CreateDeveloperService();
                var model = service.GetDevelopers();
                return View(model);
            }

            public ActionResult Create()
            {
                return View();
            }

            // Post
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(DeveloperCreate model)
            {
                if (!ModelState.IsValid) return View(model);
                var service = CreateDeveloperService();
                if (service.CreateDeveloper(model))
                {
                    TempData["SaveResult"] = "Deveolper has been Created.";
                    return RedirectToAction("Index");
                };
                ModelState.AddModelError("", "Developer could not be Created.");
                return View(model);
            }

            public ActionResult Details(int developerID)
            {
                var svc = CreateDeveloperService();
                var model = svc.GetDeveloperByID(developerID);
                return View(model);
            }

            public ActionResult Edit(int developerID)
            {
                var service = CreateDeveloperService();
                var detail = service.GetDeveloperByID(developerID);
                var model = new DeveloperEdit
                {
                    DeveloperID = detail.DeveloperID,
                    DeveloperName = detail.DeveloperName
                };
                return View(model);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int developerID, DeveloperEdit model)
            {
                if (!ModelState.IsValid) return View(model);

                if(model.DeveloperID != developerID)
                {
                    ModelState.AddModelError("", "DeveoperID Mismatch");
                    return View(model);
                }
                var service = CreateDeveloperService();

                if (service.UpdateDeveloper(model))
                {
                    TempData["SaveResult"] = "The Developer was Updated.";
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "The Developer could not be Updated.");
                return View(model);
            }

            [ActionName("Delete")]
            public ActionResult Delete(int developerID)
            {
                var svc = CreateDeveloperService();
                var model = svc.GetDeveloperByID(developerID);
                return View(model);
            }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDeveloper(int developerID)
        {
            var service = CreateDeveloperService();
            service.DeleteDeveloper(developerID);
            TempData["SaveResult"] = "The Developer was Deleted.";
            return RedirectToAction("Inex");
        }
    }
}