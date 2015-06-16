using System.Web.Mvc;
using DAL;

namespace tmac.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            using (var db = new BlogContext())
            {
                db.Blogs.Add(new Blog {Name = "Hello World"});
                db.SaveChanges();
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}