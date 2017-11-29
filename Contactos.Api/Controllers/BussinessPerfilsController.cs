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
    public class BussinessPerfilsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/BussinessPerfils
        public IQueryable<BussinessPerfils> GetBussinessPerfils()
        {
            return db.BussinessPerfils;
        }

        // GET: api/BussinessPerfils/5
        [ResponseType(typeof(BussinessPerfils))]
        public async Task<IHttpActionResult> GetBussinessPerfils(int id)
        {
            BussinessPerfils bussinessPerfils = await db.BussinessPerfils.FindAsync(id);
            if (bussinessPerfils == null)
            {
                return NotFound();
            }

            return Ok(bussinessPerfils);
        }

        // PUT: api/BussinessPerfils/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBussinessPerfils(int id, BussinessPerfils bussinessPerfils)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bussinessPerfils.BussinessPerfilId)
            {
                return BadRequest();
            }

            db.Entry(bussinessPerfils).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BussinessPerfilsExists(id))
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

        // POST: api/BussinessPerfils
        [ResponseType(typeof(BussinessPerfils))]
        public async Task<IHttpActionResult> PostBussinessPerfils(BussinessPerfils bussinessPerfils)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BussinessPerfils.Add(bussinessPerfils);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bussinessPerfils.BussinessPerfilId }, bussinessPerfils);
        }

        // DELETE: api/BussinessPerfils/5
        [ResponseType(typeof(BussinessPerfils))]
        public async Task<IHttpActionResult> DeleteBussinessPerfils(int id)
        {
            BussinessPerfils bussinessPerfils = await db.BussinessPerfils.FindAsync(id);
            if (bussinessPerfils == null)
            {
                return NotFound();
            }

            db.BussinessPerfils.Remove(bussinessPerfils);
            await db.SaveChangesAsync();

            return Ok(bussinessPerfils);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BussinessPerfilsExists(int id)
        {
            return db.BussinessPerfils.Count(e => e.BussinessPerfilId == id) > 0;
        }
    }
}