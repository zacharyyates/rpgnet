/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/7/2007
 */

namespace YatesMorrison.RolePlay.D20
{
	public class DefenseBonus : DependentCharacterAttribute
	{
		public DefenseBonus( Character character )
			: base(character)
		{
			Name = Strings.DEFENSE_BONUS;
			KeyAttribute = Strings.DEX_MOD;
		}

		public override double GetCalculatedScore( double simpleScore )
		{
			return simpleScore + m_Character.GetEffectedScoreFor(Strings.EQUIP_BONUS) +
				KeyAttributeValue + m_Character.GetEffectedScoreFor(Strings.SIZE_MOD) +
				m_Character.GetEffectedScoreFor(Strings.ARMOR_PENALTY);
		}
	}
}