﻿using System;
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
        private ApplicationDbContext  db = new ApplicationDbContext ();

        // GET: Comentarios
        public ActionResult Index() {
            var comentario = db.Comentario.Include(c => c.ID_Filme).Include(c => c.ID_User);
            return View(comentario.ToList());
        }

        // GET: Comentarios/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null) {
                return HttpNotFound();
            }
            return View(comentario);
        }

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
        public ActionResult Create([Bind(Include = "ID,Texto")] Comentario comentario, string user, int filme) {
            

            var userIDList =  db.Utilizadores.Where(u => u.NomeUtilizador.Equals(user));
            var userID = 0;
            foreach (var item in userIDList) {
              userID = item.ID;
            }
            comentario.UserFK = userID;
            comentario.FilmeFK = filme;
            comentario.DataComentario = DateTime.Now;




            if (ModelState.IsValid) {
                db.Comentario.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Details/"+filme, "Filmes");
            }

            ViewBag.FilmeFK = new SelectList(db.Filmes, "ID", "Titulo", comentario.FilmeFK);
            ViewBag.UserFK = new SelectList(db.Utilizadores, "ID", "NomeUtilizador", comentario.UserFK);
            return View(comentario);
        }

        // GET: Comentarios/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null) {
                return HttpNotFound();
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

        // GET: Comentarios/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null) {
                return HttpNotFound();
            }
            return View(comentario);
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
    }
}
