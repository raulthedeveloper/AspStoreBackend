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

    public class SalesController : ApiController
    {

        private StoreContext db = new StoreContext();

        // GET: api/Sales
        public IQueryable<Sales> Getsales()
        {
            return db.sales.Include(e => e.product);
        }

        // GET: api/Sales/5
        [ResponseType(typeof(Sales))]
        public IHttpActionResult GetSales(int id)
        {
            Sales sales = db.sales.Find(id);
            if (sales == null)
            {
                return NotFound();
            }

            return Ok(sales);
        }

        [HttpGet]
        //Will contain authorized admin id in update
        [Route("sales-report")]
        public IHttpActionResult GetSalesReport()
        {
             object customerPurchases =
               from cart in db.cart
               join customer in db.customer on cart.custId equals customer.id
               join product in db.products on cart.prodId equals product.id
               select new { 
                    cartId = cart.id,
                    customerName = customer.first_name + " " + customer.last_name,
                    productName = product.name,
                    productPrice = product.price,
               };

            return Ok(db.customer);
        }

        // PUT: api/Sales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSales(int id, Sales sales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sales.id)
            {
                return BadRequest();
            }

            db.Entry(sales).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesExists(id))
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

        // POST: api/Sales
        [ResponseType(typeof(Sales))]
        public IHttpActionResult PostSales(Sales sales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sales.Add(sales);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sales.id }, sales);
        }

        // DELETE: api/Sales/5
        [ResponseType(typeof(Sales))]
        public IHttpActionResult DeleteSales(int id)
        {
            Sales sales = db.sales.Find(id);
            if (sales == null)
            {
                return NotFound();
            }

            db.sales.Remove(sales);
            db.SaveChanges();

            return Ok(sales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesExists(int id)
        {
            return db.sales.Count(e => e.id == id) > 0;
        }
    }
}