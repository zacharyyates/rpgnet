using System.Web.Mvc;
using Rpg.Web.Controllers;
using YatesMorrison.Rpg.Dnd4;

namespace Rpg.Web.Views.Character
{
	public partial class Dnd4Classic : ViewPage<CharacterControllerViewData>
	{
		protected Dnd4Character Character
		{
			get { return ViewData.Model.CharacterDto.Character; }
		}
	}
}