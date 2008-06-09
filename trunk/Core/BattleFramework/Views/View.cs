/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/27/2008
 */

namespace YatesMorrison.RolePlay.BattleFramework
{
	/// <summary>
	/// Base interface for all of the different views of the grid, DM, PC, AI, etc...
	/// </summary>
	public interface IView
	{
		// Contains logic that renders the view to the display
		//void Render();
		string ActorId { get; set; }

		// Contains a reference to the model
		World World { get; }
	}
}