using GameStoredTwo.Models.Console;
using GameStoredTwo.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStored.WebMVC.Controllers
{
    [Authorize]
    public class ConsolesController : Controller
    {
        private ConsoleService CreateConsoleService()
        {
            //var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ConsoleService();
            return service;
        }

        // GET: Consoles
        public ActionResult Index()
        {
            var service = CreateConsoleService();
            var model = service.GetConsoles();
            return View(model);
        }

        //GET : Consoles
        public ActionResult Create()
        {
            return View();
        }

        // Post : Consoles
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConsoleCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateConsoleService();
            if (service.CreateConsoles(model))
            {
                TempData["SaveResult"] = "Console has been Created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Console could not be Created.");
            return View(model);
        }
        public ActionResult Details(int consoleID)
        {
            var svc = CreateConsoleService();
            var model = svc.GetConsoleByID(consoleID);
            return View(model);
        }

        public ActionResult Edit(int consoleID)
        {
            var service = CreateConsoleService();
            var detail = service.GetConsoleByID(consoleID);
            var model = new ConsoleEdit
            {
                ConsoleName = detail.ConsoleName,
                ConsoleDescription = detail.ConsoleDescription
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int consoleID, ConsoleEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ConsoleID != consoleID)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateConsoleService();

            if (service.UpdateConsole(model))
            {
                TempData["SaveResult"] = "The Console was Updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Console could not be Updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int consoleID)
        {
            var svc = CreateConsoleService();
            var model = svc.GetConsoleByID(consoleID);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConsole(int consoleID)
        {
            var service = CreateConsoleService();
            service.DeleteConsole(consoleID);
            TempData["SaveResult"] = "The Console was Deleted.";
            return RedirectToAction("Inex");
        }

    }
}