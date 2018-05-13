using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CineRating.Models;

namespace CineRating.Controllers {
    public class RealizadoresController : Controller {
        private CineRatingDb db = new CineRatingDb();

        // GET: Realizadores
        public ActionResult Index(string pesq) {

            var realizador = db.Realizadores;
            if (String.IsNullOrEmpty(pesq)) {
                return View(realizador.ToList());
            }
            return View(realizador.Where(p => p.Nome.ToUpper().Contains(pesq.ToUpper())).ToList());
        }
    


        // GET: Realizadores/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realizadores realizadores = db.Realizadores.Find(id);
            if (realizadores == null) {
                return HttpNotFound();
            }
            return View(realizadores);
        }

        // GET: Realizadores/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Realizadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,DataNascimento,Biografia")] Realizadores realizadores, HttpPostedFileBase fileUploadImagem) {


            //vars aux
            string nomeImagem = "realizador" + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + ".jpg";
            string caminhoParaImagem = Path.Combine(Server.MapPath("~/imagens/realizadores"), nomeImagem); //indica onde a imagem será guardada

            //verificar se chega efetivamente um ficheiro ao servidor
            if ((fileUploadImagem != null) && (fileUploadImagem.ContentType.ToString() == "image/jpeg")) {
                //guardar o nome da imagem na BD
                realizadores.Imagem = nomeImagem;
            } else {
                // não há imagem...
                ModelState.AddModelError("", "Não foi fornecida uma imagem ou o ficheiro inserido não é JPG");
                return View(realizadores);
            }



            if (ModelState.IsValid) {
                db.Realizadores.Add(realizadores);
                db.SaveChanges();

                fileUploadImagem.SaveAs(caminhoParaImagem);

                return RedirectToAction("Index");
            }

            return View(realizadores);
        }

        // GET: Realizadores/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realizadores realizadores = db.Realizadores.Find(id);
            if (realizadores == null) {
                return HttpNotFound();
            }
            return View(realizadores);
        }

        // POST: Realizadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,DataNascimento,Biografia,Imagem")] Realizadores realizadores, HttpPostedFileBase fileUploadImagem) {

            //falta tratar das imagens, como feito no CREATE
            //var. auxiliar
            string nomeImagem = "relizador" + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + ".jpg";
            string oldName = realizadores.Imagem;
            string caminhoParaImagem = Path.Combine(Server.MapPath("~/imagens/realizadores"), nomeImagem); //indica onde a imagem será guardada

            //verificar se chega efetivamente um ficheiro ao servidor
            //verificar se chega efetivamente um ficheiro ao servidor
            if ((fileUploadImagem != null) && (fileUploadImagem.ContentType.ToString() == "image/jpeg")) {
                //guardar o nome da imagem na BD
                realizadores.Imagem = nomeImagem;
            }


            if (ModelState.IsValid) {
                db.Entry(realizadores).State = EntityState.Modified;
                db.SaveChanges();

                if (fileUploadImagem != null) {
                    //guardar o nome da imagem na BD
                    fileUploadImagem.SaveAs(caminhoParaImagem);
                    System.IO.File.Delete(Path.Combine(Server.MapPath("~/imagens/atores"), oldName));
                }

                return RedirectToAction("Index");
            }
            return View(realizadores);
        }

        // GET: Realizadores/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realizadores realizadores = db.Realizadores.Find(id);
            if (realizadores == null) {
                return HttpNotFound();
            }
            return View(realizadores);
        }

        // POST: Realizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Realizadores realizadores = db.Realizadores.Find(id);
            try {
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/imagens/realizadores"), realizadores.Imagem));
                db.Realizadores.Remove(realizadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            } catch (Exception) {
                ModelState.AddModelError("", string.Format("Não foi possível remover o ator porque existem filmes associados a ele"));
            }
            return View(realizadores);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
