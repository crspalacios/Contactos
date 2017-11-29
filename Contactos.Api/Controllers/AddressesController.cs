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
    public class AddressesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Addresses
        public IQueryable<Addresses> GetAddresses()
        {
            return db.Addresses;
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(Addresses))]
        public async Task<IHttpActionResult> GetAddresses(int id)
        {
            Addresses addresses = await db.Addresses.FindAsync(id);
            if (addresses == null)
            {
                return NotFound();
            }

            return Ok(addresses);
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAddresses(int id, Addresses addresses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != addresses.AddressId)
            {
                return BadRequest();
            }

            db.Entry(addresses).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressesExists(id))
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

        // POST: api/Addresses
        [ResponseType(typeof(Addresses))]
        public async Task<IHttpActionResult> PostAddresses(Addresses addresses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Addresses.Add(addresses);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = addresses.AddressId }, addresses);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Addresses))]
        public async Task<IHttpActionResult> DeleteAddresses(int id)
        {
            Addresses addresses = await db.Addresses.FindAsync(id);
            if (addresses == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(addresses);
            await db.SaveChangesAsync();

            return Ok(addresses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddressesExists(int id)
        {
            return db.Addresses.Count(e => e.AddressId == id) > 0;
        }
    }
}