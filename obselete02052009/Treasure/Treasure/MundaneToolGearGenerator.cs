/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/24/2008
 */

using System.Collections.ObjectModel;
using System.Linq;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public class MundaneToolGearGenerator : BaseItemGenerator
	{
		public MundaneToolGearGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		public override void Generate( Collection<Item> items )
		{
			// Calculate item
			int roll = (int)Dice.Roll(100);
			var query = from a in m_DataContext.Mundane_ItemToolGears
						where a.Low <= roll &&
						a.High >= roll
						select a;
			var row = query.Single<Mundane_ItemToolGear>();

			Item item = new Item();

			item.Name = row.Description;
			item.Value = new CoinMonetaryValue(CoinType.Gold, row.MarketPrice);

			items.Add(item);
		}
	}
}