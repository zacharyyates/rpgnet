/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.1.2009
 */
namespace YatesMorrison.RolePlay
{
	using System;

	[Serializable]
	public class DerivedAttribute : Attribute, IChildOf<Attribute>
	{
		public DerivedAttribute() { }
		public DerivedAttribute(string name, string abbreviation, string description, string parentAttributeName, double initial)
			: base(name, abbreviation, description, initial) 
		{
			ParentAttributeName = parentAttributeName;
		}

		public string ParentAttributeName { get; set; }
		public Attribute Attribute { get; set; }

		public override double Base
		{
			get { return Attribute.Total; }
		}

		public override void AddTo(Actor actor)
		{
			var attrib = actor.GetAspectByName(ParentAttributeName) as Attribute;
			attrib.Add(this);
			base.AddTo(actor);
		}
		public override void RemoveFrom(Actor actor)
		{
			var attrib = actor.GetAspectByName(ParentAttributeName) as Attribute;
			attrib.Remove(this); // todo: implement
			base.RemoveFrom(actor);
		}

		public void AddTo(Attribute parent)
		{
			Attribute = parent;
		}
		public void RemoveFrom(Attribute parent)
		{
			Attribute = parent;
		}
	}
}