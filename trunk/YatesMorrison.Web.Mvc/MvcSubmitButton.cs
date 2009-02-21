/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * @source http://www.codeproject.com/KB/custom-controls/MVCCustomControls.aspx
 * @author Andrew Gunn
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
	public class MvcSubmitButton : MvcInput
	{
		public object Value
		{
			set { Attributes.Merge("value", value); }
		}

		public MvcSubmitButton(string name)
			: base(InputType.Submit, name) { }
	}
}