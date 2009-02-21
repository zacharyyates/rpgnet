/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.20.2009
 */
namespace YatesMorrison.UI
{
	using System.Collections.Generic;

	public interface IControl
	{
		string ID { get; set; }
		// todo: are these necessary?
		//bool IsEnabled { get; set; }
		//bool IsVisible { get; set; }

		//IList<IControl> Controls { get; }
	}
}