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
    public class SocialPerfilsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/SocialPerfils
        public IQueryable<SocialPerfils> GetSocialPerfils()
        {
            return db.SocialPerfils;
        }

        // GET: api/SocialPerfils/5
        [ResponseType(typeof(SocialPerfils))]
        public async Task<IHttpActionResult> GetSocialPerfils(int id)
        {
            SocialPerfils socialPerfils = await db.SocialPerfils.FindAsync(id);
            if (socialPerfils == null)
            {
                return NotFound();
            }

            return Ok(socialPerfils);
        }

        // PUT: api/SocialPerfils/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSocialPerfils(int id, SocialPerfils socialPerfils)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != socialPerfils.SocialPerfilId)
            {
                return BadRequest();
            }

            db.Entry(socialPerfils).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialPerfilsExists(id))
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

        // POST: api/SocialPerfils
        [ResponseType(typeof(SocialPerfils))]
        public async Task<IHttpActionResult> PostSocialPerfils(SocialPerfils socialPerfils)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SocialPerfils.Add(socialPerfils);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = socialPerfils.SocialPerfilId }, socialPerfils);
        }

        // DELETE: api/SocialPerfils/5
        [ResponseType(typeof(SocialPerfils))]
        public async Task<IHttpActionResult> DeleteSocialPerfils(int id)
        {
            SocialPerfils socialPerfils = await db.SocialPerfils.FindAsync(id);
            if (socialPerfils == null)
            {
                return NotFound();
            }

            db.SocialPerfils.Remove(socialPerfils);
            await db.SaveChangesAsync();

            return Ok(socialPerfils);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SocialPerfilsExists(int id)
        {
            return db.SocialPerfils.Count(e => e.SocialPerfilId == id) > 0;
        }
    }
}