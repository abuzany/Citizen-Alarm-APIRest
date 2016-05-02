using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Cors;
using IRAPIREST.Models;

namespace IRAPIREST.Controllers
{
    [EnableCors(origins: "http://localhost:61660", headers: "*", methods: "*")]
    [RoutePrefix("api/alerts2")]
    public class AlertsViewController : Controller
    {
        private IRAPIRESTContext db = new IRAPIRESTContext();

        // GET: AlertsView
        public async Task<ActionResult> Index()
        {
            return View(await db.Alerts.ToListAsync());
        }

        // GET: AlertsView/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alert alert = await db.Alerts.FindAsync(id);
            if (alert == null)
            {
                return HttpNotFound();
            }
            return View(alert);
        }

        // GET: AlertsView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlertsView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserId,AlertType,CreationDate,Description,Latitude,Longitude")] Alert alert)
        {
            if (ModelState.IsValid)
            {
                db.Alerts.Add(alert);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(alert);
        }

        // GET: AlertsView/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alert alert = await db.Alerts.FindAsync(id);
            if (alert == null)
            {
                return HttpNotFound();
            }
            return View(alert);
        }

        // POST: AlertsView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserId,AlertType,CreationDate,Description,Latitude,Longitude")] Alert alert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alert).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(alert);
        }

        // GET: AlertsView/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alert alert = await db.Alerts.FindAsync(id);
            if (alert == null)
            {
                return HttpNotFound();
            }
            return View(alert);
        }

        // POST: AlertsView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Alert alert = await db.Alerts.FindAsync(id);
            db.Alerts.Remove(alert);
            await db.SaveChangesAsync();
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
