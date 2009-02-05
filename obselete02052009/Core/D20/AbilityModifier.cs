/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/5/2007
 */

namespace YatesMorrison.RolePlay.D20
{
	public class AbilityModifier : DependentCharacterAttribute
	{
		public AbilityModifier( Character character ) : base(character) { }
		public AbilityModifier( Character character, string keyAbility ) : base(character, keyAbility + " Modifier", 0, keyAbility) { }

		public override double GetCalculatedScore( double simpleScore )
		{
			return simpleScore;
		}

		public override double SimpleScore
		{
			get { return System.Math.Floor(( KeyAttributeValue - 10 ) / 2); }
			set { }
		}
	}
}