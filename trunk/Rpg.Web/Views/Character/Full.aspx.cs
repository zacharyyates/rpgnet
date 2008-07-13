using System;
using System.Web.Mvc;
using Rpg.Web.Controllers;
using YatesMorrison.Rpg.Dnd4;

namespace Rpg.Web.Views.Character
{
	public partial class Full : ViewPage<CharacterControllerViewData>
	{
		protected void Page_Load( object sender, EventArgs e )
		{
			AverageCount++;
			TotalOfAverages += Character.AverageAbilityScore;
		}

		protected Dnd4Character Character
		{
			get { return ViewData.Model.CharacterDto.Character; }
		}

		protected static double TotalOfAverages { get; set; }
		protected static double AverageCount { get; set; }
	}
}
