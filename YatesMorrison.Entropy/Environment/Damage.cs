/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2/3/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Damage : IDamage
	{
		public Damage(double value, DamageType type) : this(value, type, "") { }
		public Damage(double value, DamageType type, string area)
		{
			Value = value;
			Type = type;
			Area = area;
		}

		public double Value { get; set; }
		public DamageType Type { get; set; }
		public string Area { get; set; }

		public void Execute(Actor actor)
		{
			// determine damage
			var dr = actor.GetAspectByName("Damage Resistance").Total;
			var drPenalty = Value * (dr / 100); // percentage based
			var totalDamage = Value - drPenalty;

			// determine armor effectiveness
			var armor = actor.GetEquipmentBySlot(Area) as Armor; // this should return null if the actor IS armor
			if (armor != null)
			{
				var dt = armor.Threshold;
				var ds = armor.Soak;

				// damage the armor
				armor.Take(new Damage(ds, Type, null)); // todo: fix this so armor doesn't take max soak every hit
				totalDamage -= (dt + ds); // ignore and soak damage from the attack
			}

			totalDamage = Math.Round(totalDamage); // round the result

			if (totalDamage > 0)
			{
				var hp = actor.GetAspectByName("Current Hit Points");
				hp.Base -= Value;
			}
		}
	}

	public enum DamageType
	{
		Kinetic,
		Thermal,
		Radiological, // todo: sp?
		Biological
	}
}