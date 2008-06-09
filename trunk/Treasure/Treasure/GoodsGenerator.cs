/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/23/2008
 */

using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public class GoodsGenerator : BaseTreasureGenerator
	{
		public GoodsGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		public override void ByEncounterLevel( int encounterLevel, Collection<Item> items )
		{
			// Calculate goods
			int goodsPercentile = (int)Dice.Roll(100);
			var goodsQuery = from g in m_DataContext.Goods_ByEncounterLevels
							 where g.EncounterLevel == encounterLevel &&
							 g.Low <= goodsPercentile &&
							 g.High >= goodsPercentile
							 select g;
			var goodsRow = goodsQuery.Single<Goods_ByEncounterLevel>();
			int goodsQuantity = (int)( Dice.Roll(goodsRow.DiceNumber, goodsRow.DiceRange) * goodsRow.Multiplier );

			switch( (GoodsType)goodsRow.GoodsType )
			{
				default:
				case GoodsType.Nothing: break;

				case GoodsType.Gem: new GemsGenerator(m_DataContext).Generate(items, goodsQuantity); break;
				case GoodsType.Art: new ArtObjectsGenerator(m_DataContext).Generate(items, goodsQuantity); break;
			}
		}
	}
}