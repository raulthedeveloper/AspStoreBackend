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

    public class HoursController : ApiController
    {
        private StoreContext db = new StoreContext();

        // GET: api/Hours
        public IQueryable<HoursModel> Gethours()
        {
            return db.hours;
        }

        // GET: api/Hours/5
        [ResponseType(typeof(HoursModel))]
        public IHttpActionResult GetHoursModel(int id)
        {
            HoursModel hoursModel = db.hours.Find(id);
            if (hoursModel == null)
            {
                return NotFound();
            }

            return Ok(hoursModel);
        }

        // PUT: api/Hours/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHoursModel(int id, HoursModel hoursModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hoursModel.Id)
            {
                return BadRequest();
            }

            db.Entry(hoursModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoursModelExists(id))
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

        // POST: api/Hours
        [ResponseType(typeof(HoursModel))]
        public IHttpActionResult PostHoursModel(HoursModel hoursModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.hours.Add(hoursModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hoursModel.Id }, hoursModel);
        }

        // DELETE: api/Hours/5
        [ResponseType(typeof(HoursModel))]
        public IHttpActionResult DeleteHoursModel(int id)
        {
            HoursModel hoursModel = db.hours.Find(id);
            if (hoursModel == null)
            {
                return NotFound();
            }

            db.hours.Remove(hoursModel);
            db.SaveChanges();

            return Ok(hoursModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HoursModelExists(int id)
        {
            return db.hours.Count(e => e.Id == id) > 0;
        }
    }
}