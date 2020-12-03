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

        public ActionResult Details(int id)
        {
            //ConsoleService consoleService = CreateConsoleService();
            //var entity = consoleService.GetConsoleByID(consoleID);
            //return View(entity);
            var svc = CreateConsoleService();
            var model = svc.GetConsoleByID(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateConsoleService();
            var detail = service.GetConsoleByID(id);
            var model = new ConsoleEdit
            {
                ConsoleID = detail.ConsoleID,
                ConsoleName = detail.ConsoleName,
                ConsoleDescription = detail.ConsoleDescription
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ConsoleEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ConsoleID != id)
            {
                ModelState.AddModelError("", "ConsoleID Mismatch");
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
        public ActionResult Delete(int id)
        {
            var svc = CreateConsoleService();
            var model = svc.GetConsoleByID(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConsole(int id)
        {
            var service = CreateConsoleService();
            service.DeleteConsole(id);
            TempData["SaveResult"] = "The Console was Deleted.";
            return RedirectToAction("Index");
        }
    }
}