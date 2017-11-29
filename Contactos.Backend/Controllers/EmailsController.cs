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
    public class EmailsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Emails
        public async Task<ActionResult> Index()
        {
            var emails = db.Emails.Include(e => e.PerfilGeneral);
            return View(await emails.ToListAsync());
        }

        // GET: Emails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emails emails = await db.Emails.FindAsync(id);
            if (emails == null)
            {
                return HttpNotFound();
            }
            return View(emails);
        }

        // GET: Emails/Create
        public ActionResult Create()
        {
            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name");
            return View();
        }

        // POST: Emails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmailId,PerfilId,DescriptionEmail,Email")] Emails emails)
        {
            if (ModelState.IsValid)
            {
                db.Emails.Add(emails);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name", emails.PerfilId);
            return View(emails);
        }

        // GET: Emails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emails emails = await db.Emails.FindAsync(id);
            if (emails == null)
            {
                return HttpNotFound();
            }
            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name", emails.PerfilId);
            return View(emails);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmailId,PerfilId,DescriptionEmail,Email")] Emails emails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emails).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name", emails.PerfilId);
            return View(emails);
        }

        // GET: Emails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emails emails = await db.Emails.FindAsync(id);
            if (emails == null)
            {
                return HttpNotFound();
            }
            return View(emails);
        }

        // POST: Emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Emails emails = await db.Emails.FindAsync(id);
            db.Emails.Remove(emails);
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
