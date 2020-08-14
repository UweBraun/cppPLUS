using cppPLUS_2407.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using cppPLUS_2407.Code;

namespace cppPLUS_2407.Views
{
    public class ViewModel
    {
        public PersonalMaster personalmaster { get; set; }
        public AspNetUser aspnetuser { get; set; }
     
}

public class PersonalMastersController : Controller
    {
        private cppPLUSEntities db = new cppPLUSEntities();


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


        public string GetEmailIdentity()
        {
            try
            {
                string useId = User.Identity.GetUserId().ToString();
                var query = db.AspNetUsers.Where(m => m.Id == useId).SingleOrDefault();

                if (query != null)
                {
                    return query.Email;
                }
                else
                {
                    return "User not found";
                }
            }
            catch (Exception e)
            {
                return "Exception: Retrieve ASP_Email" + e.ToString();
            }
        }

        public ActionResult ASPV()
        {
            return View(db.AspNetUsers.ToList());
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonalMasterCreateViewModel viewmodel)
            //([Bind(Include = "UserID,ASPID,RoleID,UserStatus,UserBackground,UserVerification,FirstName,MiddleName,LastName,ShortName,SystemName,Nationality,PostalCode,Street,City,MobilePhone,Email,Linkedin,Xing,Hyperlink1,ProfilePic,UserCmntPub,UserCmntHid,UserID_AddMod,DateModified,DateAdded,AddAddressFld")] PersonalMaster personalMaster)
        {
         
            if (ModelState.IsValid)
            {
                PersonalMaster model = new PersonalMaster();
               
                model.ASPID = User.Identity.GetUserId();
                model.RoleID = 1;
                model.UserStatus = "A";
                model.UserBackground = "Gen";
                model.UserVerification = 0;
                model.FirstName = viewmodel.FirstName;
                model.MiddleName = viewmodel.MiddleName;
                model.LastName = viewmodel.LastName;
                model.ShortName = viewmodel.ShortName;
                model.SystemName = "NA";
                model.Nationality = viewmodel.Nationality;
                model.PostalCode = viewmodel.PostalCode;
                model.Street = viewmodel.Street;
                model.AddAddressFld = viewmodel.AddAddressFld;
                model.City = viewmodel.City;
                model.MobilePhone = viewmodel.MobilePhone;
                model.Email = GetEmailIdentity();
                model.Linkedin = viewmodel.Linkedin;
                model.Xing = viewmodel.Xing;
                model.Hyperlink1 = viewmodel.Hyperlink1;
                //model.ProfilePic
                model.UserCmntPub = viewmodel.UserCmntPub;
                //model.UserCmntHid
                model.UserID_AddMod = User.Identity.GetAppUserId();
                //model.DateModified
                model.DateAdded = DateTime.Now;
                model.ClientID = 1;

                db.PersonalMasters.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Nationality = new SelectList(db.CountryLists, "CountryID", "Country", viewmodel.Nationality);
            return View(viewmodel);
        }

        // GET: PersonalMasters/Edit/5
        //public ActionResult Edit(PersonalMasterEditViewModel viewmodel, int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PersonalMaster personalMaster = db.PersonalMasters.Find(id);
        //    if (personalMaster == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Nationality = new SelectList(db.CountryLists, "CountryID", "Country", personalMaster.Nationality);
        //    ViewBag.ClientID = new SelectList(db.ClientMasters, "ClientID", "ClientName", personalMaster.ClientID);
        //    return View(viewmodel);
        //}

        // POST: PersonalMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(PersonalMasterEditViewModel viewmodel)
        //[Bind(Include = "UserID,ASPID,RoleID,UserStatus,UserBackground,UserVerification,FirstName,MiddleName,LastName,ShortName,SystemName,Nationality,PostalCode,Street,City,MobilePhone,Email,Linkedin,Xing,Hyperlink1,ProfilePic,UserCmntPub,UserCmntHid,UserID_AddMod,DateModified,DateAdded,AddAddressFld,ClientID")] PersonalMaster personalMaster)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            if (ModelState.IsValid)
            {

                PersonalMaster personalMaster = db.PersonalMasters.SingleOrDefault(c => c.UserID == viewmodel.UserID);
                if (personalMaster == null)
                {
                    return HttpNotFound();
                }

                personalMaster.ASPID = viewmodel.ASPID;
                personalMaster.RoleID = viewmodel.RoleID;
                personalMaster.UserStatus = viewmodel.UserStatus;
                personalMaster.UserBackground = viewmodel.UserBackground;
                personalMaster.UserVerification = viewmodel.UserVerification;
                personalMaster.FirstName = viewmodel.FirstName;
                personalMaster.MiddleName = viewmodel.MiddleName;
                personalMaster.LastName = viewmodel.LastName;
                personalMaster.ShortName = viewmodel.ShortName;
                personalMaster.SystemName = viewmodel.SystemName;
                personalMaster.Nationality = viewmodel.Nationality;
                personalMaster.PostalCode = viewmodel.PostalCode;
                personalMaster.Street = viewmodel.Street;
                personalMaster.AddAddressFld = viewmodel.AddAddressFld;
                personalMaster.City = viewmodel.City;
                personalMaster.MobilePhone = viewmodel.MobilePhone;
                personalMaster.Email = viewmodel.Email;
                personalMaster.Linkedin = viewmodel.Linkedin;
                personalMaster.Xing = viewmodel.Xing;
                personalMaster.Hyperlink1 = viewmodel.Hyperlink1;
                //model.ProfilePic
                personalMaster.UserCmntPub = viewmodel.UserCmntPub;
                personalMaster.UserCmntHid = viewmodel.UserCmntHid;
                personalMaster.UserID_AddMod = User.Identity.GetAppUserId();
                personalMaster.DateModified = DateTime.Now;
                personalMaster.DateAdded = viewmodel.DateAdded;
                personalMaster.ClientID = viewmodel.ClientID;

                db.Entry(personalMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            { 
            ViewBag.Nationality = new SelectList(db.CountryLists, "CountryID", "Country", viewmodel.Nationality);
            ViewBag.ClientID = new SelectList(db.ClientMasters, "ClientID", "ClientName", viewmodel.ClientID);
        }
            return View(viewmodel);

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
