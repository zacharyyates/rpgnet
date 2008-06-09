/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/28/2008
 */

using System;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YatesMorrison.RolePlay.BattleFramework.Web
{
	public class WebViewRenderer
	{
		public World World
		{
			get { return m_World; }
			set { m_World = value; }
		}
		World m_World;

		public Table Table
		{
			get { return m_Table; }
			set { m_Table = value; }
		}
		Table m_Table;

		public ImageClickEventHandler OnCharacterClick
		{
			get { return m_OnCharacterClick; }
			set { m_OnCharacterClick = value; }
		}
		ImageClickEventHandler m_OnCharacterClick;

		public ImageClickEventHandler OnTileClick
		{
			get { return m_OnTileClick; }
			set { m_OnTileClick = value; }
		}
		ImageClickEventHandler m_OnTileClick;

		public void Render()
		{
			Table.Rows.Clear();

			// Set style
			Table.CssClass = "BattleGrid";

			// Loop through the tiles and create the background
			for( double currentY = 0; currentY < World.Size.Height; currentY++ )
			{
				TableRow row = new TableRow();
				Table.Rows.Add(row);

				for( double currentX = 0; currentX < World.Size.Width; currentX++ )
				{
					TableCell cell = new TableCell();
					row.Cells.Add(cell);

					// Add the tile
					Tile tile = World.GetTileAt(new Position { X = currentX, Y = currentY });
					if( tile != null )
					{
						ApplyTile(cell, tile);
					}
					else
					{
						ApplyTile(cell, World.NullTile);
					}

					// Add the WorldObject if there is one
					IWorldObject worldObject = World.GetObjectAt(new Position { X = currentX, Y = currentY });
					if( worldObject != null )
					{
						SpriteDisplayObject woDispObj = worldObject.DisplayObject as SpriteDisplayObject;

						ImageButton image = new ImageButton();
						image.ImageUrl = woDispObj.ImageUrl;
						image.Width = woDispObj.ScreenWidth;
						image.Height = woDispObj.ScreenHeight;
						image.ToolTip = woDispObj.ActorID;
						image.Click += OnCharacterClick;
						image.ID = currentX + "_" + currentY;

						cell.Controls.Add(image);
					}
					else
					{
						ImageButton image = new ImageButton();
						image.ImageUrl = "~/Images/Sprites/Icons/no-image-small.png";
						image.ToolTip = "Move Here";
						image.Click += OnTileClick;

						cell.Controls.Add(image);
					}
				}
			}
		}

		void ApplyTile( TableCell cell, Tile tile )
		{
			SpriteDisplayObject tileDispObj = tile.DisplayObject as SpriteDisplayObject;
			if( tileDispObj == null )
			{
				tileDispObj = World.DefaultTile.DisplayObject as SpriteDisplayObject;
			}

			if( tileDispObj != null )
			{
				string imageUrl = string.Empty;
				if( tileDispObj.ImageUrl.StartsWith("~") )
				{
					imageUrl = tileDispObj.ImageUrl.Substring(1);
				}
				else
				{
					imageUrl = tileDispObj.ImageUrl;
				}

				cell.Style.Add(HtmlTextWriterStyle.BackgroundImage, imageUrl);
				cell.Style.Add(HtmlTextWriterStyle.Width, tileDispObj.ScreenWidth.ToString() + "px");
				cell.Style.Add(HtmlTextWriterStyle.Height, tileDispObj.ScreenHeight.ToString() + "px");
			}
			else
			{
				Trace.Write("tile and defaultTile did not have a SpriteDisplayObject referenced, no background loaded");
			}
		}

		public Position SelectedPosition
		{
			get { return m_SelectedPosition; }
			set { m_SelectedPosition = value; }
		}
		Position m_SelectedPosition;
	}
}