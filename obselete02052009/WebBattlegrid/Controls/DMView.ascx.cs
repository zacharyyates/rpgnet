/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/27/2008
 */

using System;
using System.Web.UI;
using YatesMorrison.RolePlay.BattleFramework;
using YatesMorrison.RolePlay.BattleFramework.Web;
using System.Web.UI.WebControls;

namespace WebBattlegrid.Controls
{
	public partial class DMView : 
		UserControl,
		IView
	{
		WebViewRenderer m_Renderer = new WebViewRenderer();

		protected void Page_Load( object sender, EventArgs e )
		{
			if( !IsPostBack )
			{
				Render(CreateTestWorld());
			}
		}

		World CreateTestWorld()
		{
			World world = new World
			{
				Size = new Size
				{
					Width = 10,
					Height = 10
				},
				DefaultTile = new Tile
				{
					DisplayObject = new SpriteDisplayObject
					{
						ImageUrl = "~/Images/Sprites/Backgrounds/Sq100Gray.png",
						ScreenWidth = 100,
						ScreenHeight = 100
					}
				},
				NullTile = new Tile
				{
					DisplayObject = new SpriteDisplayObject
					{
						ImageUrl = "~/Images/Sprites/Backgrounds/Sq100White.png",
						ScreenWidth = 100,
						ScreenHeight = 100
					}
				}
			};

			world.FillDefault();

			CombatActor actor1 = new CombatActor
			{
				DisplayObject = new SpriteDisplayObject
				{
					ImageUrl = "~/Images/Sprites/Characters/LinkSprite.png",
					ScreenWidth = 42,
					ScreenHeight = 55,
					ActorID = "Chase"
				},
				Position = new Position
				{
					X = 0,
					Y = 0
				}
			};
			world.Objects.Add(actor1);
			return world;
		}

		#region IView Members

		public void Render( World world )
		{		
			m_Renderer.Table = tblBattleGrid;
			m_Renderer.OnCharacterClick = new ImageClickEventHandler(OnCharacterClick);
			m_Renderer.OnTileClick = new ImageClickEventHandler(OnTileClick);
			m_Renderer.World = world;

			m_Renderer.Render();
		}

		protected void OnCharacterClick( object sender, ImageClickEventArgs e )
		{
			// Get selected character
			ImageButton ibSender = sender as ImageButton;
			string[] positionStr = ibSender.ID.Split('_');
			int x = int.Parse(positionStr[0]);
			int y = int.Parse(positionStr[1]);

			m_Renderer.SelectedPosition = new Position { X = x, Y = y };

			Render(CreateTestWorld());
		}

		protected void OnTileClick( object sender, ImageClickEventArgs e )
		{

		}

		#endregion
	}
}