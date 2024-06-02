using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vezba.Models;

namespace vezba.Controllers
{
    public class DoctorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Doctors
        public ActionResult Index()
        {
            return View(db.Doctors.ToList());
        }
        [Authorize(Roles ="Admin,Editor")]
        public ActionResult AddPatient(int id) {
            AddPatientToDoctorModel model = new AddPatientToDoctorModel();
            model.DoctorId = id;
            var doc = db.Doctors.Find(id);

            // Retrieve the doctor ID
            var doctorId = doc.Id;

            // Use doctorId in the LINQ query
            model.Patients = db.Patients
                .Where(p => !p.Doctors.Select(d => d.Id).Contains(doctorId))
                .ToList();

            return View(model);
        }
        [Authorize(Roles = "Admin,Editor")]
        [HttpPost]
        public ActionResult AddPatient(AddPatientToDoctorModel model)
        {
            var doc = db.Doctors.Find(model.DoctorId);
            var pat = db.Patients.Find(model.PatientId);
            doc.Patients.Add(pat);
            db.SaveChanges();
            return RedirectToAction("Details",new { id = model.DoctorId});
        }
        [Authorize(Roles = "Admin,Editor")]
        public ActionResult DeletePatient(int dId,int pId)
        {
            var doc = db.Doctors.Find(dId);
            var pat = db.Patients.Find(pId);
            doc.Patients.Remove(pat);
            pat.Doctors.Remove(doc);
            db.SaveChanges();
            return RedirectToAction("Details",new { id=dId});
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        // GET: Doctors/Edit/5
        [Authorize(Roles = "Admin,Editor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Editor")]
        public ActionResult Edit([Bind(Include = "Id,Name")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
            db.Patients.ToList().ForEach(p =>
            {
                if (p.Doctors.Contains(doctor)) {
                    p.Doctors.Remove(doctor);
                }
            });
            db.Hospitals.ToList().ForEach(p =>
            {
                if (p.Doctors.Contains(doctor)) {
                    p.Doctors.Remove(doctor);
                }
            });
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
