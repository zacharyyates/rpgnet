/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 7/6/2008
 */

using System.Web.Mvc;
using Rpg.Web.Models;
using YatesMorrison.Rpg;
using YatesMorrison.Rpg.Dnd4;

namespace Rpg.Web.Controllers
{
	public class CharacterControllerViewData
	{
		public int CharacterId { get; set; }
		public CharacterDto CharacterDto { get; set; }
	}

	public class CharacterController : Controller
	{
		/// <summary>
		/// Shows the character sheet view
		/// </summary>
		public ActionResult Index()
		{
			// Retrieve the character
			CharacterDto dto = CharacterMocker.Create();
			return View("Full", new CharacterControllerViewData { CharacterDto = dto });
		}

		public ActionResult New()
		{
			// Create a new character in the database
			Character character = new Character();
			return null;
		}
	}
}