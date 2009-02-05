/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2/3/2009
 */
namespace YatesMorrison.RolePlay
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	[Serializable]
	public class Equipment : Item, IEffect // todo: add some sort of "slot" functionality, ie: you can't wear 2 helmets
	{
		#region IEffect
		public EffectType EffectType
		{
			get { return EffectType.Equipment; }
		}

		public ReadOnlyCollection<Modifier> Modifiers
		{
			get { return new ReadOnlyCollection<Modifier>(m_Modifiers); }
		}
		List<Modifier> m_Modifiers = new List<Modifier>();

		public void Add(Modifier modifier)
		{
			m_Modifiers.Add(modifier);
			modifier.Effect = this;
		}

		public ReadOnlyCollection<Requisite> Requisites
		{
			get { return new ReadOnlyCollection<Requisite>(m_Requisites); }
		}
		List<Requisite> m_Requisites = new List<Requisite>();

		public void Add(Requisite requisite)
		{
			m_Requisites.Add(requisite);
		}
		#endregion

		public Actor EquipedTo { get; set; }
		public Actor Owner { get; set; }

		public string AspectName { get; set; }
		public bool RequiresLineOfSight { get; set; }

		public Range Range { get; set; }

		public List<Ability> Abilities
		{
			get { return m_Abilities; }
		}
		List<Ability> m_Abilities = new List<Ability>();

		public void AddTo(Actor parent)
		{
			EquipedTo = parent;
		}
		public void RemoveFrom(Actor parent)
		{
			EquipedTo = null;
		}
	}
}