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
    public class AttributesController : ApiController
    {
        private LISAEntities db = new LISAEntities();

        // GET: api/Attributes
        public IQueryable<Models.Attribute> GetAttribute()
        {
            return db.Attribute;
        }

        // GET: api/Attributes/5
        [ResponseType(typeof(Models.Attribute))]
        public async Task<IHttpActionResult> GetAttribute(int id)
        {
            Models.Attribute attribute = await db.Attribute.FindAsync(id);
            if (attribute == null)
            {
                return NotFound();
            }

            return Ok(attribute);
        }

        // PUT: api/Attributes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAttribute(int id, Models.Attribute attribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attribute.Id)
            {
                return BadRequest();
            }

            db.Entry(attribute).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttributeExists(id))
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

        // POST: api/Attributes
        [ResponseType(typeof(Models.Attribute))]
        public async Task<IHttpActionResult> PostAttribute(Models.Attribute attribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Attribute.Add(attribute);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = attribute.Id }, attribute);
        }

        // DELETE: api/Attributes/5
        [ResponseType(typeof(Models.Attribute))]
        public async Task<IHttpActionResult> DeleteAttribute(int id)
        {
            Models.Attribute attribute = await db.Attribute.FindAsync(id);
            if (attribute == null)
            {
                return NotFound();
            }

            db.Attribute.Remove(attribute);
            await db.SaveChangesAsync();

            return Ok(attribute);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttributeExists(int id)
        {
            return db.Attribute.Count(e => e.Id == id) > 0;
        }
    }
}