/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/23/2008
 */

using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public class CoinGenerator : BaseTreasureGenerator
	{
		public CoinGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		public override void ByEncounterLevel( int encounterLevel, Collection<Item> items )
		{
			int coinPercentile = (int)Dice.Roll(100);
			var coinsQuery = from c in m_DataContext.Coins_ByEncounterLevels
							 where c.EncounterLevel == encounterLevel &&
							 c.Low <= coinPercentile &&
							 c.High >= coinPercentile
							 select c;
			var coinsRow = coinsQuery.Single<Coins_ByEncounterLevel>();

			if( ( (CoinType)coinsRow.CoinType ) != CoinType.Nothing )
			{
				int coinValue = (int)( Dice.Roll(coinsRow.DiceNumber, coinsRow.DiceRange) * coinsRow.Multiplier );
				CurrencyItem coinsItem = new CurrencyItem(new CoinMonetaryValue(( (CoinType)coinsRow.CoinType ), coinValue));
				items.Add(coinsItem);
			}
		}
	}
}