/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/24/2008
 */

using System.Collections.ObjectModel;
using System.Linq;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public class MundaneAlchemicalGenerator : BaseItemGenerator
	{
		public MundaneAlchemicalGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		public override void Generate( Collection<Item> items )
		{
			// Calculate item
			int roll = (int)Dice.Roll(100);
			var query = from a in m_DataContext.Mundane_ItemAlchemicals
							where a.Low <= roll &&
							a.High >= roll
							select a;
			var row = query.Single<Mundane_ItemAlchemical>();

			StackableItem item = new StackableItem();

			item.Name = row.Description;
			item.Quantity = (int)( Dice.Roll(row.DiceNumber, row.DiceRange) );
			item.Value = new CoinMonetaryValue(CoinType.Gold, row.MarketPrice);

			items.Add(item);
		}
	}
}