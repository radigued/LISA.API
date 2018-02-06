using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LISA.API.Models;

namespace LISA.API.Controllers
{
    public class PriceProductsController : ApiController
    {
        private LISAEntities db = new LISAEntities();

        // GET: api/PriceProducts
        public IQueryable<PriceProduct> GetPriceProduct()
        {
            return db.PriceProduct;
        }

        // GET: api/PriceProducts/5
        [ResponseType(typeof(PriceProduct))]
        public async Task<IHttpActionResult> GetPriceProduct(int id)
        {
            PriceProduct priceProduct = await db.PriceProduct.FindAsync(id);
            if (priceProduct == null)
            {
                return NotFound();
            }

            return Ok(priceProduct);
        }

        // PUT: api/PriceProducts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPriceProduct(int id, PriceProduct priceProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != priceProduct.Id)
            {
                return BadRequest();
            }

            db.Entry(priceProduct).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceProductExists(id))
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

        // POST: api/PriceProducts
        [ResponseType(typeof(PriceProduct))]
        public async Task<IHttpActionResult> PostPriceProduct(PriceProduct priceProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PriceProduct.Add(priceProduct);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = priceProduct.Id }, priceProduct);
        }

        // DELETE: api/PriceProducts/5
        [ResponseType(typeof(PriceProduct))]
        public async Task<IHttpActionResult> DeletePriceProduct(int id)
        {
            PriceProduct priceProduct = await db.PriceProduct.FindAsync(id);
            if (priceProduct == null)
            {
                return NotFound();
            }

            db.PriceProduct.Remove(priceProduct);
            await db.SaveChangesAsync();

            return Ok(priceProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PriceProductExists(int id)
        {
            return db.PriceProduct.Count(e => e.Id == id) > 0;
        }
    }
}