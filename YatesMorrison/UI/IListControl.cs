/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.20.2009
 */
namespace YatesMorrison.UI
{
	using System.Collections.Generic;

	public interface IListControl : IValueControl
	{
		IList<IListItem> Selected { get; }
		IList<IListItem> Items { get; }
		bool IsMultiSelectEnabled { get; set; }
	}

	public interface IListItem
	{
		string Text { get; set; }
		string Value { get; set; }
		bool IsSelected { get; set; }
	}
}