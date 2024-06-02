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
    public class HospitalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hospitals
        public ActionResult Index()
        {
            return View(db.Hospitals.ToList());
        }
        public ActionResult AddDoctor(int id)
        {
            AddDoctorToHospitalModel model = new AddDoctorToHospitalModel();
            model.HospitalId = id;
            model.Doctors = db.Doctors.Where(d => d.Hospital == null).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddDoctor(AddDoctorToHospitalModel model)
        {
            var doc = db.Doctors.Find(model.DoctorId);
            var hosp = db.Hospitals.Find(model.HospitalId);
            hosp.Doctors.Add(doc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDoctor(int hId,int dId) {
            var doc = db.Doctors.Find(dId);
            var hosp = db.Hospitals.Find(hId);
            hosp.Doctors.Remove(doc);
            doc.Hospital = null;
            db.SaveChanges();
            return RedirectToAction("Details",new { id=hId});
        }

        // GET: Hospitals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        // GET: Hospitals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hospitals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Img_Url")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                db.Hospitals.Add(hospital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospital);
        }

        // GET: Hospitals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        // POST: Hospitals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Img_Url")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospital);
        }

        // GET: Hospitals/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Hospital hospital = db.Hospitals.Find(id);
        //    if (hospital == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(hospital);
        //}

        //// POST: Hospitals/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Hospital hospital = db.Hospitals.Find(id);
            db.Hospitals.Remove(hospital);
            db.Doctors.ToList().ForEach(c =>
            {
                if (c.Hospital == hospital) {
                    c.Hospital = null;
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
