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
    public class BussinessPerfilsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: BussinessPerfils
        public async Task<ActionResult> Index()
        {
            var bussinessPerfils = db.BussinessPerfils.Include(b => b.PerfilGeneral);
            return View(await bussinessPerfils.ToListAsync());
        }

        // GET: BussinessPerfils/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BussinessPerfils bussinessPerfils = await db.BussinessPerfils.FindAsync(id);
            if (bussinessPerfils == null)
            {
                return HttpNotFound();
            }
            return View(bussinessPerfils);
        }

        // GET: BussinessPerfils/Create
        public ActionResult Create()
        {
            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name");
            return View();
        }

        // POST: BussinessPerfils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BussinessPerfilId,PerfilId,BussinessPerfilStudyDescription,BussinessPerfilWorkDescription,BussinessPerfilPositionDescription")] BussinessPerfils bussinessPerfils)
        {
            if (ModelState.IsValid)
            {
                db.BussinessPerfils.Add(bussinessPerfils);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name", bussinessPerfils.PerfilId);
            return View(bussinessPerfils);
        }

        // GET: BussinessPerfils/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BussinessPerfils bussinessPerfils = await db.BussinessPerfils.FindAsync(id);
            if (bussinessPerfils == null)
            {
                return HttpNotFound();
            }
            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name", bussinessPerfils.PerfilId);
            return View(bussinessPerfils);
        }

        // POST: BussinessPerfils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BussinessPerfilId,PerfilId,BussinessPerfilStudyDescription,BussinessPerfilWorkDescription,BussinessPerfilPositionDescription")] BussinessPerfils bussinessPerfils)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bussinessPerfils).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PerfilId = new SelectList(db.PerfilGenerals, "PerfilId", "Name", bussinessPerfils.PerfilId);
            return View(bussinessPerfils);
        }

        // GET: BussinessPerfils/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BussinessPerfils bussinessPerfils = await db.BussinessPerfils.FindAsync(id);
            if (bussinessPerfils == null)
            {
                return HttpNotFound();
            }
            return View(bussinessPerfils);
        }

        // POST: BussinessPerfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BussinessPerfils bussinessPerfils = await db.BussinessPerfils.FindAsync(id);
            db.BussinessPerfils.Remove(bussinessPerfils);
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
