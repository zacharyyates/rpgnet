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

	public class MvcValidationMessage : MvcControl
	{
		#region MvcControlBuilder Members

		protected override void Initialize(ViewContext viewContext)
		{
			if (viewContext == null)
			{
				throw new ArgumentNullException("viewContext");
			}

			ViewDataDictionary viewData = viewContext.ViewData;

			if (!viewData.ModelState.ContainsKey(ModelName))
			{
				return;
			}

			ModelErrorCollection modelErrors = viewData.ModelState.GetErrors(ModelName);

			if (modelErrors == null || modelErrors.Count == 0)
			{
				return;
			}

			string errorMessage = string.IsNullOrEmpty(ErrorMessage) ? modelErrors[0].ErrorMessage : ErrorMessage;

			SetInnerText(errorMessage);
			Title = errorMessage;
		}

		#endregion

		protected string ModelName { get; private set; }

		protected string ErrorMessage { get; private set; }

		public MvcValidationMessage(string modelName)
			: this(modelName, null) { }

		public MvcValidationMessage(string modelName, string errorMessage)
			: base("span")
		{
			if (string.IsNullOrEmpty(modelName))
			{
				throw new ArgumentException("Value cannot be null or empty.", "modelName");
			}

			// Set a default CSS class.
			Class = "field-validation-error"; // todo: do we need a default class?

			ModelName = modelName;
			ErrorMessage = errorMessage;
		}
	}
}