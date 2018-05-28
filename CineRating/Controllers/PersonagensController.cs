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
    public class PersonagensController : Controller
    {
        private ApplicationDbContext  db = new ApplicationDbContext ();

        // GET: Personagens
        public ActionResult Index()
        {
            var aux = Convert.ToInt32(Session["filmeID"]);
            if (aux != 0) {
                var personagem = db.Personagem.Where(p => p.MovieFK.Equals(aux))
                .Include(p => p.ID_Ator)
                .Include(p => p.ID_Filme);
                Session["filmeID"] = 0;
                return View(personagem.ToList());
            }
            return View(db.Personagem.ToList());
        }

        // GET: Personagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }
            Personagem personagem = db.Personagem.Find(id);
            if (personagem == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            return View(personagem);
        }

        // GET: Personagens/Create
        public ActionResult Create()
        {
            ViewBag.AtorFK = new SelectList(db.Atores, "ID", "Nome");
            ViewBag.MovieFK = new SelectList(db.Filmes, "ID", "Titulo");
            return View();
        }

        // POST: Personagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AtorFK,Role")] Personagem personagem, int filmeID)
        {
            personagem.MovieFK = filmeID;
            if (ModelState.IsValid)
            {
                db.Personagem.Add(personagem);
                db.SaveChanges();
                return RedirectToAction("Details", "Filmes", new { id = filmeID });
            }

            ViewBag.AtorFK = new SelectList(db.Atores, "ID", "Nome", personagem.AtorFK);
            ViewBag.MovieFK = new SelectList(db.Filmes, "ID", "Titulo", personagem.MovieFK);
            return View(personagem);
        }

        // GET: Personagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }
            Personagem personagem = db.Personagem.Find(id);
            if (personagem == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            ViewBag.AtorFK = new SelectList(db.Atores, "ID", "Nome", personagem.AtorFK);
            ViewBag.MovieFK = new SelectList(db.Filmes, "ID", "Titulo", personagem.MovieFK);
            return View(personagem);
        }

        // POST: Personagens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MovieFK,AtorFK,Role")] Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AtorFK = new SelectList(db.Atores, "ID", "Nome", personagem.AtorFK);
            ViewBag.MovieFK = new SelectList(db.Filmes, "ID", "Titulo", personagem.MovieFK);
            return View(personagem);
        }

        // GET: Personagens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }
            Personagem personagem = db.Personagem.Find(id);
            if (personagem == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            return View(personagem);
        }

        // POST: Personagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personagem personagem = db.Personagem.Find(id);
            db.Personagem.Remove(personagem);
            db.SaveChanges();
            return RedirectToAction("Details", "Filmes", new { id = personagem.MovieFK });
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
