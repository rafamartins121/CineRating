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
    public class FilmeGeneroController : Controller
    {
        private CineRatingDb db = new CineRatingDb();

        // GET: FilmeGenero
        public ActionResult Index()
        {
            var filmeGenero = db.FilmeGenero.Include(f => f.ID_Filme).Include(f => f.ID_Genero);
            return View(filmeGenero.ToList());
        }

        // GET: FilmeGenero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmeGenero filmeGenero = db.FilmeGenero.Find(id);
            if (filmeGenero == null)
            {
                return HttpNotFound();
            }
            return View(filmeGenero);
        }

        // GET: FilmeGenero/Create
        public ActionResult Create()
        {
            ViewBag.MovieFK = new SelectList(db.Filmes, "ID", "Titulo");
            ViewBag.GeneroFK = new SelectList(db.Generos, "ID", "Nome");
            return View();
        }

        // POST: FilmeGenero/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MovieFK,GeneroFK")] FilmeGenero filmeGenero)
        {
            if (ModelState.IsValid)
            {
                db.FilmeGenero.Add(filmeGenero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieFK = new SelectList(db.Filmes, "ID", "Titulo", filmeGenero.MovieFK);
            ViewBag.GeneroFK = new SelectList(db.Generos, "ID", "Nome", filmeGenero.GeneroFK);
            return View(filmeGenero);
        }

        // GET: FilmeGenero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmeGenero filmeGenero = db.FilmeGenero.Find(id);
            if (filmeGenero == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieFK = new SelectList(db.Filmes, "ID", "Titulo", filmeGenero.MovieFK);
            ViewBag.GeneroFK = new SelectList(db.Generos, "ID", "Nome", filmeGenero.GeneroFK);
            return View(filmeGenero);
        }

        // POST: FilmeGenero/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MovieFK,GeneroFK")] FilmeGenero filmeGenero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filmeGenero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieFK = new SelectList(db.Filmes, "ID", "Titulo", filmeGenero.MovieFK);
            ViewBag.GeneroFK = new SelectList(db.Generos, "ID", "Nome", filmeGenero.GeneroFK);
            return View(filmeGenero);
        }

        // GET: FilmeGenero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmeGenero filmeGenero = db.FilmeGenero.Find(id);
            if (filmeGenero == null)
            {
                return HttpNotFound();
            }
            return View(filmeGenero);
        }

        // POST: FilmeGenero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FilmeGenero filmeGenero = db.FilmeGenero.Find(id);
            db.FilmeGenero.Remove(filmeGenero);
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
