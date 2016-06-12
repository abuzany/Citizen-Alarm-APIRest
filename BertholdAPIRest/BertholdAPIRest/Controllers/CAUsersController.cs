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

namespace BertholdAPIRest.Controllers
{
    [RoutePrefix("api/causers")]
    public class CAUsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CAUsers
        public IQueryable<CAUser> GetCAUsers()
        {
            return db.CAUsers;
        }

        [Route("facebook/{id}")]
        [ResponseType(typeof(CAUser))]
        public IHttpActionResult GetUserByFacebookId(string id)
        {
            CAUser user = db.CAUsers.Where(x => x.FacebookID == id).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/CAUsers/5
        [ResponseType(typeof(CAUser))]
        public IHttpActionResult GetCAUser(int id)
        {
            CAUser cAUser = db.CAUsers.Find(id);
            if (cAUser == null)
            {
                return NotFound();
            }

            return Ok(cAUser);
        }

        // PUT: api/CAUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCAUser(int id, CAUser cAUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cAUser.Id)
            {
                return BadRequest();
            }

            db.Entry(cAUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAUserExists(id))
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

        // POST: api/CAUsers
        [ResponseType(typeof(CAUser))]
        public IHttpActionResult PostCAUser(CAUser cAUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CAUsers.Add(cAUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cAUser.Id }, cAUser);
        }

        // DELETE: api/CAUsers/5
        [ResponseType(typeof(CAUser))]
        public IHttpActionResult DeleteCAUser(int id)
        {
            CAUser cAUser = db.CAUsers.Find(id);
            if (cAUser == null)
            {
                return NotFound();
            }

            db.CAUsers.Remove(cAUser);
            db.SaveChanges();

            return Ok(cAUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CAUserExists(int id)
        {
            return db.CAUsers.Count(e => e.Id == id) > 0;
        }
    }
}