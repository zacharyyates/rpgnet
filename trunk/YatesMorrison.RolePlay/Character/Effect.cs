/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/4/2007
 */
namespace YatesMorrison.RolePlay
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public interface IEffect // todo: maybe break this out into IRequisite, IModifier
	{
		string Name { get; }
		string Description { get; }
		EffectType EffectType { get; }

		ReadOnlyCollection<Modifier> Modifiers { get; }
		ReadOnlyCollection<Requisite> Requisites { get; }
	}

	[Serializable]
	public class Effect : IEffect
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public EffectType EffectType { get; set; }

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
	}

	public enum EffectType
	{
		Enhancement,
		Equipment,
		Friendly,
		Hostile
	}
}