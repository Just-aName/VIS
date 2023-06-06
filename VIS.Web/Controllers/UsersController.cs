using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VIS.Models.Db;

namespace VIS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private DbEntities db = new DbEntities();

        public ActionResult Index()
        {
            var user = db.User.Include(u => u.User2).Include(u => u.Usersettings);
            return View(user.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Create()
        {
            ViewBag.Trener_ID = new SelectList(db.User, "User_ID", "Email");
            ViewBag.Usersettings_ID = new SelectList(db.Usersettings, "Settings_id", "Settings_id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_ID,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,FirstName,LastName,ExternalLogin,RegistrationGUID,GUIDExpirationDate,TwoFactorEnabled,Trener_ID,Usersettings_ID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Trener_ID = new SelectList(db.User, "User_ID", "Email", user.Trener_ID);
            ViewBag.Usersettings_ID = new SelectList(db.Usersettings, "Settings_id", "Settings_id", user.Usersettings_ID);
            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Trener_ID = new SelectList(db.User, "User_ID", "Email", user.Trener_ID);
            ViewBag.Usersettings_ID = new SelectList(db.Usersettings, "Settings_id", "Settings_id", user.Usersettings_ID);
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_ID,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,FirstName,LastName,ExternalLogin,RegistrationGUID,GUIDExpirationDate,TwoFactorEnabled,Trener_ID,Usersettings_ID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Trener_ID = new SelectList(db.User, "User_ID", "Email", user.Trener_ID);
            ViewBag.Usersettings_ID = new SelectList(db.Usersettings, "Settings_id", "Settings_id", user.Usersettings_ID);
            return View(user);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
