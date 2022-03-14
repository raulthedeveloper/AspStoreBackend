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
    public class CartsController : ApiController
    {
        private StoreContext db = new StoreContext();

        // GET: api/Carts
        public IQueryable<Cart> Getcart()
        {
            return db.cart;
        }

        // GET: api/Carts/5
        [ResponseType(typeof(Cart))]
        public IHttpActionResult GetCart(int id)
        {
            Cart cart = db.cart.Find(id);
            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        // PUT: api/Carts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCart(int id, Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.id)
            {
                return BadRequest();
            }

            db.Entry(cart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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

        // POST: api/Carts
        [ResponseType(typeof(Cart))]
        public IHttpActionResult PostCart(Cart[] cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DateTime date = DateTime.Now;

            Random rnd = new Random();
            int number = rnd.Next(1000000, 3000000);
            string n = date.ToString("yyyyMMddHH");

            foreach (Cart item in cart)
            {
                item.cartId = item.custId + n + number;

                db.cart.Add(item);
                db.SaveChanges();


            }

            return StatusCode(HttpStatusCode.OK);



        }

        // DELETE: api/Carts/5
        [ResponseType(typeof(Cart))]
        public IHttpActionResult DeleteCart(int id)
        {
            Cart cart = db.cart.Find(id);
            if (cart == null)
            {
                return NotFound();
            }

            db.cart.Remove(cart);
            db.SaveChanges();

            return Ok(cart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartExists(int id)
        {
            return db.cart.Count(e => e.id == id) > 0;
        }
    }
}