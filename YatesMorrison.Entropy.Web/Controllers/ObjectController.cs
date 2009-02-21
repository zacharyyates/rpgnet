/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 1.30.2009
 */
namespace YatesMorrison.Entropy.Web.Controllers
{
	using System.Web.Mvc;
	using YatesMorrison.RolePlay;

	[HandleError]
	public class ObjectController : Controller
	{
		public ActionResult Index()
		{
			return View(new Actor());
		}

		//public ActionResult Index(Guid? id)
		//{
		//    if (id.HasValue)
		//    {
		//        Actor actor = null;
		//        using (var repository = MvcApplication.RepositoryFactory.Create<ObjectTemplate>())
		//        {
		//            var objTemplate = repository.Single(c => c.Id == id.Value);
		//            actor = objTemplate.Data.Decompress().ToInstance<Character>();
		//        }
		//        return View(actor);
		//    }
		//    return RedirectToAction("List");
		//}

		//public ActionResult Create()
		//{
		//    Character character = CharacterFactory.Create();
		//    character.Name = "New Object";

		//    using (var repository = MvcApplication.RepositoryFactory.Create<CharacterInstance>())
		//    {
		//        var charInstance = repository.Create();
		//        charInstance.Id = Guid.NewGuid();
		//        charInstance.Name = character.Name;
		//        charInstance.Data = character.ToBinary().Compress();

		//        repository.SubmitChanges();
		//        return RedirectToAction("Index", new { id = charInstance.Id });
		//    }
		//}

		//[AcceptVerbs("GET")]
		//public ActionResult Edit(Guid? id)
		//{
		//    if (id.HasValue)
		//    {
		//        Character character = null;
		//        using (var repository = MvcApplication.RepositoryFactory.Create<CharacterInstance>())
		//        {
		//            var charInstance = repository.Single(c => c.Id == id.Value);
		//            character = charInstance.Data.Decompress().ToInstance<Character>();
		//        }
		//        return View(character);
		//    }
		//    return RedirectToAction("List");
		//}
	}
}