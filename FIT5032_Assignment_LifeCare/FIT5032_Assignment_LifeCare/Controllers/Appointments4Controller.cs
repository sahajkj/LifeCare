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
    public class Appointments4Controller : Controller
    {
        private LifecareDataModelContainer db = new LifecareDataModelContainer();

        // GET: Appointments4
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.Doctor).Include(a => a.Patient);
            return View(appointments.ToList());
        }

        // GET: Appointments4/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments4/Create
        public ActionResult Create(String date)
        {
            if (null == date)
                return RedirectToAction("Index");
            Appointment m = new Appointment();
            DateTime convertedDate = DateTime.Parse(date);
            m.DateTime = convertedDate;
            return View(m);
        }

        // POST: Appointments4/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateTime,Status,Price,DoctorId,PatientId,Text")] Appointment appointment)
        {
            var appointmentsList = db.Appointments.ToList();
            foreach (Appointment a in appointmentsList)
            {
                if (a.DateTime == appointment.DateTime)
                {
                    TempData["msg"] = "<script>alert('This Booking is unavailable.');</script>";
                    return RedirectToAction("Index");
                }
            }
            if (appointment.DateTime >= DateTime.Today)
            {
                if (ModelState.IsValid)
                {
                    db.Appointments.Add(appointment);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["msg"] = "<script>alert('Can not accept a booking on a day that has passed.');</script>";
                return RedirectToAction("Index");
            }

            return View(appointment);
        }

        // GET: Appointments4/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Speciality", appointment.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Gender", appointment.PatientId);
            return View(appointment);
        }

        // POST: Appointments4/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateTime,Status,Price,DoctorId,PatientId,Text")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Speciality", appointment.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Gender", appointment.PatientId);
            return View(appointment);
        }

        // GET: Appointments4/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments4/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
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
