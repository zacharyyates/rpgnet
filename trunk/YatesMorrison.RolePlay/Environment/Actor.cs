/* Zachary Yates
 * Copyright 2007 YatesMorrison Software, LLC.
 * 11/3/2007
 */
namespace YatesMorrison.RolePlay
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;

	[Serializable]
	public class Actor : IParentOf<Aspect>, IParentOf<Advance>, IParentOf<IEffect>
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

		#region Aspects

		public ReadOnlyCollection<Aspect> Aspects
		{
			get { return new ReadOnlyCollection<Aspect>(m_Aspects); }
		}
		List<Aspect> m_Aspects = new List<Aspect>();

		public virtual void Add(Aspect child)
		{
			m_Aspects.Add(child);
			child.AddTo(this);
		}
		public virtual void Remove(Aspect child)
		{
			child.RemoveFrom(this);
			m_Aspects.Remove(child);
		}

		#endregion

		#region Advances

		public ReadOnlyCollection<Advance> Advances
		{
			get { return new ReadOnlyCollection<Advance>(m_Advances); }
		}
		List<Advance> m_Advances = new List<Advance>();

		public virtual void Add(Advance child)
		{
			m_Advances.Add(child);
			child.AddTo(this);
		}
		public virtual void Remove(Advance child)
		{
			child.RemoveFrom(this);
			m_Advances.Remove(child);
		}

		#endregion

		#region Effects

		public ReadOnlyCollection<IEffect> Effects
		{
			get { return new ReadOnlyCollection<IEffect>(m_Effects); }
		}
		List<IEffect> m_Effects = new List<IEffect>();

		public virtual void Add(IEffect child)
		{
			if (Meets(child.Requisites))
			{
				m_Effects.Add(child);
				child.AddTo(this);
			}
		}
		public virtual void Remove(IEffect child)
		{
			child.RemoveFrom(this);
			m_Effects.Remove(child);
		}

		#endregion

		#region Equipment

		public ReadOnlyCollection<Item> Items
		{
			get { return new ReadOnlyCollection<Item>(m_Items); }
		}
		List<Item> m_Items = new List<Item>();

		public void Equip(Equipment equipment, string slot)
		{
			if (equipment.LegalSlots.Contains(slot) &&	// can be equiped to the slot
				m_Equipment[slot] == null &&			// the slot is empty
				Meets(equipment.Requisites))			// meets prereqisites
			{
				m_Equipment[slot] = equipment;
				equipment.EquipTo(this);
			}
			// todo: add a message or something when equip fails
		}
		public void Unequip(Equipment equipment, string slot)
		{
			equipment.UnequipFrom(this);
		}

		public Equipment GetEquipmentBySlot(string slot)
		{
			return m_Equipment[slot];
		}

		public ReadOnlyCollection<Equipment> Equipment
		{
			get { return new ReadOnlyCollection<Equipment>(m_Equipment.Values.ToList()); }
		}
		protected Dictionary<string, Equipment> m_Equipment = new Dictionary<string, Equipment>();

		#endregion

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

		public void Take(IDamage damage)
		{
			if (damage != null) // failed or no-effect attack
			{
				damage.Execute(this);
			}
		}

		public override string ToString()
		{
			return Name;
		}
	}
}