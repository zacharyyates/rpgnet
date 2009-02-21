/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.20.2009
 */
namespace YatesMorrison.UI
{
	public interface IButtonControl : IControl
	{
		string Text { get; set; }
		// todo: add some sort of action property
	}
}