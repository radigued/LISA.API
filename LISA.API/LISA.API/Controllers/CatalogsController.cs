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
    public class CatalogsController : ApiController
    {
        private LISAEntities db = new LISAEntities();

        // GET: api/Catalogs
        public IQueryable<Catalog> GetCatalog()
        {
            return db.Catalog;
        }

        // GET: api/Catalogs/5
        [ResponseType(typeof(Catalog))]
        public async Task<IHttpActionResult> GetCatalog(int id)
        {
            Catalog catalog = await db.Catalog.FindAsync(id);
            if (catalog == null)
            {
                return NotFound();
            }

            return Ok(catalog);
        }

        // PUT: api/Catalogs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCatalog(int id, Catalog catalog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catalog.Id)
            {
                return BadRequest();
            }

            db.Entry(catalog).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogExists(id))
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

        // POST: api/Catalogs
        [ResponseType(typeof(Catalog))]
        public async Task<IHttpActionResult> PostCatalog(Catalog catalog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Catalog.Add(catalog);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = catalog.Id }, catalog);
        }

        // DELETE: api/Catalogs/5
        [ResponseType(typeof(Catalog))]
        public async Task<IHttpActionResult> DeleteCatalog(int id)
        {
            Catalog catalog = await db.Catalog.FindAsync(id);
            if (catalog == null)
            {
                return NotFound();
            }

            db.Catalog.Remove(catalog);
            await db.SaveChangesAsync();

            return Ok(catalog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CatalogExists(int id)
        {
            return db.Catalog.Count(e => e.Id == id) > 0;
        }
    }
}