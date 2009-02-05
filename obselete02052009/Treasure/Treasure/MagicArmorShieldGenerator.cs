/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/26/2008
 */

using System.Collections.ObjectModel;
using System.Linq;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public class MagicArmorShieldGenerator : BaseMagicItemGenerator
	{
		public MagicArmorShieldGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		MagicItem m_CurrentItem = null;

		public void Generate( ItemsType type, Collection<Item> items, MagicItem currentItem )
		{
			m_CurrentItem = currentItem;
			Generate(type, items);
		}

		public override void Generate( ItemsType type, Collection<Item> items )
		{
			IQueryable<Magic_ArmorShield> query = null;
			int roll = (int)Dice.Roll(100);

			switch( type )
			{
				case ItemsType.Minor:
					query = from i in m_DataContext.Magic_ArmorShields
							where i.MinorLow <= roll &&
							i.MinorHigh >= roll
							select i;
					break;
				case ItemsType.Medium:
					query = from i in m_DataContext.Magic_ArmorShields
							where i.MediumLow <= roll &&
							i.MediumHigh >= roll
							select i;
					break;
				case ItemsType.Major:
					query = from i in m_DataContext.Magic_ArmorShields
							where i.MajorLow <= roll &&
							i.MajorHigh >= roll
							select i;
					break;

				default:
				case ItemsType.Mundane:
				case ItemsType.Nothing:
					break;
			}

			var row = query.Single<Magic_ArmorShield>();

			// Build the base item
			if( m_CurrentItem != null )
			{
				m_CurrentItem = new MagicItem();
			}
				
			// forward the generation to the specific table indicated
			switch( (ArmorOrShieldType)row.ArmorOrShield )
			{
				default:
				case ArmorOrShieldType.Nothing:
					break;

				case ArmorOrShieldType.Armor:

					// Determine armor type
					int armorRoll = (int)Dice.Roll(100);
					var armorQuery = from t in m_DataContext.Magic_ArmorTypes
									where t.Low <= armorRoll && t.High >= armorRoll
									select t;
					var armorRow = armorQuery.Single<Magic_ArmorType>();

					m_CurrentItem.Name = armorRow.Description;
					m_CurrentItem.EnhancementBonus = row.EnhancementBonus.Value;
					m_CurrentItem.Value += armorRow.ArmorCost.Value;
					break;

				case ArmorOrShieldType.Shield:

					// Determine shield type
					int shieldRoll = (int)Dice.Roll(100);
					var shieldQuery = from t in m_DataContext.Magic_ShieldTypes
									where t.Low <= shieldRoll && t.High >= shieldRoll
									select t;
					var shieldRow = shieldQuery.Single<Magic_ShieldType>();

					m_CurrentItem.Name = shieldRow.Description;
					m_CurrentItem.EnhancementBonus = row.EnhancementBonus.Value;
					m_CurrentItem.Value += shieldRow.ShieldCost.Value;
					break;


			}
		}
	}

	public enum ArmorOrShieldType
	{
		Nothing = 0,
		Shield = 1,
		SpecificShield = 2,
		Armor = 3,
		SpecificArmor = 4,
		SpecialAbility = 5
	}
}