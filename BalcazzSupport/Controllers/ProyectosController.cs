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
    public class ProyectosController : Controller
    {
        private BalcazzSupportEntities db = new BalcazzSupportEntities();

        // GET: Proyectos
        public ActionResult Index()
        {
            var proyectos = db.Proyectos.Include(p => p.Clientes).Include(p => p.Prioridades);
            return View(proyectos.ToList());
        }

        // GET: Proyectos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyectos proyectos = db.Proyectos.Find(id);
            if (proyectos == null)
            {
                return HttpNotFound();
            }
            return View(proyectos);
        }

        // GET: Proyectos/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cliente");
            ViewBag.IdPrioridad = new SelectList(db.Prioridades, "IdPrioridad", "Prioridad");
            return View();
        }

        // POST: Proyectos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProyecto,IdCliente,Proyecto,FechaInicio,FechaFin,CantidadHoras,IdPrioridad")] Proyectos proyectos)
        {
            if (ModelState.IsValid)
            {
                db.Proyectos.Add(proyectos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cliente", proyectos.IdCliente);
            ViewBag.IdPrioridad = new SelectList(db.Prioridades, "IdPrioridad", "Prioridad", proyectos.IdPrioridad);
            return View(proyectos);
        }

        // GET: Proyectos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyectos proyectos = db.Proyectos.Find(id);
            if (proyectos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cliente", proyectos.IdCliente);
            ViewBag.IdPrioridad = new SelectList(db.Prioridades, "IdPrioridad", "Prioridad", proyectos.IdPrioridad);
            return View(proyectos);
        }

        // POST: Proyectos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProyecto,IdCliente,Proyecto,FechaInicio,FechaFin,CantidadHoras,IdPrioridad")] Proyectos proyectos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyectos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cliente", proyectos.IdCliente);
            ViewBag.IdPrioridad = new SelectList(db.Prioridades, "IdPrioridad", "Prioridad", proyectos.IdPrioridad);
            return View(proyectos);
        }

        // GET: Proyectos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyectos proyectos = db.Proyectos.Find(id);
            if (proyectos == null)
            {
                return HttpNotFound();
            }
            return View(proyectos);
        }

        // POST: Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proyectos proyectos = db.Proyectos.Find(id);
            db.Proyectos.Remove(proyectos);
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
