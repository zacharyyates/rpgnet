/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2/3/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public struct Damage : IDamage
	{
		public Damage(double value, DamageType type)
		{
			m_Value = value;
			m_Type = type;
		}

		public double Value
		{
			get { return m_Value; }
		}
		double m_Value;

		public DamageType Type
		{
			get { return m_Type; }
		}
		DamageType m_Type;

		public void Execute(Actor actor)
		{
			var hp = actor.GetAspectByName("Current Hit Points");
			hp.Base -= Value;
		}
	}

	public enum DamageType
	{
		Kinetic
	}
}