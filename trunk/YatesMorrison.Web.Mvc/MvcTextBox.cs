/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * @source http://www.codeproject.com/KB/custom-controls/MVCCustomControls.aspx
 * @author Andrew Gunn
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
	using System;
	using System.IO;
	using System.Web.Mvc;
	using YatesMorrison.UI;

	public class MvcTextBox : MvcInput, ITextControl
	{
		#region MvcControlBuilder Members

		protected override void RenderHtml(StringWriter writer, ViewContext viewContext)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}

			if (viewContext == null)
			{
				throw new ArgumentNullException("viewContext");
			}

			MvcControlHelper.RenderWatermarkScript(writer, viewContext, ID, Name, WatermarkedCssClass, WatermarkText);
		}

		#endregion

		public int Columns
		{
			set { Attributes.Merge("size", value.ToString()); }
		}
		public string MaximumLength
		{
			set { Attributes.Merge("maxlength", value); }
		}

		public string WatermarkedCssClass { get; set; }

		public string WatermarkText { get; set; }

		public object Value
		{
			set { Attributes.Merge("value", value); }
		}

		public MvcTextBox(string name)
			: base(InputType.Text, name)
		{
			WatermarkedCssClass = "input-watermarked";
		}

		#region ITextControl Members

		public string Text
		{
			get { return string.Empty; } // todo: revisit this later, will we ever need to get values from MVC controls? probably not
			set { Value = value; }
		}

		#endregion
	}
}