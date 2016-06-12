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
using BertholdAPIRest.Models;
using BertholdAPIRest.Framework;
using System.Data.Entity.Core.Objects;
using System.Xml;
using System.IO;
using GoogleMapsGeocoding;
using GoogleMapsGeocoding.Common;

namespace BertholdAPIRest.Controllers
{
    [RoutePrefix("api/alerts")]
    public class AlertsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Alerts
        public IQueryable<Alert> GetAlerts()
        {
            return db.Alerts;
        }

        [Route("today")]
        public List<Alert> GetTodayAlerts()
        {
            var alerts = db.Alerts.ToList();

            var newAlerts = new List<Alert>();

            foreach (var alert in alerts)
            {
                int res = DateTime.Compare(alert.CreationDate.Date, DateTime.Now.Date);

                if (res == 0)
                    newAlerts.Add(alert);

            }

            return newAlerts;
        }

        [Route("user/{id}")]
        public IQueryable<Alert> GetUserAlerts(string id)
        {
            var alerts = db.Alerts.Where(x => x.UserId == id);

            return alerts;
        }

        [Route("user/{id}/today")]
        public List<Alert> GetTodayUserAlerts(string id)
        {
            var alerts = db.Alerts.Where(x => x.UserId == id).ToList();

            var newAlerts = new List<Alert>();

            foreach (var alert in alerts)
            {
                int res = DateTime.Compare(alert.CreationDate.Date, DateTime.Now.Date);

                if (res == 0)
                    newAlerts.Add(alert);

            }

            return newAlerts;
        }

        [Route("user/{id}/week")]
        public List<Alert> GetWeekUserAlerts(string id)
        {
            var firstdayOfThisWeek = DateTime.Now.FirstDayOfWeek();
            var lastdayOfThisWeek = DateTime.Now.LastDayOfWeek();

            var alerts = db.Alerts.Where(x =>x.UserId == id).ToList();

            var newAlerts = new List<Alert>();

            foreach (var alert in alerts)
            {
                if (!((alert.CreationDate.Date >= firstdayOfThisWeek.Date)&&(alert.CreationDate.Date <= lastdayOfThisWeek.Date)))
                    newAlerts.Add(alert);
            }

            return newAlerts;
        }

        [Route("user/{id}/month")]
        public List<Alert> GetMonthUserAlerts(string id)
        {
            var firstdayOfThisMonth = DateTime.Now.FirstDayOfMonth();
            var lastdayOfThisMonth = DateTime.Now.LastDayOfMonth();

            var alerts = db.Alerts.Where(x => x.UserId == id).ToList();

            var newAlerts = new List<Alert>();

            foreach (var alert in alerts)
            {
                if (!((alert.CreationDate.Date >= firstdayOfThisMonth.Date) && (alert.CreationDate.Date <= lastdayOfThisMonth.Date)))
                    newAlerts.Add(alert);
            }

            return newAlerts;
        }

        // GET: api/Alerts/5
        [ResponseType(typeof(Alert))]
        public IHttpActionResult GetAlert(int id)
        {
            Alert alert = db.Alerts.Find(id);
            if (alert == null)
            {
                return NotFound();
            }

            return Ok(alert);
        }

        // PUT: api/Alerts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlert(int id, Alert alert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alert.Id)
            {
                return BadRequest();
            }

            db.Entry(alert).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertExists(id))
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

        // POST: api/Alerts
        [ResponseType(typeof(Alert))]
        public IHttpActionResult PostAlert(Alert alert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Create new Geocoder and pass GOOGLE_MAPS_API_KEY(in this example it's stored in .config)
            IGeocoder geocoder = new Geocoder("AIzaSyCyrwDBZYm83nLY6Eg8_ECHRCF-aNQ91eQ");

            // Get GeocodeResponse C# object from address or from Latitude Longitude(reverse geocoding) 
            GeocodeResponse reversGeocoderesponse = geocoder.ReverseGeocode(alert.Latitude, alert.Longitude);

            // You can then query the response to get what you need
            string address = reversGeocoderesponse.Results[1].FormattedAddress;

            alert.Address = address;

            db.Alerts.Add(alert);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = alert.Id }, alert);
        }

        // DELETE: api/Alerts/5
        [ResponseType(typeof(Alert))]
        public IHttpActionResult DeleteAlert(int id)
        {
            Alert alert = db.Alerts.Find(id);
            if (alert == null)
            {
                return NotFound();
            }

            db.Alerts.Remove(alert);
            db.SaveChanges();

            return Ok(alert);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlertExists(int id)
        {
            return db.Alerts.Count(e => e.Id == id) > 0;
        }
    }
}