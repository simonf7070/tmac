using System.Web.Mvc;
using DAL.DomainEvents;
using tmac.Models;

namespace tmac.Controllers
{
    public class NetworkAssetController : Controller
    {
        // GET: NetworkAsset
        public ActionResult Index()
        {
            return View();
        }

        // GET: NetworkAsset/Details
        public ActionResult Details()
        {
            var model = Session["NetworkAsset"];
            return View(model);
        }

        // GET: NetworkAsset/Add
        public ActionResult Add()
        {
            var model = new NetworkAsset();
            return View(model);
        }

        // POST: NetworkAsset/Add
        [HttpPost]
        public ActionResult Add(NetworkAsset model)
        {
            if (ModelState.IsValid)
            {
                Session["NetworkAsset"] = model;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: NetworkAsset/Edit
        public ActionResult Edit()
        {
            var model = Session["NetworkAsset"];
            if (model == null)
            {
                model = new NetworkAsset();
            }
            return View(model);
        }

        // POST: NetworkAsset/Edit/5
        [HttpPost]
        public ActionResult Edit(NetworkAsset model)
        {
            if (ModelState.IsValid)
            {
                Session["NetworkAsset"] = model;
                DomainEvents.Raise(new NetworkAssetUpdated { Name = model.Name } );
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
