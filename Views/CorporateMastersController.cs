using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cppPLUS_2407.Models;

namespace cppPLUS_2407.Views
{
    public class CorporateMastersController : Controller
    {
        private cppPLUSEntities db = new cppPLUSEntities();

        // GET: CorporateMasters
        public ActionResult Index()
        {
            var corporateMasters = db.CorporateMasters.Include(c => c.CountryList);
            return View(corporateMasters.ToList());
        }

        // GET: CorporateMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CorporateMaster corporateMaster = db.CorporateMasters.Find(id);
            if (corporateMaster == null)
            {
                return HttpNotFound();
            }
            return View(corporateMaster);
        }

        // GET: CorporateMasters/Create
        public ActionResult Create()
        {
            ViewBag.C_Country = new SelectList(db.CountryLists, "CountryID", "Country");
            return View();
        }

        // POST: CorporateMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Corporate_ID,CorporateShort,CorporateEntityName,C_Country,C_Location,UserUpdate,DateModified,DateAdded")] CorporateMaster corporateMaster)
        {
            if (ModelState.IsValid)
            {
                db.CorporateMasters.Add(corporateMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.C_Country = new SelectList(db.CountryLists, "CountryID", "Country", corporateMaster.C_Country);
            return View(corporateMaster);
        }

        // GET: CorporateMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CorporateMaster corporateMaster = db.CorporateMasters.Find(id);
            if (corporateMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.C_Country = new SelectList(db.CountryLists, "CountryID", "Country", corporateMaster.C_Country);
            return View(corporateMaster);
        }

        // POST: CorporateMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Corporate_ID,CorporateShort,CorporateEntityName,C_Country,C_Location,UserUpdate,DateModified,DateAdded")] CorporateMaster corporateMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(corporateMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.C_Country = new SelectList(db.CountryLists, "CountryID", "Country", corporateMaster.C_Country);
            return View(corporateMaster);
        }

        // GET: CorporateMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CorporateMaster corporateMaster = db.CorporateMasters.Find(id);
            if (corporateMaster == null)
            {
                return HttpNotFound();
            }
            return View(corporateMaster);
        }

        // POST: CorporateMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CorporateMaster corporateMaster = db.CorporateMasters.Find(id);
            db.CorporateMasters.Remove(corporateMaster);
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
