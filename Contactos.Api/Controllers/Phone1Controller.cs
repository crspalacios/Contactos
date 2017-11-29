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
using Contactos.Domain;
using Contactos.Domain.Models;

namespace Contactos.Api.Controllers
{
    public class Phone1Controller : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Phone1
        public IQueryable<Phone1> GetPhone1()
        {
            return db.Phone1;
        }

        // GET: api/Phone1/5
        [ResponseType(typeof(Phone1))]
        public async Task<IHttpActionResult> GetPhone1(int id)
        {
            Phone1 phone1 = await db.Phone1.FindAsync(id);
            if (phone1 == null)
            {
                return NotFound();
            }

            return Ok(phone1);
        }

        // PUT: api/Phone1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhone1(int id, Phone1 phone1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phone1.PhoneId)
            {
                return BadRequest();
            }

            db.Entry(phone1).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Phone1Exists(id))
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

        // POST: api/Phone1
        [ResponseType(typeof(Phone1))]
        public async Task<IHttpActionResult> PostPhone1(Phone1 phone1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Phone1.Add(phone1);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = phone1.PhoneId }, phone1);
        }

        // DELETE: api/Phone1/5
        [ResponseType(typeof(Phone1))]
        public async Task<IHttpActionResult> DeletePhone1(int id)
        {
            Phone1 phone1 = await db.Phone1.FindAsync(id);
            if (phone1 == null)
            {
                return NotFound();
            }

            db.Phone1.Remove(phone1);
            await db.SaveChangesAsync();

            return Ok(phone1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Phone1Exists(int id)
        {
            return db.Phone1.Count(e => e.PhoneId == id) > 0;
        }
    }
}