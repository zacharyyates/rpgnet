﻿/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.20.2009
 */
namespace YatesMorrison.UI
{
	using System;

	public interface IDateTimeControl : IValueControl // todo: add a IValueControl<T> interface?
	{
		DateTime Value { get; set; }
	}
}