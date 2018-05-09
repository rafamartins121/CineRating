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
    public class AtoresController : Controller {
        private CineRatingDb db = new CineRatingDb();

        // GET: Atores
        public ActionResult Index() {

            var aux = Convert.ToInt32(Session["atorID"]);
            if (aux != 0) {
                var ator = db.Atores.Where(a => a.ID.Equals(aux));
                Session["atorID"] = 0;
                return View(ator.ToList());
            }
            return View(db.Atores.ToList());
        }

        // GET: Atores/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atores atores = db.Atores.Find(id);
            if (atores == null) {
                return HttpNotFound();
            }
            return View(atores);
        }

        // GET: Atores/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Atores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,DataNascimento,Biografia")] Atores atores, HttpPostedFileBase fileUploadImagem) {

            //vars aux
            string nomeImagem = "ator" + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + ".jpg";
            string caminhoParaImagem = Path.Combine(Server.MapPath("~/imagens/atores"), nomeImagem); //indica onde a imagem será guardada

            //verificar se chega efetivamente um ficheiro ao servidor
            if ((fileUploadImagem != null) && (fileUploadImagem.ContentType.ToString() == "image/jpeg")) {
                //guardar o nome da imagem na BD
                atores.Imagem = nomeImagem;
            } else {
                // não há imagem...
                ModelState.AddModelError("", "Não foi fornecida uma imagem ou o ficheiro inserido não é JPG");
                return View(atores);
            }


            if (ModelState.IsValid) {
                db.Atores.Add(atores);
                db.SaveChanges();

                fileUploadImagem.SaveAs(caminhoParaImagem);

                return RedirectToAction("Index");
            }

            return View(atores);
        }

        // GET: Atores/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atores atores = db.Atores.Find(id);
            if (atores == null) {
                return HttpNotFound();
            }
            return View(atores);
        }

        // POST: Atores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,DataNascimento,Biografia,Imagem")] Atores atores, HttpPostedFileBase fileUploadImagem) {

            //falta tratar das imagens, como feito no CREATE
            //var. auxiliar
            string nomeImagem = "ator" + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + ".jpg";
            string oldName = atores.Imagem;
            string caminhoParaImagem = Path.Combine(Server.MapPath("~/imagens/atores"), nomeImagem); //indica onde a imagem será guardada

            //verificar se chega efetivamente um ficheiro ao servidor
            //verificar se chega efetivamente um ficheiro ao servidor
            if ((fileUploadImagem != null) && (fileUploadImagem.ContentType.ToString() == "image/jpeg")) {
                //guardar o nome da imagem na BD
                atores.Imagem = nomeImagem;
            }


            if (ModelState.IsValid) {
                db.Entry(atores).State = EntityState.Modified;
                db.SaveChanges();


                if (fileUploadImagem != null) {
                    //guardar o nome da imagem na BD
                    fileUploadImagem.SaveAs(caminhoParaImagem);
                    System.IO.File.Delete(Path.Combine(Server.MapPath("~/imagens/atores"), oldName));
                }
 
                return RedirectToAction("Index");
            }
            return View(atores);
        }

        // GET: Atores/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }
            Atores atores = db.Atores.Find(id);
            if (atores == null) {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            return View(atores);
        }

        // POST: Atores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Atores atores = db.Atores.Find(id);
            try {
                db.Atores.Remove(atores);
                db.SaveChanges();
                return RedirectToAction("Index");
            } catch (Exception) {
                ModelState.AddModelError("", string.Format("Não foi possível remover o ator porque existem filmes associados a ele"));
            }
            return View(atores);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
