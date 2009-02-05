/* Zachary Yates
 * Copyright 2007 YatesMorrison Software, LLC.
 * 11/3/2007
 */
namespace YatesMorrison.RolePlay
{
	using System;
	using System.Linq;
	using System.Xml.Serialization;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	[Serializable]
	public class Actor
	{
		public Game Game { get; set; }
		public Point Location { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }

		public virtual double Weight
		{
			get { return m_Weight; }
			set { m_Weight = value; }
		}
		protected double m_Weight = 0;

		public Inventory Inventory { get; set; }
		public Armor Armor { get; set; }

		public ReadOnlyCollection<Aspect> Aspects
		{
			get { return new ReadOnlyCollection<Aspect>(m_Aspects); }
		}
		List<Aspect> m_Aspects = new List<Aspect>();

		public virtual void Add(Aspect aspect)
		{
			m_Aspects.Add(aspect);
			aspect.Actor = this;

			var derived = aspect as DerivedAttribute;
			if (derived != null)
			{
				var attrib = GetAspectByName(derived.ParentAttributeName) as Attribute;
				attrib.Add(derived);
			}
		}

		public ReadOnlyCollection<Advance> Advances
		{
			get { return new ReadOnlyCollection<Advance>(m_Advances); }
		}
		List<Advance> m_Advances = new List<Advance>();

		public virtual void Add(Advance advance)
		{
			var attrib = GetAspectByName(advance.AttributeName) as Attribute;
			attrib.Add(advance);
			m_Advances.Add(advance);
		}

		public ReadOnlyCollection<IEffect> Effects
		{
			get { return new ReadOnlyCollection<IEffect>(m_Effects); }
		}
		List<IEffect> m_Effects = new List<IEffect>();

		public virtual void Add(IEffect effect)
		{
			if (Meets(effect.Requisites))
			{
				foreach (var modifier in effect.Modifiers)
				{
					var attrib = GetAspectByName(modifier.AspectName);
					attrib.Add(modifier);
				}
				m_Effects.Add(effect);
			}
		}
		public virtual void Remove(IEffect effect)
		{
			foreach (var modifier in effect.Modifiers)
			{
				var attrib = GetAspectByName(modifier.AspectName);
				attrib.Remove(modifier);
			}
			m_Effects.Remove(effect);
		}

		public bool Meets(Requisite requisite)
		{
			var attrib = GetAspectByName(requisite.AspectName);
			return requisite.IsSatisfied(attrib.Total);
		}
		public bool Meets(IList<Requisite> requisites)
		{
			foreach (Requisite requisite in requisites)
			{
				if (!Meets(requisite)) throw new InvalidOperationException(requisite.NotSatisfiedMessage);
			}
			return true;
		}

		public Aspect GetAspectByName(string name)
		{
			try
			{
				return Aspects.Single(a => a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
			}
			catch (Exception exception)
			{
				throw new ApplicationException(string.Format("Could not find '{0}'.", name), exception);
			}
		}
		public Aspect GetAspectByAbbreviation(string abbreviation)
		{
			try
			{
				return Aspects.Single(a => a.Abbreviation.Equals(abbreviation, StringComparison.InvariantCultureIgnoreCase));
			}
			catch (Exception exception)
			{
				throw new ApplicationException(string.Format("Could not find '{0}'.", abbreviation), exception);
			}
		}

		public ReadOnlyCollection<Equipment> Equipment
		{
			get { return new ReadOnlyCollection<Equipment>(m_Equipment); }
		}
		List<Equipment> m_Equipment = new List<Equipment>();

		public void Equip(Equipment equipment)
		{
			if (Meets(equipment.Requisites))
			{
				m_Equipment.Add(equipment);
				Add(equipment);  // todo: make this a little more elegant?
				equipment.EquipedTo = this;
			}
			// todo: add a message or something when equip fails
		}
		public void Unequip(Equipment equipment)
		{
			m_Equipment.Remove(equipment);
			Remove(equipment);
			equipment.EquipedTo = null;
		}

		public void Take(IDamage damage)
		{
			damage.Execute(this);
		}

		public override string ToString()
		{
			return Name;
		}
	}

	public class ActionEventArgs : EventArgs
	{
		public Actor Initiator { get; set; }
		public Actor Target { get; set; }
		public Ability Ability { get; set; }
	}
}