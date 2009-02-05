/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 1.30.2009
 */
namespace YatesMorrison.Entropy.Web.Controllers
{
	using System;
	using System.Linq;
	using System.Web.Mvc;
	using YatesMorrison.Entropy.Data;
	using YatesMorrison.IO;
	using YatesMorrison.Linq;
	using YatesMorrison.RolePlay;

	[HandleError]
	public class CharacterController : Controller
	{
		public ActionResult Index(Guid? id)
		{
			if (id.HasValue)
			{
				Character character = null;
				using (EntropyDataContext dc = new EntropyDataContext())
				{
					var charData = dc.CharacterDatas.Single(c => c.Id == id.Value);
					character = charData.Data.Decompress().ToInstance<Character>();
				}
				return View(character);
			}
			return RedirectToAction("List");
		}

		public ActionResult Create()
		{
			Character character = CharacterFactory.Create();
			character.Name = "New Character";

			CharacterData charData = new CharacterData();
			charData.Id = Guid.NewGuid();
			charData.Name = character.Name;
			charData.Data = character.ToBinary().Compress();
	
			using (EntropyDataContext dc = new EntropyDataContext())
			{
				dc.CharacterDatas.InsertOnSubmit(charData);
				dc.SubmitChanges();
			}
			return RedirectToAction("Index", new { id = charData.Id });
		}

		[AcceptVerbs("GET")]
		public ActionResult Edit(Guid? id)
		{
			if (id.HasValue)
			{
				Character character = null;
				using (EntropyDataContext dc = new EntropyDataContext())
				{
					var charData = dc.CharacterDatas.Single(c => c.Id == id.Value);
					character = charData.Data.Decompress().ToInstance<Character>();
				}
				return View(character);
			}
			return RedirectToAction("List");
		}

		//[AcceptVerbs("POST")]
		//public ActionResult Edit(Guid? id, FormCollection form)
		//{
		//    if (id.HasValue)
		//    {
		//        Character character = null;
		//        using (EntropyDataContext dc = new EntropyDataContext())
		//        {
		//            var charData
		//        }
		//    }
		//    RedirectToAction("Edit");
		//}
	}
}