using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace YatesMorrison.Entropy.Web.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewData["Title"] = "Entropy";
			ViewData["Message"] = "Entropy Character System";

			return View();
		}

		public ActionResult About()
		{
			ViewData["Title"] = "Entropy - About";

			return View();
		}
	}
}
