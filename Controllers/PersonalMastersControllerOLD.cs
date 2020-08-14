using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cppPLUS_2407.Models;

namespace cppPLUS_2407.Controllers
{
    public class PersonalMastersControllerOLD : Controller
    {
        private cppPLUSEntities db = new cppPLUSEntities();

        // GET: PersonalMasters
        public ActionResult Index()
        {
            var personalMasters = db.PersonalMasters.Include(p => p.CountryList);
            return View(personalMasters.ToList());
        }

        // GET: PersonalMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalMaster personalMaster = db.PersonalMasters.Find(id);
            if (personalMaster == null)
            {
                return HttpNotFound();
            }
            return View(personalMaster);
        }

        // GET: PersonalMasters/Create
        public ActionResult Create()
        {
            ViewBag.Nationality = new SelectList(db.CountryLists, "CountryID", "Country");
            return View();
        }

        // POST: PersonalMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,ASPID,RoleID,UserStatus,UserBackground,UserVerification,FirstName,MiddleName,LastName,ShortName,SystemName,Nationality,PostalCode,Street,City,MobilePhone,Email,Linkedin,Xing,Hyperlink1,ProfilePic,UserCmntPub,UserCmntHid,UserID_AddMod,DateModified,DateAdded")] PersonalMaster personalMaster)
        {
            if (ModelState.IsValid)
            {
                db.PersonalMasters.Add(personalMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Nationality = new SelectList(db.CountryLists, "CountryID", "Country", personalMaster.Nationality);
            return View(personalMaster);
        }

        // GET: PersonalMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalMaster personalMaster = db.PersonalMasters.Find(id);
            if (personalMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nationality = new SelectList(db.CountryLists, "CountryID", "Country", personalMaster.Nationality);
            return View(personalMaster);
        }

        // POST: PersonalMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,ASPID,RoleID,UserStatus,UserBackground,UserVerification,FirstName,MiddleName,LastName,ShortName,SystemName,Nationality,PostalCode,Street,City,MobilePhone,Email,Linkedin,Xing,Hyperlink1,ProfilePic,UserCmntPub,UserCmntHid,UserID_AddMod,DateModified,DateAdded")] PersonalMaster personalMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Nationality = new SelectList(db.CountryLists, "CountryID", "Country", personalMaster.Nationality);
            return View(personalMaster);
        }

        // GET: PersonalMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalMaster personalMaster = db.PersonalMasters.Find(id);
            if (personalMaster == null)
            {
                return HttpNotFound();
            }
            return View(personalMaster);
        }

        // POST: PersonalMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalMaster personalMaster = db.PersonalMasters.Find(id);
            db.PersonalMasters.Remove(personalMaster);
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
