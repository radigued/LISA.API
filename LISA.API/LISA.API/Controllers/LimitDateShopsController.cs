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
    public class LimitDateShopsController : ApiController
    {
        private LISAEntities db = new LISAEntities();

        // GET: api/LimitDateShops
        public IQueryable<LimitDateShop> GetLimitDateShop()
        {
            return db.LimitDateShop;
        }

        // GET: api/LimitDateShops/5
        [ResponseType(typeof(LimitDateShop))]
        public async Task<IHttpActionResult> GetLimitDateShop(int id)
        {
            LimitDateShop limitDateShop = await db.LimitDateShop.FindAsync(id);
            if (limitDateShop == null)
            {
                return NotFound();
            }

            return Ok(limitDateShop);
        }

        // PUT: api/LimitDateShops/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLimitDateShop(int id, LimitDateShop limitDateShop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != limitDateShop.Id)
            {
                return BadRequest();
            }

            db.Entry(limitDateShop).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LimitDateShopExists(id))
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

        // POST: api/LimitDateShops
        [ResponseType(typeof(LimitDateShop))]
        public async Task<IHttpActionResult> PostLimitDateShop(LimitDateShop limitDateShop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LimitDateShop.Add(limitDateShop);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = limitDateShop.Id }, limitDateShop);
        }

        // DELETE: api/LimitDateShops/5
        [ResponseType(typeof(LimitDateShop))]
        public async Task<IHttpActionResult> DeleteLimitDateShop(int id)
        {
            LimitDateShop limitDateShop = await db.LimitDateShop.FindAsync(id);
            if (limitDateShop == null)
            {
                return NotFound();
            }

            db.LimitDateShop.Remove(limitDateShop);
            await db.SaveChangesAsync();

            return Ok(limitDateShop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LimitDateShopExists(int id)
        {
            return db.LimitDateShop.Count(e => e.Id == id) > 0;
        }
    }
}