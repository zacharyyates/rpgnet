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
	using YatesMorrison.Linq;
	using YatesMorrison.RolePlay;
	using YatesMorrison.IO;

	[HandleError]
	public class CharacterController : Controller
	{
		public ActionResult Index(Guid? id)
		{
			if (id.HasValue)
			{
				Character character = null;
				using (var repository = MvcApplication.RepositoryFactory.Create<CharacterInstance>())
				{
					var charData = repository.Single(c => c.Id == id.Value);
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

			using (var repository = MvcApplication.RepositoryFactory.Create<CharacterInstance>())
			{
				var charInstance = repository.Create();
				charInstance.Id = Guid.NewGuid();
				charInstance.Name = character.Name;
				charInstance.Data = character.ToBinary().Compress();
				
				repository.SubmitChanges();
				return RedirectToAction("Index", new { id = charInstance.Id });
			}
		}

		[AcceptVerbs("GET")]
		public ActionResult Edit(Guid? id)
		{
			if (id.HasValue)
			{
				Character character = null;
				using (var repository = MvcApplication.RepositoryFactory.Create<CharacterInstance>())
				{
					var charInstance = repository.Single(c => c.Id == id.Value);
					character = charInstance.Data.Decompress().ToInstance<Character>();
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