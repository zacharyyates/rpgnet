/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1.31.2009
 */
namespace YatesMorrison.RolePlay
{
	using System;

	[Serializable]
	public class Advance : IChildOf<Attribute>, IChildOf<Actor>
	{
		public string AttributeName { get; set; }
		public Attribute Attribute { get; set; }
		public double Value { get; set; }
		public bool IsActive { get; set; }

		public void AddTo(Attribute parent)
		{
			Attribute = parent;
			IsActive = true;
		}
		public void RemoveFrom(Attribute parent)
		{
			Attribute = null;
			IsActive = false;
		}

		public void AddTo(Actor parent)
		{
			var attrib = parent.GetAspectByName(AttributeName) as Attribute;
			attrib.Add(this);
		}
		public void RemoveFrom(Actor parent)
		{
			var attrib = parent.GetAspectByName(AttributeName) as Attribute;
			attrib.Remove(this);
		}
	}
}