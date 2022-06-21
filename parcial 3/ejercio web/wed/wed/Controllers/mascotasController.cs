using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wed.Models;

namespace wed.Controllers
{
    public class mascotasController : Controller
    {
        private veterinariaEntities db = new veterinariaEntities();

        // GET: mascotas
        public ActionResult Index()
        {
            return View(db.mascotas.ToList());
        }

        // GET: mascotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mascotas mascotas = db.mascotas.Find(id);
            if (mascotas == null)
            {
                return HttpNotFound();
            }
            return View(mascotas);
        }

        // GET: mascotas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,raza,edad,dueño")] mascotas mascotas)
        {
            if (ModelState.IsValid)
            {
                db.mascotas.Add(mascotas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mascotas);
        }

        // GET: mascotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mascotas mascotas = db.mascotas.Find(id);
            if (mascotas == null)
            {
                return HttpNotFound();
            }
            return View(mascotas);
        }

        // POST: mascotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,raza,edad,dueño")] mascotas mascotas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascotas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mascotas);
        }

        // GET: mascotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mascotas mascotas = db.mascotas.Find(id);
            if (mascotas == null)
            {
                return HttpNotFound();
            }
            return View(mascotas);
        }

        // POST: mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mascotas mascotas = db.mascotas.Find(id);
            db.mascotas.Remove(mascotas);
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
