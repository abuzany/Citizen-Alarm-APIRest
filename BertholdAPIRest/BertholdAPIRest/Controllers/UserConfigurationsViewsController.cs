using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BertholdAPIRest.Models;

namespace BertholdAPIRest.Controllers
{
    public class UserConfigurationsViewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserConfigurationsViews
        public ActionResult Index()
        {
            return View(db.UserConfigurations.ToList());
        }

        // GET: UserConfigurationsViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserConfiguration userConfiguration = db.UserConfigurations.Find(id);
            if (userConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(userConfiguration);
        }

        // GET: UserConfigurationsViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserConfigurationsViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FacebookID,Range,EnabledNotifications")] UserConfiguration userConfiguration)
        {
            if (ModelState.IsValid)
            {
                db.UserConfigurations.Add(userConfiguration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userConfiguration);
        }

        // GET: UserConfigurationsViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserConfiguration userConfiguration = db.UserConfigurations.Find(id);
            if (userConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(userConfiguration);
        }

        // POST: UserConfigurationsViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FacebookID,Range,EnabledNotifications")] UserConfiguration userConfiguration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userConfiguration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userConfiguration);
        }

        // GET: UserConfigurationsViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserConfiguration userConfiguration = db.UserConfigurations.Find(id);
            if (userConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(userConfiguration);
        }

        // POST: UserConfigurationsViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserConfiguration userConfiguration = db.UserConfigurations.Find(id);
            db.UserConfigurations.Remove(userConfiguration);
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
