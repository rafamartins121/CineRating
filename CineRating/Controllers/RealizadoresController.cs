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
    public class RealizadoresController : Controller
    {
        private CineRatingDb db = new CineRatingDb();

        // GET: Realizadores
        public ActionResult Index()
        {
            return View(db.Realizadores.ToList());
        }

        // GET: Realizadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realizadores realizadores = db.Realizadores.Find(id);
            if (realizadores == null)
            {
                return HttpNotFound();
            }
            return View(realizadores);
        }

        // GET: Realizadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Realizadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,DataNascimento,Biografia,Imagem")] Realizadores realizadores)
        {
            if (ModelState.IsValid)
            {
                db.Realizadores.Add(realizadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(realizadores);
        }

        // GET: Realizadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realizadores realizadores = db.Realizadores.Find(id);
            if (realizadores == null)
            {
                return HttpNotFound();
            }
            return View(realizadores);
        }

        // POST: Realizadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,DataNascimento,Biografia,Imagem")] Realizadores realizadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realizadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(realizadores);
        }

        // GET: Realizadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realizadores realizadores = db.Realizadores.Find(id);
            if (realizadores == null)
            {
                return HttpNotFound();
            }
            return View(realizadores);
        }

        // POST: Realizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Realizadores realizadores = db.Realizadores.Find(id);
            db.Realizadores.Remove(realizadores);
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
