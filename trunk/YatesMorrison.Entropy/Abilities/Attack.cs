/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.3.2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Attack : Ability
	{
		public Attack() : base("Attack", "ATTK", "") { }
		public Attack(string name, string abbreviation, string description) : base(name, abbreviation, description) { }

		public Weapon Weapon { get; set; }
		public string Area { get; set; }

		/// <summary>
		/// The Initiator's score in the ability required to use the weapon
		/// </summary>
		public virtual double AbilityScore
		{
			get { return Initiator.GetAspectByName(Weapon.AspectName).Total; }
		}
		public virtual bool IsInRange
		{
			get { return (Range <= Weapon.Range.Maximum); }
		}
		// todo: possibly add a range extender perk?
		protected virtual double Range
		{
			get { return Initiator.Location.DistanceTo(Target.Location); }
		}
		protected virtual double RangePenalty
		{
			get { return (Range / Weapon.Range.Nominal - 1) * 100; }
		}
		protected virtual double TargetAC
		{
			get { return Target.GetAspectByName("Armor Class").Total; }
		}
		protected virtual double ToHit
		{
			get
			{
				// calculate to hit
				var toHit = AbilityScore - RangePenalty - TargetAC;
				// bound the toHit score
				var boundedToHit = Math.Round(toHit);
				if (toHit < 1) boundedToHit = 1;
				if (toHit > 95) boundedToHit = 95;

				return boundedToHit;
			}
		}
		protected virtual bool AttackHits
		{
			get { return Dice.Roll(100) < ToHit; }
		}
		protected virtual Armor Armor
		{
			get { return Target.GetEquipmentByArea(Area) as Armor; }
		}

		public override void Use()
		{
			// todo: add a targeted attack ability
			if( IsInRange )
			{
				if (AttackHits)
				{
					Damage d = Weapon.Use() as Damage;
					if (d != null)
					{
						d.Area = Area;
						Target.Take(d); // damage the target
					}
					// todo: add a critical hit calculation
				}
			}
		}
	}
}