using GameStoredTwo.Models.Publisher;
using GameStoredTwo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStored.WebMVC.Controllers
{
    [Authorize]
    public class PublisherController : Controller
    {
        private PublisherService CreatePublisherService()
        {
            var service = new PublisherService();
            return service;
        }

        // Get: Publisher
        public ActionResult Index()
        {
            var service = CreatePublisherService();
            var model = service.GetPublishers();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // Post: Publisher
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PublisherCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreatePublisherService();
            if (service.CreatePublisher(model))
            {
                TempData["SaveResult"] = "Publisher has been Created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Publisher could not be Created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePublisherService();
            var model = svc.GetPublisherByID(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePublisherService();
            var detail = service.GetPublisherByID(id);
            var model = new PublisherEdit
            {
                PublisherID = detail.PublisherID,
                PublisherName = detail.PublisherName
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PublisherEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PublisherID != id)
            {
                ModelState.AddModelError("", "PublisherID Mismatch");
                return View(model);
            }
            var service = CreatePublisherService();

            if (service.UpdatePublisher(model))
            {
                TempData["SaveResult"] = "The Publisher was Updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Publisher could not be Updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePublisherService();
            var model = svc.GetPublisherByID(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePublisher(int id)
        {
            var service = CreatePublisherService();
            service.DeletePublisher(id);
            TempData["SaveResult"] = "The Publisher was Deleted.";
            return RedirectToAction("Inex");
        }
    }
}