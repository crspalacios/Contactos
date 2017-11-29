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
    public class EmailsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Emails
        public IQueryable<Emails> GetEmails()
        {
            return db.Emails;
        }

        // GET: api/Emails/5
        [ResponseType(typeof(Emails))]
        public async Task<IHttpActionResult> GetEmails(int id)
        {
            Emails emails = await db.Emails.FindAsync(id);
            if (emails == null)
            {
                return NotFound();
            }

            return Ok(emails);
        }

        // PUT: api/Emails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmails(int id, Emails emails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emails.EmailId)
            {
                return BadRequest();
            }

            db.Entry(emails).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailsExists(id))
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

        // POST: api/Emails
        [ResponseType(typeof(Emails))]
        public async Task<IHttpActionResult> PostEmails(Emails emails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Emails.Add(emails);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = emails.EmailId }, emails);
        }

        // DELETE: api/Emails/5
        [ResponseType(typeof(Emails))]
        public async Task<IHttpActionResult> DeleteEmails(int id)
        {
            Emails emails = await db.Emails.FindAsync(id);
            if (emails == null)
            {
                return NotFound();
            }

            db.Emails.Remove(emails);
            await db.SaveChangesAsync();

            return Ok(emails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmailsExists(int id)
        {
            return db.Emails.Count(e => e.EmailId == id) > 0;
        }
    }
}