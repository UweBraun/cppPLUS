using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace cppPLUS_2407.Models
{
    public class EntityMastersController : Controller
    {
        private cppPLUSEntities db = new cppPLUSEntities();

        // GET: EntityMasters
        public ActionResult Index()
        {
            var entityMasters = db.EntityMasters.Include(e => e.CorporateMaster).Include(e => e.CountryList);
            return View(entityMasters.ToList());
        }

        // GET: EntityMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityMaster entityMaster = db.EntityMasters.Find(id);
            if (entityMaster == null)
            {
                return HttpNotFound();
            }
            return View(entityMaster);
        }

        // GET: EntityMasters/Create
        public ActionResult Create()
        {
            ViewBag.Corporation = new SelectList(db.CorporateMasters, "Corporate_ID", "CorporateShort");
            ViewBag.Country = new SelectList(db.CountryLists, "CountryID", "Country");
            return View();
        }

        // POST: EntityMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntityID,EntityShort,EntityLegalName,Corporation,Location,Country,Comment,UserID,DateModified,DateAdded")] EntityMaster entityMaster)
        {
            if (ModelState.IsValid)
            {
                db.EntityMasters.Add(entityMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Corporation = new SelectList(db.CorporateMasters, "Corporate_ID", "CorporateShort", entityMaster.Corporation);
            ViewBag.Country = new SelectList(db.CountryLists, "CountryID", "Country", entityMaster.Country);
            return View(entityMaster);
        }

        // GET: EntityMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityMaster entityMaster = db.EntityMasters.Find(id);
            if (entityMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.Corporation = new SelectList(db.CorporateMasters, "Corporate_ID", "CorporateShort", entityMaster.Corporation);
            ViewBag.Country = new SelectList(db.CountryLists, "CountryID", "Country", entityMaster.Country);
            return View(entityMaster);
        }

        // POST: EntityMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntityID,EntityShort,EntityLegalName,Corporation,Location,Country,Comment,UserID,DateModified,DateAdded")] EntityMaster entityMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entityMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Corporation = new SelectList(db.CorporateMasters, "Corporate_ID", "CorporateShort", entityMaster.Corporation);
            ViewBag.Country = new SelectList(db.CountryLists, "CountryID", "Country", entityMaster.Country);
            return View(entityMaster);
        }

        // GET: EntityMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityMaster entityMaster = db.EntityMasters.Find(id);
            if (entityMaster == null)
            {
                return HttpNotFound();
            }
            return View(entityMaster);
        }

        // POST: EntityMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntityMaster entityMaster = db.EntityMasters.Find(id);
            db.EntityMasters.Remove(entityMaster);
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
