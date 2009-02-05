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
	public class Attribute : Aspect, IParentOf<DerivedAttribute>, IParentOf<Advance>
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

		#region Advances

		public void Add(Advance child)
		{
			m_Advances.Add(child);
			child.AddTo(this);
		}
		public void Remove(Advance child)
		{
			m_Advances.Remove(child);
			child.RemoveFrom(this);
		}

		public ReadOnlyCollection<Advance> Advances
		{
			get { return new ReadOnlyCollection<Advance>(m_Advances); }
		}
		List<Advance> m_Advances = new List<Advance>();

		public double AdvanceTotal
		{
			get { return Advances.Where(a => a.IsActive).Sum(a => a.Value); }
		}

		#endregion

		#region Derived

		public void Add(DerivedAttribute child)
		{
			m_Derived.Add(child);
			child.AddTo(this);
		}
		public void Remove(DerivedAttribute child)
		{
			child.RemoveFrom(this);
			m_Derived.Remove(child);
		}

		public ReadOnlyCollection<DerivedAttribute> Derived
		{
			get { return new ReadOnlyCollection<DerivedAttribute>(m_Derived); }
		}
		List<DerivedAttribute> m_Derived = new List<DerivedAttribute>();

		#endregion
	}
}