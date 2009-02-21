/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.20.2009
 */
namespace YatesMorrison.UI
{
	using System.Collections.Generic;

	public interface IControl
	{
		string Name { get; set; }
		string Field { get; set; }
		bool IsEnabled { get; set; }
		bool IsVisible { get; set; }

		IList<IControl> Controls { get; }
	}
}