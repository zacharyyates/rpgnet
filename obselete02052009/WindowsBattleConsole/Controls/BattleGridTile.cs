/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 01.31.2008
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsBattleConsole.Resources.Images;
using YatesMorrison.RolePlay.BattleFramework;

namespace WindowsBattleConsole.Controls
{
	public class BattleGridTile : PictureBox
	{
		public BattleGridTile() 
		{
			this.SizeMode = PictureBoxSizeMode.CenterImage;
		}
		public BattleGridTile( Tile tile ) : this()
		{
			Tile = tile;
		}
		public BattleGridTile( Tile tile, IWorldActor actor ) : this(tile)
		{
			WorldActor = actor;
		}

		public IWorldActor WorldActor
		{
			get { return m_WorldActor; }
			set
			{
				m_WorldActor = value;

				if( value != null )
				{
					Tag = WorldActor.ActorId;
					SetForegroundImage();
				}
			}
		}
		IWorldActor m_WorldActor;

		public Tile Tile
		{
			get { return m_Tile; }
			set
			{
				m_Tile = value;

				if( value != null )
				{
					SetBackgroundImage();
					SetPosition();
				}
			}
		}
		Tile m_Tile;

		void SetForegroundImage()
		{
			// Set image
			SpriteDisplayObject sdo = WorldActor.DisplayObject as SpriteDisplayObject;
			if( sdo != null )
			{
				if( File.Exists(sdo.ImagePath) )
				{
					Image = new Bitmap(sdo.ImagePath);
				}
				else
				{
					// TODO: Display error?
				}
			}
		}

		void SetBackgroundImage()
		{
			switch( Highlight )
			{
				default:
				case TileHighlightType.None: BackgroundImage = Images.Sq100Gray; break;
				case TileHighlightType.Hover: BackgroundImage = Images.Sq100White; break;
				case TileHighlightType.Selected: BackgroundImage = Images.Sq100Green; break;
				case TileHighlightType.Special: BackgroundImage = Images.Sq100Orange; break;
			}

			Width = BackgroundImage.Width;
			Height = BackgroundImage.Height;
		}

		void SetPosition()
		{
			TableLayoutPanel parent = Parent as TableLayoutPanel;
			if( parent != null )
			{
				parent.SetColumn(this, (int)WorldActor.Position.X);
				parent.SetRow(this, (int)WorldActor.Position.Y);
			}
		}

		public TileHighlightType Highlight
		{
			get { return m_Highlight; }
			set
			{
				m_PreviousHighlight = m_Highlight;
				m_Highlight = value;
				SetBackgroundImage();
			}
		}
		TileHighlightType m_Highlight = TileHighlightType.None;

		void RevertHighlight()
		{
			Highlight = m_PreviousHighlight;
		}

		TileHighlightType m_PreviousHighlight = TileHighlightType.None;

		public bool HighlightOnHover
		{
			get;
			set;
		}

		protected override void OnMouseEnter( EventArgs e )
		{
			base.OnMouseEnter(e);
			if( HighlightOnHover && Highlight == TileHighlightType.None ) { Highlight = TileHighlightType.Hover; }
		}
		protected override void OnMouseLeave( EventArgs e )
		{
			base.OnMouseLeave(e);

			if( HighlightOnHover && Highlight == TileHighlightType.None ) { RevertHighlight(); }
		}
	}

	public enum TileHighlightType
	{
		None,
		Hover,
		Selected,
		Special
	}

	public class TileClickEventArgs : EventArgs
	{
		public MouseEventArgs MouseEventArgs
		{
			get;
			set;
		}

		public Tile Tile
		{
			get;
			set;
		}
		public IWorldActor Actor
		{
			get;
			set;
		}
	}
}
