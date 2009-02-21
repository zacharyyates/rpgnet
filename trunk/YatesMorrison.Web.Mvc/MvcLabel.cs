/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * @source http://www.codeproject.com/KB/custom-controls/MVCCustomControls.aspx
 * @author Andrew Gunn
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
	public class MvcLabel : MvcControl
	{
		private string AssociatedControlID
		{
			set { Attributes.Merge("for", value); }
		}

		protected string Text
		{
			get { return InnerHtml; }
			private set { InnerHtml = value; }
		}

		public MvcLabel(string associatedControlID, string text)
			: base("label")
		{
			AssociatedControlID = associatedControlID;
			Text = text;
		}
	}
}