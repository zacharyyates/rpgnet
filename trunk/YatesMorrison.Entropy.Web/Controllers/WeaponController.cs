using System.Web.Mvc;

namespace YatesMorrison.Entropy.Web.Controllers
{
    public class WeaponController : Controller
    {
        //
        // GET: /Weapon/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Weapon/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Weapon/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Weapon/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Weapon/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Weapon/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
