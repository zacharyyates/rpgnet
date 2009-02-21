/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * @source http://www.codeproject.com/KB/custom-controls/MVCCustomControls.aspx
 * @author Andrew Gunn
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
	using System.Web.Mvc;

	public class MvcEndForm : MvcControl
	{
		public MvcEndForm()
			: base("form", TagRenderMode.EndTag) { }
	}
}