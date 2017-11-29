using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contactos.Domain;
using Contactos.Domain.Models;

namespace Contactos.Backend.Controllers
{
    public class AddressesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Addresses
        public async Task<ActionResult> Index()
        {
            var addresses = db.Addresses.Include(a => a.PerfilGeneral);
            return View(await addresses.ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addresses addresses = await db.Addresses.FindAsync(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            return View(addresses);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AddressId,PerfilId,DescriptionAddress,Address")] Addresses addresses)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(addresses);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name", addresses.PerfilId);
            return View(addresses);
        }

        // GET: Addresses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addresses addresses = await db.Addresses.FindAsync(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name", addresses.PerfilId);
            return View(addresses);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AddressId,PerfilId,DescriptionAddress,Address")] Addresses addresses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addresses).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name", addresses.PerfilId);
            return View(addresses);
        }

        // GET: Addresses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addresses addresses = await db.Addresses.FindAsync(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            return View(addresses);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Addresses addresses = await db.Addresses.FindAsync(id);
            db.Addresses.Remove(addresses);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
