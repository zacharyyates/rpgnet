using System.Web.Mvc;
using Rpg.Web.Controllers;
using YatesMorrison.Rpg.Dnd4;

namespace Rpg.Web.Views.Character
{
	public partial class Full : ViewPage<CharacterControllerViewData>
	{
		protected Dnd4Character Character
		{
			get { return ViewData.Model.CharacterDto.Character; }
		}
	}
}
