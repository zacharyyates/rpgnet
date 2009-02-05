/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/7/2007
 */

namespace YatesMorrison.RolePlay.D20
{
	public class AttackBonus : DependentCharacterAttribute
	{
		public AttackBonus( Character character ) : base(character) { }

		public override double GetCalculatedScore( double simpleScore )
		{
			return m_Character.GetEffectedScoreFor(Strings.BASE_ATTACK_BONUS) + 
				KeyAttributeValue + 
				m_Character.GetEffectedScoreFor(Strings.SIZE_MOD);
		}
	}
}