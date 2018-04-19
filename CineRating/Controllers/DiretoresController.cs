using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CineRating.Models;

namespace CineRating.Controllers
{
    public class DiretoresController : Controller
    {
        private CineRatingDb db = new CineRatingDb();

        // GET: Diretores
        public ActionResult Index()
        {
            return View(db.Diretores.ToList());
        }

        // GET: Diretores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diretores diretores = db.Diretores.Find(id);
            if (diretores == null)
            {
                return HttpNotFound();
            }
            return View(diretores);
        }

        // GET: Diretores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diretores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome")] Diretores diretores)
        {
            if (ModelState.IsValid)
            {
                db.Diretores.Add(diretores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diretores);
        }

        // GET: Diretores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diretores diretores = db.Diretores.Find(id);
            if (diretores == null)
            {
                return HttpNotFound();
            }
            return View(diretores);
        }

        // POST: Diretores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome")] Diretores diretores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diretores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diretores);
        }

        // GET: Diretores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diretores diretores = db.Diretores.Find(id);
            if (diretores == null)
            {
                return HttpNotFound();
            }
            return View(diretores);
        }

        // POST: Diretores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diretores diretores = db.Diretores.Find(id);
            db.Diretores.Remove(diretores);
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
