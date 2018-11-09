using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BalcazzSupport.Models;

namespace BalcazzSupport.Controllers
{
    public class AutorizacionesController : Controller
    {
        private BalcazzSupportEntities db = new BalcazzSupportEntities();

        // GET: Autorizaciones
        public ActionResult Index()
        {
            var autorizaciones = db.Autorizaciones.Include(a => a.NivelAccesos).Include(a => a.Proyectos);
            return View(autorizaciones.ToList());
        }

        // GET: Autorizaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autorizaciones autorizaciones = db.Autorizaciones.Find(id);
            if (autorizaciones == null)
            {
                return HttpNotFound();
            }
            return View(autorizaciones);
        }

        // GET: Autorizaciones/Create
        public ActionResult Create()
        {
            ViewBag.idNivelAcceso = new SelectList(db.NivelAccesos, "IdNivelAcceso", "NivelAcceso");
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto");
            return View();
        }

        // POST: Autorizaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProyecto,Usuario,idNivelAcceso")] Autorizaciones autorizaciones)
        {
            if (ModelState.IsValid)
            {
                db.Autorizaciones.Add(autorizaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idNivelAcceso = new SelectList(db.NivelAccesos, "IdNivelAcceso", "NivelAcceso", autorizaciones.idNivelAcceso);
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", autorizaciones.IdProyecto);
            return View(autorizaciones);
        }

        // GET: Autorizaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autorizaciones autorizaciones = db.Autorizaciones.Find(id);
            if (autorizaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNivelAcceso = new SelectList(db.NivelAccesos, "IdNivelAcceso", "NivelAcceso", autorizaciones.idNivelAcceso);
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", autorizaciones.IdProyecto);
            return View(autorizaciones);
        }

        // POST: Autorizaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProyecto,Usuario,idNivelAcceso")] Autorizaciones autorizaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autorizaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNivelAcceso = new SelectList(db.NivelAccesos, "IdNivelAcceso", "NivelAcceso", autorizaciones.idNivelAcceso);
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", autorizaciones.IdProyecto);
            return View(autorizaciones);
        }

        // GET: Autorizaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autorizaciones autorizaciones = db.Autorizaciones.Find(id);
            if (autorizaciones == null)
            {
                return HttpNotFound();
            }
            return View(autorizaciones);
        }

        // POST: Autorizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autorizaciones autorizaciones = db.Autorizaciones.Find(id);
            db.Autorizaciones.Remove(autorizaciones);
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
