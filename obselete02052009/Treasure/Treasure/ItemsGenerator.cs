/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/24/2008
 */

using System.Collections.ObjectModel;
using System.Linq;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public class ItemsGenerator : BaseTreasureGenerator
	{
		public ItemsGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		public override void ByEncounterLevel( int encounterLevel, Collection<Item> items )
		{
			// Calculate goods
			int roll = (int)Dice.Roll(100);
			var query = from i in m_DataContext.Items_ByEncounterLevels
						where i.EncounterLevel == encounterLevel &&
						i.Low <= roll &&
						i.High >= roll
						select i;
			var row = query.Single<Items_ByEncounterLevel>();
			int quantity = (int)( Dice.Roll(row.DiceNumber, row.DiceRange) * row.Multiplier );

			switch( ( (ItemsType)row.ItemsType ) )
			{
				case ItemsType.Mundane:
					new MundaneGenerator(m_DataContext).Generate(items, quantity); break;
				case ItemsType.Minor:
				case ItemsType.Medium:
				case ItemsType.Major:
					new MagicItemGenerator(m_DataContext).Generate(( (ItemsType)row.ItemsType ), items, quantity); break;

				default:
				case ItemsType.Nothing:
					break;
			}
		}
	}
}