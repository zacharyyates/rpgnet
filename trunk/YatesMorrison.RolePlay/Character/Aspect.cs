/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.3.2009
 */
namespace YatesMorrison.RolePlay
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;

	[Serializable]
	public class Aspect : IChildOf<Actor>, IParentOf<Modifier>
	{
		public Aspect() { }
		public Aspect(string name, string abbreviation, string description, double initial)
		{
			Name = name;
			Abbreviation = abbreviation;
			Description = description;
			m_Base = initial;
		}

		public string Name { get; set; }
		public string Abbreviation { get; set; }
		public string Description { get; set; }
		
		public Actor Actor { get; set; }

		public virtual double Base
		{
			get { return m_Base; }
			set { m_Base = value; }
		}
		double m_Base = 0;
		public virtual double Normal
		{
			get { return Base; }
		}
		public virtual double Total
		{
			get { return Base + ModifierTotal; }
		}

		#region Modifiers

		public void Add(Modifier child)
		{
			m_Modifiers.Add(child);
			child.AddTo(this);
		}
		public void Remove(Modifier child)
		{
			child.RemoveFrom(this);
			m_Modifiers.Remove(child);
		}

		public ReadOnlyCollection<Modifier> Modifiers
		{
			get { return new ReadOnlyCollection<Modifier>(m_Modifiers); }
		}
		List<Modifier> m_Modifiers = new List<Modifier>();

		public double ModifierTotal
		{
			get { return Modifiers.Sum(m => m.Bonus); }
		}

		#endregion

		public virtual void AddTo(Actor actor)
		{
			Actor = actor;
		}
		public virtual void RemoveFrom(Actor actor)
		{
			Actor = null;
		}
	}
}