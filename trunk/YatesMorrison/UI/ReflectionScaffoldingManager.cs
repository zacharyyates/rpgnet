/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.20.2009
 */
namespace YatesMorrison.UI
{
	using System;
	using System.Collections.Generic;
	using System.Reflection;

	public class ReflectionScaffoldingManager : IScaffoldingManager
	{
		public ReflectionScaffoldingManager(Type type, IControlFactory controlFactory) // todo: add an abstract base class for this?
		{
			if (type == null) { throw new NullReferenceException("Parameter 'type' must not be null"); }
			if (controlFactory == null) { throw new NullReferenceException("Parameter 'controlFactory' must have a value"); }
			m_Type = type;
			m_ControlFactory = controlFactory;
		}

		Type m_Type;
		IControlFactory m_ControlFactory;

		public IList<IControl> GetEntityView()
		{
			List<IControl> controls = new List<IControl>();
			// build a list of controls based on the public properties of m_Type
			var properties = m_Type.GetProperties();
			foreach (var property in properties)
			{
				var controlType = GetControlType(property.PropertyType);
				if (controlType != null)
				{
					var control = m_ControlFactory.Create(controlType, property.Name);
					// todo: add more control initialization based on custom attributes on the entity?
					controls.Add(control);
				}
			}
			return controls;
		}

		protected Type GetControlType(Type fieldType)
		{
			switch (fieldType.FullName)
			{
				case "System.String": return typeof(ITextControl);
				case "System.Boolean": return typeof(ICheckBoxControl);
				case "System.DateTime": return typeof(IDateTimeControl);
				
				default: return null;
			}
		}
	}
}