using System.Web.Mvc;

namespace CineRating.Controllers {
    public class HomeController : Controller {


        public ActionResult About() {
            ViewBag.Message = "Your app description page.";

            return View();
        }


    }
}
