using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using src.Models;

namespace src.Controllers
{
    public class TestBookingsController : Controller
    {
        private LifecareDataModelContainer db = new LifecareDataModelContainer();

        // GET: TestBookings
        public ActionResult Index()
        {
            var testBookings = db.TestBookings.Include(t => t.Patient).Include(t => t.Test);
            return View(testBookings.ToList());
        }

        // GET: TestBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestBooking testBooking = db.TestBookings.Find(id);
            if (testBooking == null)
            {
                return HttpNotFound();
            }
            return View(testBooking);
        }

        // GET: TestBookings/Create
        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Gender");
            ViewBag.TestId = new SelectList(db.Tests, "Id", "Name");
            return View();
        }

        // POST: TestBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateTime,Status,PatientId,TestId")] TestBooking testBooking)
        {
            if (ModelState.IsValid)
            {
                db.TestBookings.Add(testBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Gender", testBooking.PatientId);
            ViewBag.TestId = new SelectList(db.Tests, "Id", "Name", testBooking.TestId);
            return View(testBooking);
        }

        // GET: TestBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestBooking testBooking = db.TestBookings.Find(id);
            if (testBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Gender", testBooking.PatientId);
            ViewBag.TestId = new SelectList(db.Tests, "Id", "Name", testBooking.TestId);
            return View(testBooking);
        }

        // POST: TestBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateTime,Status,PatientId,TestId")] TestBooking testBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Gender", testBooking.PatientId);
            ViewBag.TestId = new SelectList(db.Tests, "Id", "Name", testBooking.TestId);
            return View(testBooking);
        }

        // GET: TestBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestBooking testBooking = db.TestBookings.Find(id);
            if (testBooking == null)
            {
                return HttpNotFound();
            }
            return View(testBooking);
        }

        // POST: TestBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestBooking testBooking = db.TestBookings.Find(id);
            db.TestBookings.Remove(testBooking);
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
