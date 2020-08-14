using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using cppPLUS_2407.Code;

namespace cppPLUS_2407.Models
{
    public class StatusList
    {
        public static List<SelectListItem> ClientStatus = new List<SelectListItem>()
            {
            new SelectListItem() {Text = "Active", Value = "A" },
            new SelectListItem() {Text = "Locked", Value = "L" },
            new SelectListItem() {Text = "Inactive", Value = "I" },
            new SelectListItem() {Text = "Remove", Value = "Z" },
            };
    }

    public class ClientMastersController : Controller
    {
        private cppPLUSEntities db = new cppPLUSEntities();

        // GET: ClientMasters
        public ActionResult Index()
        {
         return View(db.ClientMasters.ToList());
        }

        // GET: ClientMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientMaster clientMaster = db.ClientMasters.Find(id);
            if (clientMaster == null)
            {
                return HttpNotFound();
            }
            return View(clientMaster);
        }

        // GET: ClientMasters/Create
        public ActionResult Create()
        {
            ViewBag.ClientStatusList = StatusList.ClientStatus;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientMasterEditModel viewModel)
           
        {
            if (ModelState.IsValid)
            {
                ClientMaster model = new ClientMaster();

                //ViewBag.ClientStatusList = StatusList.ClientStatus;

                model.ClientID = viewModel.ClientID;
                model.ClientName = viewModel.ClientName;
                model.ClientDescr = viewModel.ClientDescr;
                model.ClientStatus = viewModel.ClientStatus;
                model.UserMod = User.Identity.GetAppUserId();
                model.DateModified = DateTime.Now;
                model.DateAdded = viewModel.DateAdded;

                db.ClientMasters.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: ClientMasters/Edit/5
        public ActionResult Edit(int? id)
        {                      
            ViewBag.ClientStatusList = StatusList.ClientStatus;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientMaster clientMaster = db.ClientMasters.Find(id);
            if (clientMaster == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ClientMasterEditModel
            {
            ClientID = clientMaster.ClientID,
            ClientName = clientMaster.ClientName,
            ClientDescr = clientMaster.ClientDescr,
            ClientStatus = clientMaster.ClientStatus,
            UserMod = clientMaster.UserMod,
            DateModified = clientMaster.DateModified,
            DateAdded = clientMaster.DateAdded,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientMasterEditModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ClientMaster model = new ClientMaster();

                model.ClientID = viewModel.ClientID;
                model.ClientName = viewModel.ClientName;
                model.ClientDescr = viewModel.ClientDescr;
                model.ClientStatus = viewModel.ClientStatus;
                model.UserMod = User.Identity.GetAppUserId();
                model.DateModified = DateTime.Now;
                model.DateAdded = viewModel.DateAdded;

                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: ClientMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientMaster clientMaster = db.ClientMasters.Find(id);
            if (clientMaster == null)
            {
                return HttpNotFound();
            }
            return View(clientMaster);
        }

        // POST: ClientMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientMaster clientMaster = db.ClientMasters.Find(id);
            db.ClientMasters.Remove(clientMaster);
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
