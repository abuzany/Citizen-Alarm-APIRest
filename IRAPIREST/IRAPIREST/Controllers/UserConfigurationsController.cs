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
    [RoutePrefix("api/userconfigurations")]
    public class UserConfigurationsController : ApiController
    {
        private IRAPIRESTContext db = new IRAPIRESTContext();

        // GET: api/UserConfigurations
        public IQueryable<UserConfiguration> GetUserConfigurations()
        {
            return db.UserConfigurations;
        }

        // GET: api/UserConfigurations/5
        [ResponseType(typeof(UserConfiguration))]
        public IHttpActionResult GetUserConfiguration(int id)
        {
            UserConfiguration userConfiguration = db.UserConfigurations.Find(id);
            if (userConfiguration == null)
            {
                return NotFound();
            }

            return Ok(userConfiguration);
        }

        [Route("facebook/{id}")]
        [ResponseType(typeof(UserConfiguration))]
        public IHttpActionResult GetUserByFacebookId(string id)
        {
            UserConfiguration userConfiguration = db.UserConfigurations.Where(x=> x.FacebookID == id).FirstOrDefault();
            if (userConfiguration == null)
            {
                return NotFound();
            }

            return Ok(userConfiguration);
        }

        // PUT: api/UserConfigurations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserConfiguration(int id, UserConfiguration userConfiguration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userConfiguration.Id)
            {
                return BadRequest();
            }   

            db.Entry(userConfiguration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserConfigurationExists(id))
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

        // POST: api/UserConfigurations
        [ResponseType(typeof(UserConfiguration))]
        public IHttpActionResult PostUserConfiguration(UserConfiguration userConfiguration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserConfigurations.Add(userConfiguration);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userConfiguration.Id }, userConfiguration);
        }

        // DELETE: api/UserConfigurations/5
        [ResponseType(typeof(UserConfiguration))]
        public IHttpActionResult DeleteUserConfiguration(int id)
        {
            UserConfiguration userConfiguration = db.UserConfigurations.Find(id);
            if (userConfiguration == null)
            {
                return NotFound();
            }

            db.UserConfigurations.Remove(userConfiguration);
            db.SaveChanges();

            return Ok(userConfiguration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserConfigurationExists(int id)
        {
            return db.UserConfigurations.Count(e => e.Id == id) > 0;
        }
    }
}