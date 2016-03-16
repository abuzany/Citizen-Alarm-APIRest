using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using IRAPIREST.Models;

namespace IRAPIREST.Controllers
{
    public class AlertTypesController : ApiController
    {
        private IRAPIRESTContext db = new IRAPIRESTContext();

        // GET: api/AlertTypes
        public IQueryable<AlertType> GetAlertTypes()
        {
            return db.AlertTypes;
        }

        // GET: api/AlertTypes/5
        [ResponseType(typeof(AlertType))]
        public IHttpActionResult GetAlertType(int id)
        {
            AlertType alertType = db.AlertTypes.Find(id);
            if (alertType == null)
            {
                return NotFound();
            }

            return Ok(alertType);
        }

        // PUT: api/AlertTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlertType(int id, AlertType alertType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alertType.AlertTypeID)
            {
                return BadRequest();
            }

            db.Entry(alertType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AlertTypes
        [ResponseType(typeof(AlertType))]
        public IHttpActionResult PostAlertType(AlertType alertType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AlertTypes.Add(alertType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = alertType.AlertTypeID }, alertType);
        }

        // DELETE: api/AlertTypes/5
        [ResponseType(typeof(AlertType))]
        public IHttpActionResult DeleteAlertType(int id)
        {
            AlertType alertType = db.AlertTypes.Find(id);
            if (alertType == null)
            {
                return NotFound();
            }

            db.AlertTypes.Remove(alertType);
            db.SaveChanges();

            return Ok(alertType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlertTypeExists(int id)
        {
            return db.AlertTypes.Count(e => e.AlertTypeID == id) > 0;
        }
    }
}