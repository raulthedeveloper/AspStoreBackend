using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AspStoreBackend.Models;

namespace AspStoreBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class LocationController : ApiController
    {
        private StoreContext db = new StoreContext();

        // GET: api/Location
        public IQueryable<LocationModel> Getlocation()
        {
            return db.location;
        }

        // GET: api/Location/5
        [ResponseType(typeof(LocationModel))]
        public IHttpActionResult GetLocationModel(int id)
        {
            LocationModel locationModel = db.location.Find(id);
            if (locationModel == null)
            {
                return NotFound();
            }

            return Ok(locationModel);
        }

        // PUT: api/Location/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLocationModel(int id, LocationModel locationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locationModel.Id)
            {
                return BadRequest();
            }

            db.Entry(locationModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationModelExists(id))
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

        // POST: api/Location
        [ResponseType(typeof(LocationModel))]
        public IHttpActionResult PostLocationModel(LocationModel locationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.location.Add(locationModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = locationModel.Id }, locationModel);
        }

        // DELETE: api/Location/5
        [ResponseType(typeof(LocationModel))]
        public IHttpActionResult DeleteLocationModel(int id)
        {
            LocationModel locationModel = db.location.Find(id);
            if (locationModel == null)
            {
                return NotFound();
            }

            db.location.Remove(locationModel);
            db.SaveChanges();

            return Ok(locationModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocationModelExists(int id)
        {
            return db.location.Count(e => e.Id == id) > 0;
        }
    }
}