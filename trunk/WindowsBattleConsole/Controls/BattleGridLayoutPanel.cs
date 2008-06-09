/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 01.31.2008
 */

using System;
using System.Windows.Forms;
using System.Drawing;
using YatesMorrison.RolePlay.BattleFramework;

namespace WindowsBattleConsole.Controls
{
	public class BattleGridLayoutPanel : TableLayoutPanel
	{
		public BattleGridLayoutPanel()
		{
			AutoScroll = true;
			AutoSize = true;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			ResizeRedraw = false;
		}

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

		protected override void OnControlAdded( ControlEventArgs e )
		{
			base.OnControlAdded(e);

			BattleGridTile tile = e.Control as BattleGridTile;
			if( tile != null )
			{
				tile.MouseClick += tile_MouseClick;
			}
		}

		protected override void OnControlRemoved( ControlEventArgs e )
		{
			base.OnControlRemoved(e);

			BattleGridTile tile = e.Control as BattleGridTile;
			if( tile != null )
			{
				tile.MouseClick -= tile_MouseClick;
			}
		}

		void tile_MouseClick( object sender, MouseEventArgs e )
		{
			BattleGridTile tile = sender as BattleGridTile;
			TileClickEventArgs tileClickArgs = new TileClickEventArgs
			{
				Tile = tile.Tile,
				MouseEventArgs = e
			};

			OnTileClick(tile, tileClickArgs);
		}

		#region Scaling logic

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

		public override Size MaximumSize
		{
			get
			{
				if( World != null )
				{
					int screenTileWidth = 100;
					int screenTileHeight = 100;

					if( World.DisplayObject != null )
					{
						TileWorldDisplayObject dispObj = World.DisplayObject as TileWorldDisplayObject;
						if( dispObj != null )
						{
							screenTileWidth = dispObj.ScreenTileWidth;
							screenTileHeight = dispObj.ScreenTileHeight;
						}
					}

					double width = (double)( screenTileWidth * ScaleFactorX * ColumnCount );
					double height = (double)( screenTileHeight * ScaleFactorY * RowCount );

					return new Size
					{
						Width = (int)Math.Round(width),
						Height = (int)Math.Round(height)
					};
				}
				else
				{
					return base.MaximumSize;
				}
			}
			set
			{
				base.MaximumSize = value;
			}
		}
		public override Size MinimumSize
		{
			get { return MaximumSize; }
			set
			{
				base.MinimumSize = value;
			}
		}

		#endregion

		public void LoadWorld( World world )
		{
			World = world;

			// Set size
			ColumnCount = (int)world.Size.Width;
			RowCount = (int)world.Size.Height;

			foreach( Tile tile in world.Tiles )
			{
				Controls.Add(new BattleGridTile(tile));
			}

			foreach( IWorldActor actor in world.Actors )
			{
				BattleGridTile tile = GetControlFromPosition(
					(int)actor.Position.X, (int)actor.Position.Y) as BattleGridTile;

				if( tile != null )
				{
					tile.WorldActor = actor;
				}
			}

			Size = MaximumSize;
			Invalidate();
			Update();
			MessageBox.Show(this.MinimumSize.Width + " x " + this.MinimumSize.Height);
		}

		public World World {
			get;
			set;
		}
	}
}