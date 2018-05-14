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
    public class FilmesController : Controller {
        private CineRatingDb db = new CineRatingDb();


        // GET: Filmes

        public ActionResult Index(string pesq) {
            var filmes = db.Filmes.Include(f => f.Realizador);
            if (String.IsNullOrEmpty(pesq)) {  
                return View (filmes.ToList());
            }
            return View(filmes.Where(p => p.Titulo.ToUpper().Contains(pesq.ToUpper())).ToList());
        }

        // GET: Atores
        public ActionResult FilmeAtores() {

            var aux = Convert.ToInt32(Session["FilmeAtorID"]);
            if (aux != 0) {
                var filme = db.Filmes.Where(a => a.ID.Equals(aux));
                Session["FilmeAtorID"] = 0;
                return View(filme.ToList());
            }
            var filmes = db.Filmes.Include(f => f.Realizador);
            return View(filmes.ToList());
        }

        // GET: Realizadores
        public ActionResult FilmeRealizadores() {

            var aux = Convert.ToInt32(Session["RealizadorID"]);
            if (aux != 0) {
                var filme = db.Filmes.Where(a => a.ID.Equals(aux));
                Session["RealizadorID"] = 0;
                return View(filme.ToList());
            }
            var filmes = db.Filmes.Include(f => f.Realizador);
            return View(filmes.ToList());
        }

        // GET: Filmes/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }
            Filmes filmes = db.Filmes.Find(id);
            if (filmes == null) {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            return View(filmes);
        }

        [Authorize]
        // GET: Filmes/Create
        public ActionResult Create() {
            ViewBag.RealizadorFK = new SelectList(db.Realizadores, "ID", "Nome");
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,Descricao,TempoExecucao,DataLancamento,Video,RealizadorFK")] Filmes filmes, HttpPostedFileBase fileUploadImagem) {

            //vars aux
            string nomeImagem = "filme" + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + ".jpg";
            string caminhoParaImagem = Path.Combine(Server.MapPath("~/imagens/filmes"), nomeImagem); //indica onde a imagem será guardada

            //verificar se chega efetivamente um ficheiro ao servidor
            if ((fileUploadImagem != null) && (fileUploadImagem.ContentType.ToString() == "image/jpeg")) {
                //guardar o nome da imagem na BD
                filmes.Imagem = nomeImagem;
            } else {
                // não há imagem...
                ViewBag.RealizadorFK = new SelectList(db.Realizadores, "ID", "Nome", filmes.RealizadorFK);
                ModelState.AddModelError("", "Não foi fornecida uma imagem ou o ficheiro inserido não é JPG");
                return View(filmes);
            }


            if (ModelState.IsValid) {
                //Insere géneros
                //var l = new List<int> { 1,2,3};
                //filmes.ListaDeGeneros =db.Generos.Where(g => l.Contains(g.ID)).ToList();
                //Insere Géneros
                db.Filmes.Add(filmes);
                db.SaveChanges();

                fileUploadImagem.SaveAs(caminhoParaImagem);

                return RedirectToAction("Index");
            }

            ViewBag.RealizadorFK = new SelectList(db.Realizadores, "ID", "Nome", filmes.RealizadorFK);
            return View(filmes);
        }

        // GET: Filmes/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }
            Filmes filmes = db.Filmes.Find(id);
            if (filmes == null) {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            ViewBag.RealizadorFK = new SelectList(db.Realizadores, "ID", "Nome", filmes.RealizadorFK);
            return View(filmes);
        }

        [Authorize]
        // POST: Filmes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,Descricao,TempoExecucao,DataLancamento,Imagem,Video,RealizadorFK")] Filmes filmes, HttpPostedFileBase fileUploadImagem) {


            //falta tratar das imagens, como feito no CREATE
            //var. auxiliar
            string nomeImagem = "filme" + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + ".jpg";
            string oldName = filmes.Imagem;
            string caminhoParaImagem = Path.Combine(Server.MapPath("~/imagens/filmes"), nomeImagem); //indica onde a imagem será guardada

            //verificar se chega efetivamente um ficheiro ao servidor
            //verificar se chega efetivamente um ficheiro ao servidor
            if ((fileUploadImagem != null) && (fileUploadImagem.ContentType.ToString() == "image/jpeg")) {
                //guardar o nome da imagem na BD
                filmes.Imagem = nomeImagem;
            }



            if (ModelState.IsValid) {
                db.Entry(filmes).State = EntityState.Modified;
                db.SaveChanges();

                if (fileUploadImagem != null) {
                    //guardar o nome da imagem na BD
                    fileUploadImagem.SaveAs(caminhoParaImagem);
                    System.IO.File.Delete(Path.Combine(Server.MapPath("~/imagens/filmes"), oldName));
                }
                return RedirectToAction("Index");
            }
            ViewBag.RealizadorFK = new SelectList(db.Realizadores, "ID", "Nome", filmes.RealizadorFK);
            return View(filmes);
        }

        [Authorize]
        // GET: Filmes/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }
            Filmes filmes = db.Filmes.Find(id);
            if (filmes == null) {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }  
            return View(filmes);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Filmes filmes = db.Filmes.Find(id); 
            try {               
                db.Filmes.Remove(filmes);
                db.SaveChanges();
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/imagens/filmes"), filmes.Imagem));
                return RedirectToAction("Index");
            } catch (Exception) {
                ModelState.AddModelError("", string.Format("Não foi possível remover o filme porque existem atores associados a ele"));
            }
            //PROBLEMA ao falhar a remover o realizador desaparece
            //ViewBag.RealizadorFK = new SelectList(db.Realizadores, "ID", "Nome", filmes.RealizadorFK);
            return View(filmes);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GetFilmes(string term) {
            return Json(db.Filmes.Where(c => c.Titulo.StartsWith(term)).Select(a => new { label = a.Titulo }), JsonRequestBehavior.AllowGet);
        }
    }
}