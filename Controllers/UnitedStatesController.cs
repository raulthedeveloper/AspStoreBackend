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
using AspStoreBackend.Models;

namespace AspStoreBackend.Controllers
{
    public class UnitedStatesController : ApiController
    {
        private StoreContext db = new StoreContext();

        // GET: api/UnitedStates
        public IQueryable<UnitedStates> GetUnitedStates()
        {
            return db.UnitedStates;
        }

        // GET: api/UnitedStates/5
        [ResponseType(typeof(UnitedStates))]
        public IHttpActionResult GetUnitedStates(int id)
        {
            UnitedStates unitedStates = db.UnitedStates.Find(id);
            if (unitedStates == null)
            {
                return NotFound();
            }

            return Ok(unitedStates);
        }

        // PUT: api/UnitedStates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUnitedStates(int id, UnitedStates unitedStates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unitedStates.Id)
            {
                return BadRequest();
            }

            db.Entry(unitedStates).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitedStatesExists(id))
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

        // POST: api/UnitedStates
        [ResponseType(typeof(UnitedStates))]
        public IHttpActionResult PostUnitedStates(UnitedStates unitedStates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UnitedStates.Add(unitedStates);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = unitedStates.Id }, unitedStates);
        }

        // DELETE: api/UnitedStates/5
        [ResponseType(typeof(UnitedStates))]
        public IHttpActionResult DeleteUnitedStates(int id)
        {
            UnitedStates unitedStates = db.UnitedStates.Find(id);
            if (unitedStates == null)
            {
                return NotFound();
            }

            db.UnitedStates.Remove(unitedStates);
            db.SaveChanges();

            return Ok(unitedStates);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnitedStatesExists(int id)
        {
            return db.UnitedStates.Count(e => e.Id == id) > 0;
        }
    }
}