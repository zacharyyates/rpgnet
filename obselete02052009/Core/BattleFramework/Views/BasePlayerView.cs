/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 01.29.2008
 */

using System;

namespace YatesMorrison.RolePlay.BattleFramework
{
	public abstract class BasePlayerView : 
		IView, 
		IBattleEvents,
		IDisposable
	{
		public string ActorId { get; set; }

		public double SightRange
		{
			get;
			set;
		}

		protected bool IsInSightRange( WorldActor worldObj )
		{
			throw new NotImplementedException();
		}

		protected bool IsInLineOfSight( WorldActor worldObj )
		{
			throw new NotImplementedException();
		}

		public World World
		{
			get { return m_RealWorld; }
		}
		protected World m_RealWorld;

		#region IDisposable Implementation
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose( bool disposing )
		{
			if( disposing )
			{
				// Make sure there are no more references to this obj
				//Detatch();
			}
		}
		#endregion

		#region IBattleEvents Members

		public virtual void OnActorMoved( string actorId, ObjectPosition toPosition )
		{
			IWorldActor actor = m_RealWorld.GetActorBy(actorId);
			actor.Position = toPosition;
		}

		#endregion
	}
}