using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using src.Models;

namespace src.Controllers
{
    public class AppRatingsController : Controller
    {
        private LifecareDataModelContainer db = new LifecareDataModelContainer();

        // GET: AppRatings
        public ActionResult Index()
        {
            return View(db.AppRatings.ToList());
        }

        // GET: AppRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppRating appRating = db.AppRatings.Find(id);
            if (appRating == null)
            {
                return HttpNotFound();
            }
            return View(appRating);
        }

        // GET: AppRatings/Create
        public ActionResult Create()
        {
            string user_id = User.Identity.GetUserId();
            var currentUser = db.AppRatings.Where(e => e.UserId == user_id);
            if (currentUser.Any())
            {
                TempData["msg"] = "<script>alert('You have already provided your rating.');</script>";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // POST: AppRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Comments,StarNo")] AppRating appRating)
        {
            appRating.UserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(appRating);
            if (ModelState.IsValid)
            {
                db.AppRatings.Add(appRating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appRating);
        }

        // GET: AppRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppRating appRating = db.AppRatings.Find(id);
            if (appRating == null)
            {
                return HttpNotFound();
            }
            return View(appRating);
        }

        // POST: AppRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Name,Comments,StarNo")] AppRating appRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appRating);
        }

        // GET: AppRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppRating appRating = db.AppRatings.Find(id);
            if (appRating == null)
            {
                return HttpNotFound();
            }
            return View(appRating);
        }

        // POST: AppRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppRating appRating = db.AppRatings.Find(id);
            db.AppRatings.Remove(appRating);
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
