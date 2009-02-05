/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 02.06.2008
 */

using System.ServiceModel;
using System.Collections.Generic;

namespace YatesMorrison.RolePlay.BattleFramework
{
	[ServiceContract(
		CallbackContract = typeof(IBattleEvents),
		Namespace = "http://yatesmorrison.com/RolePlay/")]
	public interface IServerRemotePlayerView
	{
		[OperationContract(IsInitiating = true)]
		void Connect();
		[OperationContract(IsTerminating = true)]
		void Disconnect();
	}

	//TODO: Change this class so it is a service implementation, and add a callback contract (IBattleEvents)
	[ServiceBehavior(
		InstanceContextMode = InstanceContextMode.Single)]
	public class ServerRemotePlayerView :
		IView,
		IBattleEvents,
		IServerRemotePlayerView
	{
		public ServerRemotePlayerView() { }

		IBattleEvents m_Callback;

		#region IServerRemotePlayerView Members

		void IServerRemotePlayerView.Connect()
		{
			m_Callback = OperationContext.Current.GetCallbackChannel<IBattleEvents>();
		}

		void IServerRemotePlayerView.Disconnect()
		{
			m_Callback = null;
		}

		#endregion

		#region IBattleEvents Implementation

		void IBattleEvents.OnActorMoved( string actorId, ObjectPosition toPosition )
		{
			if( m_Callback != null )
			{
				m_Callback.OnActorMoved(actorId, toPosition);
			}
		}

		#endregion

		#region IView Members

		public string ActorId { get; set; }

		public World World
		{
			get { return null; }
		}

		#endregion
	}
}