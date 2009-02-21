/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.20.2009
 */
namespace YatesMorrison.UI
{
	using System.Collections.Generic;

	public interface IScaffoldingManager // todo: find a better name for this class?
	{
		IList<IControl> GetEntityView();
	}
}