/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software Company
 * 7/20/2008 7:04
 */

using System;
using System.Web.Mvc;
using Rpg.Web.Models;

namespace Rpg.Web.Controllers
{
	public class WikiController : Controller
	{
		public ActionResult Index()
		{
			return null;
		}

		public ActionResult Topic(string name)
		{
            if (string.IsNullOrEmpty(name))
            {

            }
            else
            {
                // retrieve key from the database
				var repository = new Repository<Topic>(new WikiModelDataContext());
				var topic = repository.First(w => w.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
				if (topic != null)
				{
					return View("TopicView", topic);
				}
            }
			throw new NotImplementedException();
		}

		public ActionResult Edit(int? id)
		{
			throw new NotImplementedException();
		}

		public ActionResult Delete(int? id)
		{
			throw new NotImplementedException();
		}
	}
}