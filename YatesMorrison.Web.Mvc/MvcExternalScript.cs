/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * @source http://www.codeproject.com/KB/custom-controls/MVCCustomControls.aspx
 * @author Andrew Gunn
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
	public class MvcExternalScript : MvcScript
	{
		protected string Uri
		{
			set { Attributes.Merge("src", value); }
		}

		public MvcExternalScript(ScriptType type, string uri)
			: base(type, null)
		{
			Uri = uri;
		}
	}
}