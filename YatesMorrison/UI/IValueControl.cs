﻿/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.20.2009
 */
namespace YatesMorrison.UI
{
	public interface IValueControl : IControl
	{
		bool ValueChanged { get; set; }
	}
}