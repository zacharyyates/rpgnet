/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * @source http://www.codeproject.com/KB/custom-controls/MVCCustomControls.aspx
 * @author Andrew Gunn
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
	public class MvcHidden : MvcInput
	{
		public MvcHidden(string name) :
			base(InputType.Hidden, name) { }
	}
}