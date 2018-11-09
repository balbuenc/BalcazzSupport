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
    public class TareasController : Controller
    {
        private BalcazzSupportEntities db = new BalcazzSupportEntities();

        // GET: Tareas
        public ActionResult Index()
        {
            var tareas = db.Tareas.Include(t => t.Proyectos);
            return View(tareas.ToList());
        }

        // GET: Tareas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tareas tareas = db.Tareas.Find(id);
            if (tareas == null)
            {
                return HttpNotFound();
            }
            return View(tareas);
        }

        // GET: Tareas/Create
        public ActionResult Create()
        {
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto");
            return View();
        }

        // POST: Tareas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTarea,Tarea,Descripcion,IdProyecto,Horas")] Tareas tareas)
        {
            if (ModelState.IsValid)
            {
                db.Tareas.Add(tareas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", tareas.IdProyecto);
            return View(tareas);
        }

        // GET: Tareas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tareas tareas = db.Tareas.Find(id);
            if (tareas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", tareas.IdProyecto);
            return View(tareas);
        }

        // POST: Tareas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTarea,Tarea,Descripcion,IdProyecto,Horas")] Tareas tareas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tareas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProyecto = new SelectList(db.Proyectos, "IdProyecto", "Proyecto", tareas.IdProyecto);
            return View(tareas);
        }

        // GET: Tareas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tareas tareas = db.Tareas.Find(id);
            if (tareas == null)
            {
                return HttpNotFound();
            }
            return View(tareas);
        }

        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tareas tareas = db.Tareas.Find(id);
            db.Tareas.Remove(tareas);
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
