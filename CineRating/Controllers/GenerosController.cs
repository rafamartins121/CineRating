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
    public class GenerosController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

       

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
