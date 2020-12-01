using GameStoredTwo.Models.Game;
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
    public class GamesController : Controller
    {
        private GameService CreateGameService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userID);
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

        public ActionResult Details(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameByID(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGameService();
            var detail = service.GetGameByID(id);
            var model = new GameEdit
            {
                GameTitle = detail.GameTitle,
                Description = detail.Description,
                ReleaseDate = detail.ReleaseDate,
                ConsoleID = detail.ConsoleID,
                DeveloperID = detail.DeveloperID,
                PublisherID = detail.PublisherID,
                AddToFavoriteGames = detail.AddToFavoriteGames,
                AddToWishlist = detail.AddToWishlist
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GameID != id)
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
        public ActionResult Delete(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameByID(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGame(int id)
        {
            var service = CreateGameService();
            service.DeleteGame(id);
            TempData["SaveResult"] = "The Game was Deleted.";

            return RedirectToAction("Inex");
        }
    }
}