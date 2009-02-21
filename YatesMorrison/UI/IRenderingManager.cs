/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.20.2009
 */
namespace YatesMorrison.UI
{
	using System.Collections.Generic;

	public interface IRenderingManager // todo: add some sort of layout manager
	{
		IList<IControl> Controls { get; }
		void Render();
	}
}