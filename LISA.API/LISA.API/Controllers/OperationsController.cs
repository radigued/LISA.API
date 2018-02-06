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
    public class OperationsController : ApiController
    {
        private LISAEntities db = new LISAEntities();

        // GET: api/Operations
        public IQueryable<Operation> GetOperation()
        {
            return db.Operation;
        }

        // GET: api/Operations/5
        [ResponseType(typeof(Operation))]
        public async Task<IHttpActionResult> GetOperation(int id)
        {
            Operation operation = await db.Operation.FindAsync(id);
            if (operation == null)
            {
                return NotFound();
            }

            return Ok(operation);
        }

        // PUT: api/Operations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOperation(int id, Operation operation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != operation.Id)
            {
                return BadRequest();
            }

            db.Entry(operation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationExists(id))
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

        // POST: api/Operations
        [ResponseType(typeof(Operation))]
        public async Task<IHttpActionResult> PostOperation(Operation operation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Operation.Add(operation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = operation.Id }, operation);
        }

        // DELETE: api/Operations/5
        [ResponseType(typeof(Operation))]
        public async Task<IHttpActionResult> DeleteOperation(int id)
        {
            Operation operation = await db.Operation.FindAsync(id);
            if (operation == null)
            {
                return NotFound();
            }

            db.Operation.Remove(operation);
            await db.SaveChangesAsync();

            return Ok(operation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OperationExists(int id)
        {
            return db.Operation.Count(e => e.Id == id) > 0;
        }
    }
}