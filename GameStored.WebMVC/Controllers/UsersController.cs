using GameStoredTwo.Models.User;
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

    public class UsersController : Controller
    {
        private UserService CreateUserService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new UserService(userID);
            return service;
        }

        // GET: Users
        public ActionResult Index()
        {
            var service = CreateUserService();
            var model = service.GetUsers();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // Post : Users
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateUserService();
            if (service.CreateUsers(model))
            {
                TempData["SaveResult"] = "User has been Created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "User could not be Created.");
            return View(model);
        }

        public ActionResult Details(Guid userID)
        {
            var svc = CreateUserService();
            var model = svc.GetUserByID(userID);
            return View(model);
        }

        public ActionResult Edit(Guid userID)
        {
            var service = CreateUserService();
            var detail = service.GetUserByID(userID);
            var model = new UserEdit
            {
                UserID = detail.UserID,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                City = detail.City,
                State = detail.State,
                FavoriteGames = detail.FavoriteGames,
                Wishlists = detail.Wishlists
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateUserService();

            if (service.UpdateUser(model))
            {
                TempData["SaveResult"] = "The User was Updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The User could not be Updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(Guid userID)
        {
            var svc = CreateUserService();
            var model = svc.GetUserByID(userID);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConsole(Guid userID)
        {
            var service = CreateUserService();
            service.DeleteUser(userID);
            TempData["SaveResult"] = "The User was Deleted.";
            return RedirectToAction("Inex");
        }
    }
}