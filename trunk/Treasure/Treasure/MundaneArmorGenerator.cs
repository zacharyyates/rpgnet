﻿/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/24/2008
 */

using System.Collections.ObjectModel;
using System.Linq;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public class MundaneArmorGenerator : BaseItemGenerator
	{
		public MundaneArmorGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		public override void Generate( Collection<Item> items )
		{
			// Calculate item
			int roll = (int)Dice.Roll(100);
			var query = from a in m_DataContext.Mundane_ItemArmors
						where a.Low <= roll &&
						a.High >= roll
						select a;
			var row = query.Single<Mundane_ItemArmor>();

			Item item = new Item();

			double sizeRoll = Dice.Roll(100);
			item.SizeCategory = ( sizeRoll < 11 ? SizeCategory.Small : SizeCategory.Medium );

			if( roll >= 81 && roll <= 90 ) // Darkwood
			{
				new MundaneDarkwoodArmorGenerator(m_DataContext).Generate(items);
			}
			else if( roll >= 91 && roll <= 100 ) // Masterwork shield
			{
				new MundaneMasterworkShieldGenerator(m_DataContext).Generate(items);
			}
			else // Regular armor
			{
				item.Name = row.Description;
				item.Value = new CoinMonetaryValue(CoinType.Gold, row.MarketPrice);

				items.Add(item);
			}
		}
	}
}