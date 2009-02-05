/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 01.31.2008
 */

using System.ServiceModel;

namespace YatesMorrison.RolePlay.BattleFramework
{
	[ServiceContract]
	public interface IBattleEvents
	{
		[OperationContract(IsOneWay = true)]
		void OnActorMoved( string actorId, ObjectPosition toPosition );
	}

	public class BattleEventSubscriptionManager : SubscriptionManager<IBattleEvents>, ISubscriptionManager<IBattleEvents> { }

	public class BattleEventPublishService : PublishService<IBattleEvents>, IBattleEvents
	{
		public void OnActorMoved( string actorId, ObjectPosition toPosition )
		{
			FireEvent(actorId, toPosition);
		}
	}
}