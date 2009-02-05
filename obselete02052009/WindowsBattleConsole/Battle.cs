/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 01.31.2008
 */

using System.ServiceModel;
using System.Windows.Forms;
using WindowsBattleConsole.Controls;

using YatesMorrison.RolePlay.BattleFramework;
using YatesMorrison;

namespace WindowsBattleConsole
{
	public partial class Battle : Form
	{
		public Battle()
		{
			InitializeComponent();
		}

		World CreateTestWorld()
		{
			World world = new World
			{
				Size = new ObjectSize
				{
					Width = 10,
					Height = 5
				}
			};

			WorldActor link = new WorldActor
			{
				ActorId = "Link!",
				DisplayObject = new SpriteDisplayObject
				{
					ImagePath = @"C:\Users\Zachary\Pictures\Sprites\Characters\LinkSprite.png"
				},
				Position = new ObjectPosition
				{
					X = 1,
					Y = 1
				}
			};
			WorldActor ogre = new WorldActor
			{
				ActorId = "OgreMan! :(",
				DisplayObject = new SpriteDisplayObject
				{
					ImagePath = @"C:\Users\Zachary\Pictures\Sprites\Characters\OgreSprite.png"
				},
				Position = new ObjectPosition
				{
					X = 1,
					Y = 2
				}
			};

			world.FillDefault();
			world.Actors.Add(ogre);
			world.Actors.Add(link);

			return world;
		}

		BattleEngine m_BattleEngine = new BattleEngine();

		void LoadBattleEngine()
		{
			// Open service host
			m_BattleEngine.Open();
		}

		void Battle_Load( object sender, System.EventArgs e )
		{
			bgcMain.World = CreateTestWorld();
		}		

		void newToolStripMenuItem_Click( object sender, System.EventArgs e )
		{
			LoadBattleEngine();
		}

		void exitToolStripMenuItem_Click( object sender, System.EventArgs e )
		{
			Application.Exit();
		}

		void Battle_FormClosing( object sender, FormClosingEventArgs e )
		{
			if( m_BattleEngine != null )
			{
				m_BattleEngine.Close();
			}
		}

		void bgcMain_TileClick( object sender, TileClickEventArgs e )
		{
			BattleGridTile tile = sender as BattleGridTile;
			if( tile != null )
			{
				tile.Highlight = TileHighlightType.Selected;
			}
		}

		//PlayerConnection PlayerConnection
		//{
		//    get { return m_PlayerConnection; }
		//    set { m_PlayerConnection = value; }
		//}
		PlayerConnection m_PlayerConnection = new PlayerConnection();

		void joinBattleToolStripMenuItem1_Click( object sender, System.EventArgs e )
		{
			JoinBattle joinBattleForm = new JoinBattle();
			joinBattleForm.Show(this);
		}

		public void ConnectToBattleServer( string battleServerAddress, string actorId )
		{
			m_PlayerConnection.ClientName = actorId;
			using( RemotePlayerManagerClient proxy = new RemotePlayerManagerClient() )
			{
				proxy.Open();
				m_PlayerConnection.RemotePlayerViewAddress = proxy.Connect(actorId); // TODO: This call is timing out
				proxy.Close();
			}

			MessageBox.Show("Connected! " + actorId + " " + m_PlayerConnection.RemotePlayerViewAddress);
		}
	}
}