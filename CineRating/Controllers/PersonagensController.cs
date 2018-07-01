using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CineRating.Models;

namespace CineRating.Controllers {
    public class PersonagensController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personagens
        /// <summary>
        /// Mostra as personagens que entram num filme
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() {
            var aux = Convert.ToInt32(Session["filmeID"]);
            if (aux != 0) {
                var personagem = db.Personagem.Where(p => p.MovieFK.Equals(aux))
                .Include(p => p.ID_Ator)
                .Include(p => p.ID_Filme);
                Session["filmeID"] = 0;
                return View(personagem.ToList());
            }
            return RedirectToAction("Index", "Filmes");
        }



        // GET: Personagens/Create
        [Authorize(Roles = "Administradores,Gestores")]
        public ActionResult Create(int? filmeID) {
            if (filmeID != null) {
                ViewBag.AtorFK = new SelectList(db.Atores, "ID", "Nome");
                ViewBag.MovieFK = new SelectList(db.Filmes, "ID", "Titulo");
                return View();
            }
            return RedirectToAction("Index", "Filmes");
        }

        // POST: Personagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AtorFK,Role")] Personagem personagem, int? filmeID) {
            if (filmeID != null) {
                personagem.MovieFK = (int)filmeID;
                if (ModelState.IsValid) {
                    db.Personagem.Add(personagem);
                    db.SaveChanges();
                    return RedirectToAction("Details", "Filmes", new { id = filmeID });
                }

                ViewBag.AtorFK = new SelectList(db.Atores, "ID", "Nome", personagem.AtorFK);
                ViewBag.MovieFK = new SelectList(db.Filmes, "ID", "Titulo", personagem.MovieFK);
                return View(personagem);
            }
            return RedirectToAction("Index", "Filmes");
        }



        // GET: Personagens/Delete/5
        [Authorize(Roles = "Administradores,Gestores")]
        public ActionResult Delete(int? id) {
            if (id == null) {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }
            Personagem personagem = db.Personagem.Find(id);
            if (personagem == null) {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            return View(personagem);
        }

        // POST: Personagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Personagem personagem = db.Personagem.Find(id);
            db.Personagem.Remove(personagem);
            db.SaveChanges();
            return RedirectToAction("Details", "Filmes", new { id = personagem.MovieFK });
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
