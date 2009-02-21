/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * @source http://www.codeproject.com/KB/custom-controls/MVCCustomControls.aspx
 * @author Andrew Gunn
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
	using System;

	public class MvcRadioButton : MvcInput
	{
		public bool Checked
		{
			set
			{
				if (value)
				{
					Attributes["checked"] = "checked";
				}
				else
				{
					Attributes.Remove("checked");
				}
			}
		}

		public object Value
		{
			set { Attributes.Merge("value", value); }
		}

		public MvcRadioButton(string name, object value)
			: base(InputType.RadioButton, name)
		{
			if (value == null) { throw new ArgumentNullException("value"); }

			Value = value;
		}
	}
}