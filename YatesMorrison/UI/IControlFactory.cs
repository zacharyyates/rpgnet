/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.20.2009
 */
namespace YatesMorrison.UI
{
	using System;

	public interface IControlFactory
	{
		IControl Create(Type type, string name);
		T Create<T>(string name) where T : class, IControl, new();
	}
}