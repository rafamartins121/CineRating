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
    public class ComentariosController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        
       
        [Authorize(Roles = "Administradores,Gestores,Utilizadores")]
        // GET: Comentarios/Create
        public ActionResult Create() {
            ViewBag.FilmeFK = new SelectList(db.Filmes, "ID", "Titulo");
            ViewBag.UserFK = new SelectList(db.Utilizadores, "ID", "NomeUtilizador");
            return View();
        }


        // POST: Comentarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FilmeFK,Texto,")] Comentario comentario) {

            var userID = GetID();

            comentario.UserFK = userID;
            //comentario.FilmeFK = filme;
            comentario.DataComentario = DateTime.Now;




            if (ModelState.IsValid) {
                db.Comentario.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Details", "Filmes", new { id = comentario.FilmeFK });
                //return RedirectToAction("Details", "Filmes", new { id = filme});
            }

            ViewBag.FilmeFK = new SelectList(db.Filmes, "ID", "Titulo", comentario.FilmeFK);
            ViewBag.UserFK = new SelectList(db.Utilizadores, "ID", "NomeUtilizador", comentario.UserFK);
            return View(comentario);
        }

        [Authorize(Roles = "Administradores,Gestores,Utilizadores")]
        // GET: Comentarios/Edit/5
        public ActionResult Edit(int? id) {
            var userID = GetID();
            if (id == null) {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null || comentario.UserFK != userID) {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            ViewBag.FilmeFK = new SelectList(db.Filmes, "ID", "Titulo", comentario.FilmeFK);
            ViewBag.UserFK = new SelectList(db.Utilizadores, "ID", "NomeUtilizador", comentario.UserFK);
            return View(comentario);
        }

        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Texto")] Comentario comentario, int filmeID, int userID) {

            comentario.FilmeFK = filmeID;
            comentario.UserFK = userID;
            comentario.DataComentario = DateTime.Now;

            if (ModelState.IsValid) {
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + filmeID, "Filmes");
            }
            ViewBag.FilmeFK = new SelectList(db.Filmes, "ID", "Titulo", comentario.FilmeFK);
            ViewBag.UserFK = new SelectList(db.Utilizadores, "ID", "NomeUtilizador", comentario.UserFK);
            return View(comentario);
        }

        [Authorize(Roles = "Administradores,Gestores,Utilizadores")]
        // GET: Comentarios/Delete/5
        public ActionResult Delete(int? id) {
            var userID = GetID();
            if (id == null) {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario != null && (comentario.UserFK == userID || User.IsInRole("Administradores"))) {
                //return HttpNotFound();
                return View(comentario);
            }
            return RedirectToAction("Index");
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int filmeID) {
            Comentario comentario = db.Comentario.Find(id);
            db.Comentario.Remove(comentario);
            db.SaveChanges();
            return RedirectToAction("Details/" + filmeID, "Filmes");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public int GetID() {
            var userIDList = db.Utilizadores.Where(u => u.NomeUtilizador.Equals(User.Identity.Name));
            var userID = 0;
            foreach (var item in userIDList) {
                userID = item.ID;
            }
            return userID;
        }
    }
}
