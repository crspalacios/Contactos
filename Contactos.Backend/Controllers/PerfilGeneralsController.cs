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

namespace Contactos.Backend.Controllers
{
    public class PerfilGeneralsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: PerfilGenerals
        public async Task<ActionResult> Index()
        {
            return View(await db.PerfilGenerals.ToListAsync());
        }

        // GET: PerfilGenerals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilGeneral perfilGeneral = await db.PerfilGenerals.FindAsync(id);
            if (perfilGeneral == null)
            {
                return HttpNotFound();
            }
            return View(perfilGeneral);
        }

        // GET: PerfilGenerals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfilGenerals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PerfilId,Name,LastName,PerfilImage")] PerfilGeneral perfilGeneral)
        {
            if (ModelState.IsValid)
            {
                db.PerfilGenerals.Add(perfilGeneral);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(perfilGeneral);
        }

        // GET: PerfilGenerals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilGeneral perfilGeneral = await db.PerfilGenerals.FindAsync(id);
            if (perfilGeneral == null)
            {
                return HttpNotFound();
            }
            return View(perfilGeneral);
        }

        // POST: PerfilGenerals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PerfilId,Name,LastName,PerfilImage")] PerfilGeneral perfilGeneral)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfilGeneral).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(perfilGeneral);
        }

        // GET: PerfilGenerals/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilGeneral perfilGeneral = await db.PerfilGenerals.FindAsync(id);
            if (perfilGeneral == null)
            {
                return HttpNotFound();
            }
            return View(perfilGeneral);
        }

        // POST: PerfilGenerals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PerfilGeneral perfilGeneral = await db.PerfilGenerals.FindAsync(id);
            db.PerfilGenerals.Remove(perfilGeneral);
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
