/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/23/2008
 */

using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	/// <summary>
	/// Generates treasure for an encouter, based on encounter level
	/// </summary>
	public class TreasureGenerator : BaseTreasureGenerator
	{
		public TreasureGenerator() : base(new TreasureDataContext()) { }
		public TreasureGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		public override void ByEncounterLevel( int encounterLevel, Collection<Item> items )
		{
			CoinGenerator coinGen = new CoinGenerator(m_DataContext);
			coinGen.ByEncounterLevel(encounterLevel, items);

			GoodsGenerator goodsGen = new GoodsGenerator(m_DataContext);
			goodsGen.ByEncounterLevel(encounterLevel, items);
		}
	}
}