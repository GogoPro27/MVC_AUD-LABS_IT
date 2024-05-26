using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LAB_3_onceMore.Models;
using LAB_3_onceMore.Models.HospitalModels;

namespace LAB_3_onceMore.Controllers.HospitalControllers
{
    public class DoctorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Doctors
        public ActionResult Index()
        {
            return View(db.Doctors.ToList());
        }
        public ActionResult AddPatient(int id) {
            PatientToDoctor model = new PatientToDoctor();
            model.DoctorId = id;
            model.Patients = db.Patients.ToList();
            ViewBag.DoctorName = db.Doctors.Find(id).Name;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddPatient(PatientToDoctor model)
        {
            var doc = db.Doctors.Find(model.DoctorId);
            var patient = db.Patients.Find(model.SelectedPatientId);
            doc.Patients.Add(patient);
            db.SaveChanges();
            return View("Details",db.Doctors.Find(model.DoctorId));
        }
        public ActionResult AddHospitalToDoctor(int id) {
            HospitalToDoctorModel hospitalToDoctorModel = new HospitalToDoctorModel();
            hospitalToDoctorModel.DoctorId = id;
            hospitalToDoctorModel.Hospitals = db.Hospitals.ToList();
            ViewBag.DoctorName = db.Doctors.Find(id).Name;
            return View(hospitalToDoctorModel);
        }
        [HttpPost]
        public ActionResult AddHospitalToDoctor(HospitalToDoctorModel model)
        {
            var doc = db.Doctors.Find(model.DoctorId);
            var hosp = db.Hospitals.Find(model.ChosenHospitalId);

            doc.Hospital = hosp;
            db.SaveChanges();

            return RedirectToAction("Index");
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
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
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
