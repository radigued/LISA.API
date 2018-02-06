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
    public class PositionProductsController : ApiController
    {
        private LISAEntities db = new LISAEntities();

        // GET: api/PositionProducts
        public IQueryable<PositionProduct> GetPositionProduct()
        {
            return db.PositionProduct;
        }

        // GET: api/PositionProducts/5
        [ResponseType(typeof(PositionProduct))]
        public async Task<IHttpActionResult> GetPositionProduct(int id)
        {
            PositionProduct positionProduct = await db.PositionProduct.FindAsync(id);
            if (positionProduct == null)
            {
                return NotFound();
            }

            return Ok(positionProduct);
        }

        // PUT: api/PositionProducts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPositionProduct(int id, PositionProduct positionProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != positionProduct.Id)
            {
                return BadRequest();
            }

            db.Entry(positionProduct).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionProductExists(id))
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

        // POST: api/PositionProducts
        [ResponseType(typeof(PositionProduct))]
        public async Task<IHttpActionResult> PostPositionProduct(PositionProduct positionProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PositionProduct.Add(positionProduct);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = positionProduct.Id }, positionProduct);
        }

        // DELETE: api/PositionProducts/5
        [ResponseType(typeof(PositionProduct))]
        public async Task<IHttpActionResult> DeletePositionProduct(int id)
        {
            PositionProduct positionProduct = await db.PositionProduct.FindAsync(id);
            if (positionProduct == null)
            {
                return NotFound();
            }

            db.PositionProduct.Remove(positionProduct);
            await db.SaveChangesAsync();

            return Ok(positionProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PositionProductExists(int id)
        {
            return db.PositionProduct.Count(e => e.Id == id) > 0;
        }
    }
}