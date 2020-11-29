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
    public class GamasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Gamas
        public ActionResult Index()
        {
            return View(db.Gamas.ToList());
        }

        // GET: Gamas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gama gama = db.Gamas.Include(a => a.Maquillajes).Where( a => a.Id==id).SingleOrDefault();
            if (gama == null)
            {
                return HttpNotFound();
            }
            return View(gama);
        }

        // GET: Gamas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gamas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo")] Gama gama)
        {
            if (ModelState.IsValid)
            {
                db.Gamas.Add(gama);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gama);
        }

        // GET: Gamas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gama gama = db.Gamas.Find(id);
            if (gama == null)
            {
                return HttpNotFound();
            }
            return View(gama);
        }

        // POST: Gamas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo")] Gama gama)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gama).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gama);
        }

        // GET: Gamas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gama gama = db.Gamas.Find(id);
            if (gama == null)
            {
                return HttpNotFound();
            }
            return View(gama);
        }

        // POST: Gamas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gama gama = db.Gamas.Find(id);
            db.Gamas.Remove(gama);
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
