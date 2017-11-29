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

namespace Contactos.Api.Controllers
{
    public class PerfilGeneralsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/PerfilGenerals
        public IQueryable<PerfilGeneral> GetPerfilGenerals()
        {
            return db.PerfilGenerals;
        }

        // GET: api/PerfilGenerals/5
        [ResponseType(typeof(PerfilGeneral))]
        public async Task<IHttpActionResult> GetPerfilGeneral(int id)
        {
            PerfilGeneral perfilGeneral = await db.PerfilGenerals.FindAsync(id);
            if (perfilGeneral == null)
            {
                return NotFound();
            }

            return Ok(perfilGeneral);
        }

        // PUT: api/PerfilGenerals/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPerfilGeneral(int id, PerfilGeneral perfilGeneral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfilGeneral.PerfilId)
            {
                return BadRequest();
            }

            db.Entry(perfilGeneral).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilGeneralExists(id))
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

        // POST: api/PerfilGenerals
        [ResponseType(typeof(PerfilGeneral))]
        public async Task<IHttpActionResult> PostPerfilGeneral(PerfilGeneral perfilGeneral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PerfilGenerals.Add(perfilGeneral);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = perfilGeneral.PerfilId }, perfilGeneral);
        }

        // DELETE: api/PerfilGenerals/5
        [ResponseType(typeof(PerfilGeneral))]
        public async Task<IHttpActionResult> DeletePerfilGeneral(int id)
        {
            PerfilGeneral perfilGeneral = await db.PerfilGenerals.FindAsync(id);
            if (perfilGeneral == null)
            {
                return NotFound();
            }

            db.PerfilGenerals.Remove(perfilGeneral);
            await db.SaveChangesAsync();

            return Ok(perfilGeneral);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerfilGeneralExists(int id)
        {
            return db.PerfilGenerals.Count(e => e.PerfilId == id) > 0;
        }
    }
}