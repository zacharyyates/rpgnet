/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software Company
 * 6/29/2008
 */

using System.Web.Mvc;

namespace Rpg.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            ViewData["Title"] = "About Page";

            return View();
        }
    }
}