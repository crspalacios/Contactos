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
    public class Phone1Controller : Controller
    {
        private DataContext db = new DataContext();

        // GET: Phone1
        public async Task<ActionResult> Index()
        {
            var phone1 = db.Phone1.Include(p => p.PerfilGeneral);
            return View(await phone1.ToListAsync());
        }

        // GET: Phone1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone1 phone1 = await db.Phone1.FindAsync(id);
            if (phone1 == null)
            {
                return HttpNotFound();
            }
            return View(phone1);
        }

        // GET: Phone1/Create
        public ActionResult Create()
        {
            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name");
            return View();
        }

        // POST: Phone1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PhoneId,PerfilId,PhoneNumber,DescriptionPhone,LastUpdate")] Phone1 phone1)
        {
            if (ModelState.IsValid)
            {
                db.Phone1.Add(phone1);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name", phone1.PerfilId);
            return View(phone1);
        }

        // GET: Phone1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone1 phone1 = await db.Phone1.FindAsync(id);
            if (phone1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name", phone1.PerfilId);
            return View(phone1);
        }

        // POST: Phone1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PhoneId,PerfilId,PhoneNumber,DescriptionPhone,LastUpdate")] Phone1 phone1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone1).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name", phone1.PerfilId);
            return View(phone1);
        }

        // GET: Phone1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone1 phone1 = await db.Phone1.FindAsync(id);
            if (phone1 == null)
            {
                return HttpNotFound();
            }
            return View(phone1);
        }

        // POST: Phone1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Phone1 phone1 = await db.Phone1.FindAsync(id);
            db.Phone1.Remove(phone1);
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
