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

    public class StoreController : ApiController
    {
        private StoreContext db = new StoreContext();


        // GET api/values
        public IEnumerable<object> Get()
        {

            object StoreProducts = db.products.Join(
                db.categories,
                product => product.catId,
                category => category.id,
                (product,category) => new
                {
                    catId = category.id,
                    catName = category.name,
                    id = product.id,
                    name = product.name,
                    image = product.image,
                    price = product.price,
                }
                ).GroupBy(x => x.catId, (key,g) => g.Take(9)).ToList();

            return (IEnumerable<object>)StoreProducts;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }



        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
