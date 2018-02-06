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
    public class AttributeProductsController : ApiController
    {
        private LISAEntities db = new LISAEntities();

        // GET: api/AttributeProducts
        public IQueryable<AttributeProduct> GetAttributeProduct()
        {
            return db.AttributeProduct;
        }

        // GET: api/AttributeProducts/5
        [ResponseType(typeof(AttributeProduct))]
        public async Task<IHttpActionResult> GetAttributeProduct(int id)
        {
            AttributeProduct attributeProduct = await db.AttributeProduct.FindAsync(id);
            if (attributeProduct == null)
            {
                return NotFound();
            }

            return Ok(attributeProduct);
        }

        // PUT: api/AttributeProducts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAttributeProduct(int id, AttributeProduct attributeProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attributeProduct.Id)
            {
                return BadRequest();
            }

            db.Entry(attributeProduct).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttributeProductExists(id))
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

        // POST: api/AttributeProducts
        [ResponseType(typeof(AttributeProduct))]
        public async Task<IHttpActionResult> PostAttributeProduct(AttributeProduct attributeProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AttributeProduct.Add(attributeProduct);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = attributeProduct.Id }, attributeProduct);
        }

        // DELETE: api/AttributeProducts/5
        [ResponseType(typeof(AttributeProduct))]
        public async Task<IHttpActionResult> DeleteAttributeProduct(int id)
        {
            AttributeProduct attributeProduct = await db.AttributeProduct.FindAsync(id);
            if (attributeProduct == null)
            {
                return NotFound();
            }

            db.AttributeProduct.Remove(attributeProduct);
            await db.SaveChangesAsync();

            return Ok(attributeProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttributeProductExists(int id)
        {
            return db.AttributeProduct.Count(e => e.Id == id) > 0;
        }
    }
}