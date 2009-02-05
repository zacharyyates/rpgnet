/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2/3/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Attack : Ability
	{
		public Attack() : base("Attack", "ATTK", "") { }

		public Weapon Weapon { get; set; }

		public override void Use(Actor initiator, Actor target)
		{
			// todo: add a targeted attack ability
			var range = initiator.Location.DistanceTo(target.Location);
			if (range <= Weapon.Range.Maximum)
			{
				// determine if the initiator hits the target
				var abilScore = initiator.GetAspectByName(Weapon.AspectName).Total;
				// calculate range penalty
				var rangePenalty = (range / Weapon.Range.Nominal - 1) * 100;
				// get AC for the target
				var ac = target.GetAspectByName("Armor Class").Total;
				// calculate to hit
				var toHit = abilScore - rangePenalty - ac;
				// bound the toHit score
				var toHitPercent = toHit;
				if (toHit < 1) toHitPercent = 1;
				if (toHit > 95) toHitPercent = 95;
				// determine if the attack hit
				var roll = Dice.Roll(100);
				if (roll < toHitPercent) // attack hits
				{
					// determine damage
					var maxDamage = Weapon.MaxDamage;

					var dr = target.GetAspectByName("Damage Resistance").Total;
					var dt = (target.Armor as Armor).Threshold;
					var ds = (target.Armor as Armor).Soak;

					var drPenalty = maxDamage * (dr / 100); // percentage based
					var totalDamage = Math.Round(maxDamage - drPenalty - dt - ds);

					// damage the actor
					target.Take(new Damage(totalDamage, DamageType.Kinetic));
					// damage his armor
					target.Armor.Take(new Damage(ds, DamageType.Kinetic)); // todo: fix this so armor doesn't take max soak every hit
				}
			}
		}
	}
}