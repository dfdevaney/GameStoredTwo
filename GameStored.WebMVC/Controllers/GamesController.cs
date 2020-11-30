using GameStoredTwo.Models.Game;
using GameStoredTwo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStored.WebMVC.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private GameService CreateGameService()
        {
            var service = new GameService();
            return service;
        }

        // Get: Game
        public ActionResult Index()
        {
            var service = CreateGameService();
            var model = service.GetGames();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // Post: Game
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateGameService();
            if (service.CreateGame(model))
            {
                TempData["SaveResult"] = "Game has been Created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Game could not be Created.");
            return View(model);
        }

        public ActionResult Details(int gameID)
        {
            var svc = CreateGameService();
            var model = svc.GetGameByID(gameID);
            return View(model);
        }

        public ActionResult Edit(int gameID)
        {
            var service = CreateGameService();
            var detail = service.GetGameByID(gameID);
            var model = new GameEdit
            {
                GameTitle = detail.GameTitle
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int gameID, GameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GameID != gameID)
            {
                ModelState.AddModelError("", "GameID Mismatch");
                return View(model);
            }
            var service = CreateGameService();

            if (service.UpdateGame(model))
            {
                TempData["SaveResult"] = "The Game was Updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Game could not be Updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int gameID)
        {
            var svc = CreateGameService();
            var model = svc.GetGameByID(gameID);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGame(int gameID)
        {
            var service = CreateGameService();
            service.DeleteGame(gameID);
            TempData["SaveResult"] = "The Game was Deleted.";
            return RedirectToAction("Inex");
        }
    }
}