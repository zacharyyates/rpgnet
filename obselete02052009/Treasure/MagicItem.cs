/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/24/2008
 */

using System.Collections.ObjectModel;
namespace YatesMorrison.RolePlay.D20.Past
{
	public class MagicItem : Item
	{
		public Collection<ItemSpecialAbility> Abilities
		{
			get { return m_Abilities; }
		}
		Collection<ItemSpecialAbility> m_Abilities = new Collection<ItemSpecialAbility>();

		public int EnhancementBonus
		{
			get { return m_EnhancementBonus; }
			set { m_EnhancementBonus = value; }
		}
		int m_EnhancementBonus;
	}
}