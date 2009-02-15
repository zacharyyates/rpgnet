/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.3.2009
 */
namespace YatesMorrison.RolePlay
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	[Serializable]
	public class Equipment : Item, IEffect
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
		} // todo: implement IChild pattern
		public void Remove(Modifier modifier)
		{
			modifier.Effect = null;
			m_Modifiers.Remove(modifier);
		}

		public ReadOnlyCollection<Requisite> Requisites
		{
			get { return new ReadOnlyCollection<Requisite>(m_Requisites); }
		}
		List<Requisite> m_Requisites = new List<Requisite>();

		public void Add(Requisite requisite)
		{
			m_Requisites.Add(requisite);
		} // todo: implement IChild pattern
		public void Remove(Requisite requisite)
		{
			m_Requisites.Remove(requisite);
		}
		#endregion

		public Actor EquipedTo { get; set; }
		public Actor Owner { get; set; }

		public List<string> LegalSlots
		{
			get { return m_LegalSlots; }
		}
		List<string> m_LegalSlots = new List<string>();
		public string DefaultSlot { get; set; }

		public string AspectName { get; set; }
		public bool RequiresLineOfSight { get; set; }

		public Range Range { get; set; }

		public List<Ability> Abilities
		{
			get { return m_Abilities; }
		}
		List<Ability> m_Abilities = new List<Ability>();

		public void EquipTo(Actor actor)
		{
			EquipedTo = actor;
			actor.Add(this as IEffect);
		}
		public void UnequipFrom(Actor actor)
		{
			actor.Remove(this as IEffect);
			EquipedTo = null;
		}

		public void AddTo(Actor parent) { }
		public void RemoveFrom(Actor parent) { }

		/// <summary>
		/// When implemented in a derived class, reduces the durability of the item when it is used.
		/// </summary>
		protected virtual void ReduceDurability() { }
	}

	[Serializable]
	public class Equipment<TUseResult> : Equipment
		where TUseResult : class
	{
		public virtual TUseResult Use()
		{
			ReduceDurability();
			return default(TUseResult);
		}
	}
}