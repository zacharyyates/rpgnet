/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
	using System;
	using YatesMorrison.UI;

	public class MvcControlFactory : IControlFactory
	{
		public IControl Create(Type type, string name)
		{
			if (type == null) { throw new ArgumentNullException("type"); }
			switch (type.Name)
			{
				case "IButtonControl":		return null;
				case "ICheckBoxControl":	return new MvcCheckBox(name); // todo: make all MvcControls take a parameterless constructor?
				case "ITextControl":		return new MvcTextBox(name);
				default: return null; // todo: add more supported controls
			}
		}

		public T Create<T>(string name) where T : class, IControl, new()
		{
			return Create(typeof(T), name) as T;
		}
	}
}