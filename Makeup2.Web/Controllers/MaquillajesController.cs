using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Makeup2.Web.Models;

namespace Makeup2.Web.Controllers
{
    [Authorize]
    public class MaquillajesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Maquillajes
        public ActionResult Index()
        {
            var maquillajes = db.Maquillajes.Include(a => a.Gama);
            return View(maquillajes.ToList());
        }

        // GET: Maquillajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maquillaje maquillaje = db.Maquillajes.Find(id);
            if (maquillaje == null)
            {
                return HttpNotFound();
            }
            return View(maquillaje);
        }

        // GET: Maquillajes/Create
        public ActionResult Create()
        {
            ViewBag.GamaId = new SelectList(db.Gamas, "Id", "Tipo");
            return View();
        }

        // POST: Maquillajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Maquillaje maquillaje)
        {
            if (ModelState.IsValid)
            {
                db.Maquillajes.Add(maquillaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GamaId = new SelectList(db.Gamas, "Id", "Tipo", maquillaje.GamaId);
            return View(maquillaje);
        }

        // GET: Maquillajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maquillaje maquillaje = db.Maquillajes.Find(id);
            if (maquillaje == null)
            {
                return HttpNotFound();
            }
            ViewBag.GamaId = new SelectList(db.Gamas, "Id", "Tipo", maquillaje.GamaId);
            return View(maquillaje);
        }

        // POST: Maquillajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateTime,Marca,GamaId")] Maquillaje maquillaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maquillaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GamaId = new SelectList(db.Gamas, "Id", "Tipo", maquillaje.GamaId);
            return View(maquillaje);
        }

        // GET: Maquillajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maquillaje maquillaje = db.Maquillajes.Find(id);
            if (maquillaje == null)
            {
                return HttpNotFound();
            }
            return View(maquillaje);
        }

        // POST: Maquillajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maquillaje maquillaje = db.Maquillajes.Find(id);
            db.Maquillajes.Remove(maquillaje);
            db.SaveChanges();
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
