/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/27/2008
 */

namespace YatesMorrison.RolePlay.BattleFramework
{
	public interface IController
	{
		// Contains logic that reacts to changes in the model
		void Update();

		// Contains a reference to the view
		IView View { get; }
	}
}