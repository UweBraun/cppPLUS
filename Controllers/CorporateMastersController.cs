using cppPLUS_2407.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace cppPLUS_2407.Controllers
{
    public class CorporateMastersController : Controller
    {
        private cppPLUSEntities db = new cppPLUSEntities();

        // GET: CorporateMasters
        [Authorize(Roles = "Admin")]
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

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CorporateMasterViewModel viewmodel)
        //[Bind(Include = "Corporate_ID,CorporateShort,CorporateEntityName,C_Country,C_Location,UserUpdate,DateAdded")] CorporateMaster corporateMaster )
        {
            if (ModelState.IsValid)
            {
                CorporateMaster model = new CorporateMaster();
                model.CorporateEntityName = viewmodel.CorporateEntityName;
                model.CorporateShort = viewmodel.CorporateShort;
                model.C_Location = viewmodel.C_Location;
                model.C_Country = viewmodel.C_Country;
                model.DateAdded = DateTime.Now;
                model.UserID = User.Identity.GetUserId();

                db.CorporateMasters.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.C_Country = new SelectList(db.CountryLists, "CountryID", "Country", viewmodel.C_Country);
            return View(viewmodel);
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

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Corporate_ID,CorporateShort,CorporateEntityName,C_Country,C_Location,UserID,DateModified,DateAdded")] CorporateMaster corporateMaster)
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
