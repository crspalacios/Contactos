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
    public class SocialPerfilsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: SocialPerfils
        public async Task<ActionResult> Index()
        {
            var socialPerfils = db.SocialPerfils.Include(s => s.PerfilGeneral);
            return View(await socialPerfils.ToListAsync());
        }

        // GET: SocialPerfils/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialPerfils socialPerfils = await db.SocialPerfils.FindAsync(id);
            if (socialPerfils == null)
            {
                return HttpNotFound();
            }
            return View(socialPerfils);
        }

        // GET: SocialPerfils/Create
        public ActionResult Create()
        {
            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name");
            return View();
        }

        // POST: SocialPerfils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SocialPerfilId,DescriptionSocialPerfil,PerfilId,SocialPerfil")] SocialPerfils socialPerfils)
        {
            if (ModelState.IsValid)
            {
                db.SocialPerfils.Add(socialPerfils);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name", socialPerfils.PerfilId);
            return View(socialPerfils);
        }

        // GET: SocialPerfils/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialPerfils socialPerfils = await db.SocialPerfils.FindAsync(id);
            if (socialPerfils == null)
            {
                return HttpNotFound();
            }
            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name", socialPerfils.PerfilId);
            return View(socialPerfils);
        }

        // POST: SocialPerfils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SocialPerfilId,DescriptionSocialPerfil,PerfilId,SocialPerfil")] SocialPerfils socialPerfils)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialPerfils).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name", socialPerfils.PerfilId);
            return View(socialPerfils);
        }

        // GET: SocialPerfils/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialPerfils socialPerfils = await db.SocialPerfils.FindAsync(id);
            if (socialPerfils == null)
            {
                return HttpNotFound();
            }
            return View(socialPerfils);
        }

        // POST: SocialPerfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SocialPerfils socialPerfils = await db.SocialPerfils.FindAsync(id);
            db.SocialPerfils.Remove(socialPerfils);
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
