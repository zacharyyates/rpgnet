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

	public class MvcTextArea : MvcControl
	{
		#region MvcControlBuilder Members

		protected override void RenderHtml(StringWriter writer, ViewContext viewContext)
		{
			if (writer == null) { throw new ArgumentNullException("writer"); }
			if (viewContext == null) { throw new ArgumentNullException("viewContext"); }

			MvcControlHelper.RenderWatermarkScript(writer, viewContext, ID, Name, WatermarkedCssClass, WatermarkText);
		}

		#endregion

		#region MvcControl Members

		protected override void Initialise(ViewContext viewContext)
		{
			if (viewContext == null)
			{
				throw new ArgumentNullException("viewContext");
			}

			ViewDataDictionary viewData = viewContext.ViewData;

			if (viewData == null)
			{
				throw new ArgumentNullException("viewData");
			}

			string attemptedValue = viewData.GetModelAttemptedValue(Name);

			Value = attemptedValue ?? viewData.EvalString(Name);

			ModelState modelState;

			if (viewData.ModelState.TryGetValue(Name, out modelState))
			{
				if (modelState.Errors.Count > 0)
				{
					AddClass(InvalidCssClass);
				}
			}
		}

		#endregion

		private int Columns
		{
			set { Attributes.Merge("cols", value); }
		}

		public string InvalidCssClass { get; set; }

		public bool IsDisabled
		{
			set
			{
				if (value)
				{
					Attributes.Merge("disabled", "disabled");
				}
				else
				{
					Attributes.Remove("disabled");
				}
			}
		}

		public bool IsReadOnly
		{
			set
			{
				if (value)
				{
					Attributes.Merge("readonly", "readonly");
				}
				else
				{
					Attributes.Remove("readonly");
				}
			}
		}

		protected string Name
		{
			get { return Attributes.GetValue("name"); }
			private set { Attributes.Merge("name", value); }
		}

		private int Rows
		{
			set { Attributes.Merge("rows", value); }
		}

		public string WatermarkedCssClass { get; set; }

		public string WatermarkText { get; set; }

		public object Value
		{
			set { SetInnerText(value); }
		}

		public MvcTextArea(string name, int rows, int columns)
			: base("textarea")
		{
			Columns = columns;
			ID = name;
			InvalidCssClass = "input-validation-error";
			Name = name;
			Rows = rows;
			WatermarkedCssClass = "input-watermarked";
		}
	}
}