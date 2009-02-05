/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software Company
 * 7/23/2008
 */

using System;

namespace YatesMorrison.Rpg.Dnd4
{
	public class HitPoints : CharacterAttribute
	{
		HitPoints(Character character) : base(character) { }
		public HitPoints(Character character, double simpleScore) : base(character, "HP", simpleScore) { }
	}

	public class BloodiedValue : DependentCharacterAttribute
	{
		public BloodiedValue(Character character) : base(character, "BV", 0, "HP") { }

		public override double GetCalculatedScore(double simpleScore)
		{
			return Math.Floor(KeyAttributeValue / 2);
		}
	}

	public class SurgeValue : DependentCharacterAttribute
	{
		public SurgeValue(Character character) : base(character, "SV", 0, "HP") { }

		public override double GetCalculatedScore(double simpleScore)
		{
			return Math.Floor(KeyAttributeValue / 4);
		}
	}
}