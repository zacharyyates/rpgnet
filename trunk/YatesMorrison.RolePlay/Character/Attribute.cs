/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software Company
 * 1.31.2009
 */
namespace YatesMorrison.RolePlay
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;

	[Serializable]
	public class Attribute : Aspect
	{
		public Attribute() { }
		public Attribute(string name, string abbreviation, string description, double initial)
		{
			Name = name;
			Abbreviation = abbreviation;
			Description = description;
			if (initial != 0)
			{
				Add(new Advance() { AttributeName = name, IsActive = true, Value = initial });
			}
		}

		public override double Normal
		{
			get { return Base + AdvanceTotal; }
		}
		public override double Total
		{
			get { return Normal + ModifierTotal; }
		}

		public ReadOnlyCollection<Advance> Advances
		{
			get { return new ReadOnlyCollection<Advance>(m_Advances); }
		}
		List<Advance> m_Advances = new List<Advance>();

		public void Add(Advance advance)
		{
			m_Advances.Add(advance);
			advance.Attribute = this;
			advance.IsActive = true;
		}

		public double AdvanceTotal
		{
			get { return Advances.Where(a => a.IsActive).Sum(a => a.Value); }
		}

		public ReadOnlyCollection<DerivedAttribute> Children
		{
			get { return new ReadOnlyCollection<DerivedAttribute>(m_Children); }
		}
		List<DerivedAttribute> m_Children = new List<DerivedAttribute>();

		public void Add(DerivedAttribute child)
		{
			m_Children.Add(child);
			child.Parent = this;
		}
	}
}