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
		public Damage(double value, DamageType type) : this(value, type, null) { }
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
			double totalDamage = 0;
			var dr = actor.GetAspectByName("Damage Resistance");
			if (dr != null)
			{
				var drPenalty = Value * (dr.Total / 100); // percentage based
				totalDamage = Value - drPenalty; // this actor has damage resistance, apply it
			}
			else
			{
				totalDamage = Value; // no damage resistance
			}

			// determine armor effectiveness
			if (!string.IsNullOrEmpty(Area)) // If no area is defined, armor is not relevant
			{
				var armor = actor.GetEquipmentByArea(Area) as Armor; // this should return null if the actor IS armor
				if (armor != null)
				{
					var dt = armor.Threshold;
					var ds = armor.Soak;

					totalDamage -= (dt + ds); // ignore and soak damage from the attack
					if (totalDamage < 0) ds += totalDamage; // if the attack doesn't use up all of the soak, don't damage the armor for the full soak
					armor.Take(new Damage(Math.Round(ds), Type)); // damage is only Real numbers
					// todo: add damageType specific resistence
				}
			}

			totalDamage = Math.Round(totalDamage); // round the result, damage is only Real numbers

			if (totalDamage > 0)
			{
				var hp = actor.GetAspectByName("Current Hit Points");
				hp.Base -= totalDamage;
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