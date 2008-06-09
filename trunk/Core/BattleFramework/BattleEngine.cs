/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 02.04.2008
 */

using System.ServiceModel;
using System.Collections.Generic;
using System.Diagnostics;

namespace YatesMorrison.RolePlay.BattleFramework
{
	public class BattleEngine
	{
		ServiceHost<RemotePlayerManager> m_RemotePlayerManagerHost;
		BattleEventSubscriptionManager m_SubscriptionManager;
		Dictionary<string, ServiceHost<ServerRemotePlayerView>> m_RemotePlayerHosts = new Dictionary<string, ServiceHost<ServerRemotePlayerView>>();

		public BattleEngine()
		{
			m_RemotePlayerManagerHost = new ServiceHost<RemotePlayerManager>();
			m_SubscriptionManager = new BattleEventSubscriptionManager();

			// Attach events
			RemotePlayerManager.PlayerConnected += RemotePlayerManager_PlayerConnected;
			RemotePlayerManager.PlayerDisconnected += RemotePlayerManager_PlayerDisconnected;
		}

		void RemotePlayerManager_PlayerConnected( object sender, PlayerEventArgs e )
		{
			// Create new remote player view and attach it to the engine
			ServerRemotePlayerView view = new ServerRemotePlayerView();
			view.ActorId = e.PlayerConnection.ClientName;

			ServiceHost<ServerRemotePlayerView> host = new ServiceHost<ServerRemotePlayerView>(view);
			host.AddServiceEndpoint(typeof(ServerRemotePlayerView), new WSHttpBinding(), e.PlayerConnection.RemotePlayerViewAddress);

			m_RemotePlayerHosts.Add(view.ActorId, host);

			AttachView(view);
			string msg = string.Format("View Connected: {0} {1}", view.ActorId, e.PlayerConnection.RemotePlayerViewAddress);
			Debug.WriteLine(msg);
		}

		void RemotePlayerManager_PlayerDisconnected( object sender, PlayerEventArgs e )
		{
			ServerRemotePlayerView view = m_Views[e.PlayerConnection.ClientName] as ServerRemotePlayerView;
			if( view != null )
			{
				DetatchView(view);
			}
		}

		public void Open()
		{
			m_RemotePlayerManagerHost.Open();
			Debug.WriteLine("RemotePlayerManagerHost open");
		}

		public void Close()
		{
			m_RemotePlayerManagerHost.Close();
		}

		public Dictionary<string, IView> Views
		{
			get { return m_Views; }
			set { m_Views = value; }
		}
		Dictionary<string, IView> m_Views = new Dictionary<string, IView>();

		public void AttachView( IView view )
		{
			m_SubscriptionManager.Subscribe(view as IBattleEvents, "OnActorMoved");
			m_Views.Add(view.ActorId, view);
		}

		public void DetatchView( IView view )
		{			
			m_SubscriptionManager.Unsubscribe(view as IBattleEvents, "OnActorMoved");
			m_Views.Remove(view.ActorId);
		}
	}
}