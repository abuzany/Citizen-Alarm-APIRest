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
    public class CAUsersViewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CAUsersViews
        public ActionResult Index()
        {
            return View(db.CAUsers.ToList());
        }

        // GET: CAUsersViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAUser cAUser = db.CAUsers.Find(id);
            if (cAUser == null)
            {
                return HttpNotFound();
            }
            return View(cAUser);
        }

        // GET: CAUsersViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CAUsersViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FacebookID,Alias,Email,CreationDate")] CAUser cAUser)
        {
            if (ModelState.IsValid)
            {
                db.CAUsers.Add(cAUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cAUser);
        }

        // GET: CAUsersViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAUser cAUser = db.CAUsers.Find(id);
            if (cAUser == null)
            {
                return HttpNotFound();
            }
            return View(cAUser);
        }

        // POST: CAUsersViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FacebookID,Alias,Email,CreationDate")] CAUser cAUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cAUser);
        }

        // GET: CAUsersViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAUser cAUser = db.CAUsers.Find(id);
            if (cAUser == null)
            {
                return HttpNotFound();
            }
            return View(cAUser);
        }

        // POST: CAUsersViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CAUser cAUser = db.CAUsers.Find(id);
            db.CAUsers.Remove(cAUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: CAUsersViews/Dummy
        public ActionResult Dummy()
        {
            return View();
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
