/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/26/2008
 */

using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace YatesMorrison.RolePlay.BattleFramework
{
	[Serializable]
	public class World
	{
		public World() {}	

		public Collection<IWorldActor> Actors
		{
			get { return m_Actors; }
		}
		Collection<IWorldActor> m_Actors = new Collection<IWorldActor>();

		public Collection<Tile> Tiles
		{
			get { return m_Tiles; }
		}
		Collection<Tile> m_Tiles = new Collection<Tile>();

		public ObjectSize Size
		{
			get;
			set;
		}

		public IDisplayObject DisplayObject
		{
			get;
			set;
		}

		public Tile CreateTile( ObjectPosition position )
		{
			Tile tile = new Tile { Position = position };
			Tiles.Add(tile);
			return tile;
		}

		public void FillDefault()
		{
			for( int currentY = 0; currentY < Size.Height; currentY++ )
			{
				for( int currentX = 0; currentX < Size.Width; currentX++ )
				{
					CreateTile(new ObjectPosition { X = currentX, Y = currentY });
				}
			}
		}

		public Tile GetTileAt( ObjectPosition position )
		{
			try
			{
				var tile = Tiles.Single<Tile>(
					t => t.Position.X == position.X &&
						t.Position.Y == position.Y);
				return tile;
			}
			catch( InvalidOperationException )
			{
				return null;
			}
		}

		public IWorldActor GetActorAt( ObjectPosition position )
		{
			try
			{
				var worldObject = Actors.Single<IWorldActor>(
					wo => wo.Position.X == position.X &&
						wo.Position.Y == position.Y);
				return worldObject;
			}
			catch( InvalidOperationException )
			{
				return null;
			}
		}
		public IWorldActor GetActorBy( string actorId )
		{
			IWorldActor actor = null;
			try	{ actor = Actors.Single<IWorldActor>(a => a.ActorId == actorId); }
			catch{}
			return actor;
		}

		protected double GetDistance( ObjectPosition pos1, ObjectPosition pos2 )
		{
			double deltaXSquared = System.Math.Pow(( pos2.X - pos1.X ), 2);
			double deltaYSquared = System.Math.Pow(( pos2.Y - pos1.Y ), 2);
			return System.Math.Sqrt(deltaXSquared + deltaYSquared);
		}
		protected double GetDistance( IWorldObject obj1, IWorldObject obj2 )
		{
			return GetDistance(obj1.Position, obj2.Position);
		}

		protected bool IsInLineOfSight( IWorldObject obj1, IWorldObject obj2 )
		{
			throw new NotImplementedException();
		}
	}

	[Serializable]
	public class TileWorldDisplayObject : IDisplayObject
	{
		public Tile DefaultTile
		{
			get;
			set;
		}
		public Tile NullTile
		{
			get;
			set;
		}

		public int ScreenTileWidth
		{
			get;
			set;
		}
		public int ScreenTileHeight
		{
			get;
			set;
		}
	}
}