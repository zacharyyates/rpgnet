// � 2006 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace ServiceModelEx
{
	public abstract class PublishService<T> where T : class
	{
		protected static void FireEvent( params object[] args )
		{
			StackFrame stackFrame = new StackFrame(1);
			string methodName = stackFrame.GetMethod().Name;
			//Parse out explicit interface implementation
			if( methodName.Contains(".") )
			{
				string[] parts = methodName.Split('.');
				methodName = parts[parts.Length - 1];
			}
			FireEvent(methodName, args);
		}
		static void FireEvent( string methodName, params object[] args )
		{
			PublishPersistent(methodName, args);
			PublishTransient(methodName, args);
		}
		static void PublishPersistent( string methodName, params object[] args )
		{
			T[] subscribers = SubscriptionManager<T>.GetPersistentList(methodName);
			Publish(subscribers, true, methodName, args);
		}
		static void PublishTransient( string methodName, params object[] args )
		{
			T[] subscribers = SubscriptionManager<T>.GetTransientList(methodName);
			Publish(subscribers, false, methodName, args);
		}
		static void Publish( T[] subscribers, bool closeSubscribers, string methodName, params object[] args )
		{
			WaitCallback fire = delegate( object subscriber )
								{
									Invoke(subscriber as T, methodName, args);
									if( closeSubscribers )
									{
										using( subscriber as IDisposable )
										{ }
									}
								};
			Action<T> queueUp = delegate( T subscriber )
								{
									ThreadPool.QueueUserWorkItem(fire, subscriber);
								};
			Array.ForEach(subscribers, queueUp);
		}
		static void Invoke( T subscriber, string methodName, object[] args )
		{
			Debug.Assert(subscriber != null);
			Type type = typeof(T);
			MethodInfo methodInfo = type.GetMethod(methodName);
			try
			{
				methodInfo.Invoke(subscriber, args);
			}
			catch( Exception e )
			{
				Trace.WriteLine(e.Message);
			}
		}
	}
}