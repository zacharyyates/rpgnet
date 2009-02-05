/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 02.06.2008
 */

using System.Collections.Generic;
using System.ServiceModel;
using System;

namespace YatesMorrison.RolePlay.BattleFramework
{
	[ServiceContract(
		Namespace="http://yatesmorrison.com/RolePlay")]
	public interface IRemotePlayerManager
	{
		[OperationContract]
		string Connect( string clientName );
		[OperationContract]
		void Disconnect( string clientName );
	}

	public class RemotePlayerManager : IRemotePlayerManager
	{
		public static Dictionary<string, PlayerConnection> Clients
		{
			get { return m_Clients; }
		}
		static Dictionary<string, PlayerConnection> m_Clients = new Dictionary<string,PlayerConnection>();
		static int m_PlayerCount;

		static string NewRemotePlayerViewAddress()
		{
			return string.Format("http://localhost/BattleServer/RemotePlayers/{0}", m_PlayerCount++);
		}

		#region PlayerConnected Event
		public static event EventHandler<PlayerEventArgs> PlayerConnected
		{
			add { s_PlayerDisconnected += value; }
			remove { s_PlayerDisconnected -= value; }
		}
		static void OnPlayerConnected( PlayerEventArgs e )
		{
			if( s_PlayerDisconnected != null )
			{
				s_PlayerDisconnected(null, e);
			}
		}
		static EventHandler<PlayerEventArgs> s_PlayerConnected;
		#endregion

		#region PlayerDisconnected Event
		public static event EventHandler<PlayerEventArgs> PlayerDisconnected
		{
			add { s_PlayerDisconnected += value; }
			remove { s_PlayerDisconnected -= value; }
		}
		static void OnPlayerDisconnected( PlayerEventArgs e )
		{
			if( s_PlayerDisconnected != null )
			{
				s_PlayerDisconnected(null, e);
			}
		}
		static EventHandler<PlayerEventArgs> s_PlayerDisconnected;
		#endregion

		public string Connect( string clientName )
		{
			string remotePlayerViewAddress = NewRemotePlayerViewAddress();

			PlayerConnection playerConn = new PlayerConnection
			{
				ClientName = clientName,
				RemotePlayerViewAddress = remotePlayerViewAddress
			};
			m_Clients.Add(clientName, playerConn);
			//OnPlayerConnected(new PlayerEventArgs { PlayerConnection = playerConn });

			return remotePlayerViewAddress;
		}

		public void Disconnect( string clientName )
		{
			PlayerConnection playerConn = m_Clients[clientName];
			m_Clients.Remove(clientName);
			OnPlayerDisconnected(new PlayerEventArgs { PlayerConnection = playerConn });
		}
	}

	public class PlayerEventArgs : EventArgs
	{
		public PlayerConnection PlayerConnection { get; set; }
	}

	public struct PlayerConnection
	{
		public string ClientName { get; set; }
		public string RemotePlayerViewAddress { get; set; }
	}
}