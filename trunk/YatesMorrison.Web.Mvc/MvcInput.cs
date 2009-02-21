/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * @source http://www.codeproject.com/KB/custom-controls/MVCCustomControls.aspx
 * @author Andrew Gunn
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
	using System;
	using System.Web.Mvc;

	public abstract class MvcInput : MvcEventAttributes
	{
		#region MvcControlBuilder Members

		protected override void Initialise(ViewContext viewContext)
		{
			if (viewContext == null) { throw new ArgumentNullException("viewContext"); }
			ViewDataDictionary viewData = viewContext.ViewData;
			if (viewData == null) { throw new ArgumentNullException("viewData"); }

			string attemptedValue = viewData.GetModelAttemptedValue(Name);

			if (Type == InputType.CheckBox)
			{
				if (!string.IsNullOrEmpty(attemptedValue))
				{
					bool isChecked;

					// The attempted value will be "true,false" or "false" - split to be on the safe side.
					string[] attemptedValues = attemptedValue.Split(',');

					if (bool.TryParse(attemptedValues[0], out isChecked))
					{
						if (isChecked)
						{
							Attributes["checked"] = "checked";
						}
						else
						{
							Attributes.Remove("checked");
						}
					}
				}
			}
			else if (Type == InputType.RadioButton)
			{
				if (!string.IsNullOrEmpty(attemptedValue))
				{
					string value = Attributes.GetValue("value");

					if (value.Equals(attemptedValue, StringComparison.InvariantCultureIgnoreCase))
					{
						Attributes["checked"] = "checked";
					}
					else
					{
						Attributes.Remove("checked");
					}
				}
			}
			else if (Type != InputType.File)
			{
				if (attemptedValue != null)
				{
					Attributes["value"] = attemptedValue;
				}
				else if (viewData[Name] != null)
				{
					Attributes["value"] = viewData.EvalString(Name);
				}
			}

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

		protected string Name
		{
			get { return Attributes.GetValue("name"); }
			private set { Attributes.Merge("name", value); }
		}

		public string InvalidCssClass { get; set; }

		protected virtual bool IsIDRequired
		{
			get { return Type != InputType.RadioButton; }
		}

		protected InputType Type
		{
			get { return MvcControlHelper.GetInputTypeEnum(Attributes.GetValue("type")); }
			set { Attributes["type"] = MvcControlHelper.GetInputTypeString(value); }
		}

		public MvcInput(InputType type, string name)
			: base("input", TagRenderMode.SelfClosing)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Value cannot be null or empty.", "name");
			}

			Type = type;

			// Don't set the "id" attribute for certain controls because 2 or more could share the same name (e.g. radio buttons).
			if (IsIDRequired)
			{
				ID = name;
			}

			InvalidCssClass = "input-validation-error";
			Name = name;
		}
	}
}