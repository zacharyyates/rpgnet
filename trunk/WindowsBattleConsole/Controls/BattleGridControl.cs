/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 02.4.2008
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YatesMorrison.RolePlay.BattleFramework;

namespace WindowsBattleConsole.Controls
{
	public class BattleGridControl : UserControl
	{
		public BattleGridControl()
		{
			AutoSize = true;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			AutoScroll = true;
		}

		public World World
		{
			get { return m_World; }
			set
			{
				m_World = value;
				if( m_World != null )
				{
					LoadWorld();
				}
			}
		}
		World m_World;

		#region TileClick Event
		public event EventHandler<TileClickEventArgs> TileClick
		{
			add { m_TileClick += value; }
			remove { m_TileClick -= value; }
		}
		protected void OnTileClick( object sender, TileClickEventArgs e )
		{
			if( m_TileClick != null )
			{
				m_TileClick(sender, e);
			}
		}
		EventHandler<TileClickEventArgs> m_TileClick;
		#endregion

		protected override void OnPaintBackground( PaintEventArgs e )
		{
			base.OnPaintBackground(e);

			
		}

		protected override void OnPaint( PaintEventArgs e )
		{
			base.OnPaint(e);


		}

		protected void LoadWorld()
		{
			SuspendLayout();
			Controls.Clear();

			foreach( Tile tile in World.Tiles )
			{
				Controls.Add(new BattleGridTile(tile));
			}

			foreach( IWorldActor actor in World.Actors )
			{
				BattleGridTile tile = GetTileFromPosition(actor.Position);

				if( tile != null )
				{
					tile.WorldActor = actor;
				}
			}

			Size = MinimumSize;

			ResumeLayout();
			UpdateBounds();
		}

		protected ObjectPosition GetPositionForPoint( int x, int y )
		{
			double xPos = Math.Floor((double)( x / ( TileSize * ScaleFactorX + TileGutter ) - TileGutter));
			double yPos = Math.Floor((double)( y / ( TileSize * ScaleFactorY + TileGutter ) - TileGutter));
			return new ObjectPosition
			{
				X = xPos,
				Y = yPos
			};
		}
		protected Point GetPointForPosition( ObjectPosition position )
		{
			double x = Math.Round(position.X * ( TileSize * ScaleFactorX + TileGutter )) + TileGutter;
			double y = Math.Round(position.Y * ( TileSize * ScaleFactorY + TileGutter )) + TileGutter;
			return new Point
			{
				X = (int)x,
				Y = (int)y
			};
		}

		protected BattleGridTile GetTileFromPosition( ObjectPosition position )
		{
			BattleGridTile tile = null;
			try
			{
				tile = m_Tiles.Single<BattleGridTile>(t => t.Tile.Position.Equals(position));
			}
			catch( InvalidOperationException ) { }
			return tile;
		}

		#region Scaling logic

		public int TileSize
		{
			get { return m_TileSize; }
			set { m_TileSize = value; }
		}
		int m_TileSize = 100;

		public int TileGutter
		{
			get { return m_TileGutter; }
			set { m_TileGutter = value; }
		}
		int m_TileGutter = 0;

		protected override void ScaleCore( float dx, float dy )
		{
			// Save the scale factor
			ScaleFactorX = dx;
			ScaleFactorY = dy;

			base.ScaleCore(dx, dy);
		}

		protected float ScaleFactorX
		{
			get { return m_ScaleFactorX; }
			set { m_ScaleFactorX = value; }
		}
		float m_ScaleFactorX = 1;

		protected float ScaleFactorY
		{
			get { return m_ScaleFactorY; }
			set { m_ScaleFactorY = value; }
		}
		float m_ScaleFactorY = 1;

		public override Size MinimumSize
		{
			get
			{// Left this in to use later when tiles are loaded via the WorldDisplayoBj
				//if( World != null )
				//{
				//    int screenTileWidth = 100;
				//    int screenTileHeight = 100;

				//    if( World.DisplayObject != null )
				//    {
				//        TileWorldDisplayObject dispObj = World.DisplayObject as TileWorldDisplayObject;
				//        if( dispObj != null )
				//        {
				//            screenTileWidth = dispObj.ScreenTileWidth;
				//            screenTileHeight = dispObj.ScreenTileHeight;
				//        }
				//    }
				if( World != null )
				{
					if( World.Size != null )
					{
						double width = (double)( ( TileSize * ScaleFactorX + TileGutter ) * World.Size.Width ) + TileGutter;
						double height = (double)( ( TileSize * ScaleFactorY + TileGutter ) * World.Size.Height ) + TileGutter;

						return new Size
						{
							Width = (int)Math.Round(width),
							Height = (int)Math.Round(height)
						};
					}
				}

				return base.MinimumSize;

				//}
				//else
				//{
				//    return base.MaximumSize;
				//}
			}
			set
			{
				base.MinimumSize = value;
			}
		}		

		#endregion

		List<BattleGridTile> m_Tiles = new List<BattleGridTile>();

		protected override void OnControlAdded( ControlEventArgs e )
		{
			BattleGridTile tile = e.Control as BattleGridTile;
			if( tile != null )
			{
				m_Tiles.Add(tile);

				// Set position
				tile.Location = GetPointForPosition(tile.Tile.Position);
				tile.MouseClick += tile_MouseClick;
			}

			base.OnControlAdded(e);
		}

		protected override void OnControlRemoved( ControlEventArgs e )
		{
			BattleGridTile tile = e.Control as BattleGridTile;
			if( tile != null )
			{
				m_Tiles.Remove(tile);
				tile.MouseClick -= tile_MouseClick;
			}

			base.OnControlRemoved(e);
		}

		void tile_MouseClick( object sender, MouseEventArgs e )
		{
			BattleGridTile tile = sender as BattleGridTile;
			TileClickEventArgs tileClickArgs = new TileClickEventArgs
			{
				Tile = tile.Tile,
				Actor = tile.WorldActor,
				MouseEventArgs = e
			};

			OnTileClick(tile, tileClickArgs);
		}
	}
}