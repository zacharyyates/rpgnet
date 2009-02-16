/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.15.2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Ammunition : Charge
	{
		/// <summary>
		/// The minimum damage output of the ammunition
		/// </summary>
		public double MinDamage { get; set; }
		/// <summary>
		/// The maximum damage output of the ammunition
		/// </summary>
		public double MaxDamage { get; set; }
		/// <summary>
		/// The type of damage dealt by the ammunition
		/// </summary>
		public DamageType DamageType { get; set; }

		public override IDamage Damage
		{
			get { return new Damage(Dice.Range((int)MinDamage, (int)MaxDamage), DamageType); }
		}
	}
}