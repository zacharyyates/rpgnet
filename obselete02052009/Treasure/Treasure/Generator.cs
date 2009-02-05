/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/22/2008
 */

using System.Collections.ObjectModel;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public interface IItemGenerator
	{
		void Generate( Collection<Item> items );
	}

	public abstract class BaseItemGenerator : IItemGenerator
	{
		public BaseItemGenerator( TreasureDataContext dataContext )
		{
			m_DataContext = dataContext;
		}

		protected TreasureDataContext m_DataContext;

		public abstract void Generate( Collection<Item> items );
		public void Generate( Collection<Item> items, int quantity )
		{
			for( int index = 0; index < quantity; index++ )
			{
				Generate(items);
			}
		}
	}

	public interface ITreasureGenerator
	{
		void ByEncounterLevel( int encounterLevel, Collection<Item> items );
		void ByEncounterLevel( int encounterLevel, Collection<Item> items, int quantity );
	}

	public abstract class BaseTreasureGenerator : ITreasureGenerator
	{
		public BaseTreasureGenerator( TreasureDataContext dataContext )
		{
			m_DataContext = dataContext;	
		}

		protected TreasureDataContext m_DataContext;

		public abstract void ByEncounterLevel( int encounterLevel, Collection<Item> items );
		public void ByEncounterLevel( int encounterLevel, Collection<Item> items, int quantity )
		{
			for( int index = 0; index < quantity; index++ )
			{
				ByEncounterLevel(encounterLevel, items);
			}
		}
	}
}