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
    public class NivelAccesosController : Controller
    {
        private BalcazzSupportEntities db = new BalcazzSupportEntities();

        // GET: NivelAccesos
        public ActionResult Index()
        {
            return View(db.NivelAccesos.ToList());
        }

        // GET: NivelAccesos/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelAccesos nivelAccesos = db.NivelAccesos.Find(id);
            if (nivelAccesos == null)
            {
                return HttpNotFound();
            }
            return View(nivelAccesos);
        }

        // GET: NivelAccesos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NivelAccesos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdNivelAcceso,NivelAcceso")] NivelAccesos nivelAccesos)
        {
            if (ModelState.IsValid)
            {
                db.NivelAccesos.Add(nivelAccesos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nivelAccesos);
        }

        // GET: NivelAccesos/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelAccesos nivelAccesos = db.NivelAccesos.Find(id);
            if (nivelAccesos == null)
            {
                return HttpNotFound();
            }
            return View(nivelAccesos);
        }

        // POST: NivelAccesos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdNivelAcceso,NivelAcceso")] NivelAccesos nivelAccesos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nivelAccesos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivelAccesos);
        }

        // GET: NivelAccesos/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelAccesos nivelAccesos = db.NivelAccesos.Find(id);
            if (nivelAccesos == null)
            {
                return HttpNotFound();
            }
            return View(nivelAccesos);
        }

        // POST: NivelAccesos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            NivelAccesos nivelAccesos = db.NivelAccesos.Find(id);
            db.NivelAccesos.Remove(nivelAccesos);
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
