/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.1.2009
 */
namespace YatesMorrison.RolePlay
{
	using System;

	[Serializable]
	public class DerivedAttribute : Attribute
	{
		public DerivedAttribute() { }
		public DerivedAttribute(string name, string abbreviation, string description, string parentAttributeName, double initial)
			: base(name, abbreviation, description, initial) 
		{
			ParentAttributeName = parentAttributeName;
		}

		public string ParentAttributeName { get; set; }
		public Attribute Parent { get; set; }

		public override double Base
		{
			get { return Parent.Total; }
		}
	}
}