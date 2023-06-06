using ATC.LunchSystem.IServices;
using ATC.LunchSystem.Models;
using ATC.LunchSystem.Web.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATC.LunchSystem.Web.Controllers
{
    [Authorize(Roles = Constants.ElevatedRole)]
    public class UserDetailController : Controller
    {
        private IUsersService UsersService { get; set; }

        public UserDetailController()
        {
            UsersService = ServiceConfig.Get<IUsersService>();
        }

        public ActionResult Index(int? userID)
        {
            if ((userID ?? null) == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var user = UsersService.GetUserById(userID ?? 0);
            var cards = UsersService.GetUserCards(userID ?? 0);
            var role = UsersService.GetUserRole(userID ?? 0);
            
            return View(new UserDetailViewModel(user, cards, role));
        }

        public ActionResult Edit(int? id)
        {
            if ((id ?? null) == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var user = UsersService.GetUserById(id ?? 0);
            var cards = UsersService.GetUserCards(id ?? 0);
            var role = UsersService.GetUserRole(id ?? 0);
            return View(new UserDetailViewModel(user, cards, role));
        }

        [HttpPost]
        public ActionResult Edit(UserDetailViewModel model)
        {
            UsersService.EditUser(model);
            return RedirectToAction("Index", new { userID = model.UserID });
        }

        public void RemoveCard(int? cardID, int? userID)
        {
            if(cardID == null || userID == null)
            {
                return;
            }
            UsersService.RemoveCard(userID ?? 0, cardID ?? 0);
            UsersService.UnitOfWork.Save();
        }

        public void AddCard(int? cardID, int? userID)
        {
            if (cardID == null || userID == null)
            {
                return;
            }
            UsersService.AddCard(userID ?? 0, cardID ?? 0);
            UsersService.UnitOfWork.Save();
        }
    }
}