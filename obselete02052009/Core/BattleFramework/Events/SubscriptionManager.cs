/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 02.04.2008
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;

namespace YatesMorrison
{
	public abstract class SubscriptionManager<T> where T : class
	{
		static Dictionary<string, List<T>> m_SubscriberStore;

		static SubscriptionManager()
		{
			m_SubscriberStore = new Dictionary<string, List<T>>();
			string[] methods = GetOperations();
			Action<string> insert = delegate( string methodName )
									{
										m_SubscriberStore.Add(methodName, new List<T>());
									};
			Array.ForEach(methods, insert);
		}
		
		static string[] GetOperations()
		{
			MethodInfo[] methods = typeof(T).GetMethods(BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
			List<string> operations = new List<string>(methods.Length);

			Action<MethodInfo> add = delegate( MethodInfo method )
									  {
										  Debug.Assert(!operations.Contains(method.Name));
										  operations.Add(method.Name);
									  };
			Array.ForEach(methods, add);
			return operations.ToArray();
		}

		//Transient subscriptions management 
		internal static T[] GetSubscriberList( string eventOperation )
		{
			lock( typeof(SubscriptionManager<T>) )
			{
				Debug.Assert(m_SubscriberStore.ContainsKey(eventOperation));
				if( m_SubscriberStore.ContainsKey(eventOperation) )
				{
					List<T> list = m_SubscriberStore[eventOperation];
					return list.ToArray();
				}
				return new T[] { };
			}
		}
		static void AddTransient( T subscriber, string eventOperation )
		{
			lock( typeof(SubscriptionManager<T>) )
			{
				List<T> list = m_SubscriberStore[eventOperation];
				if( list.Contains(subscriber) )
				{
					return;
				}
				list.Add(subscriber);
			}
		}
		static void RemoveTransient( T subscriber, string eventOperation )
		{
			lock( typeof(SubscriptionManager<T>) )
			{
				List<T> list = m_SubscriberStore[eventOperation];
				list.Remove(subscriber);
			}
		}

		public void Subscribe( T subscriber, string eventOperation )
		{
			lock( typeof(SubscriptionManager<T>) )
			{
				if( String.IsNullOrEmpty(eventOperation) == false )
				{
					AddTransient(subscriber, eventOperation);
				}
				else
				{
					string[] methods = GetOperations();
					Action<string> addTransient = delegate( string methodName )
												  {
													  AddTransient(subscriber, methodName);
												  };
					Array.ForEach(methods, addTransient);
				}
			}
		}
		public void Unsubscribe( T subscriber, string eventOperation )
		{
			lock( typeof(SubscriptionManager<T>) )
			{
				if( String.IsNullOrEmpty(eventOperation) == false )
				{
					RemoveTransient(subscriber, eventOperation);
				}
				else
				{
					string[] methods = GetOperations();
					Action<string> removeTransient = delegate( string methodName )
													 {
														 RemoveTransient(subscriber, methodName);
													 };
					Array.ForEach(methods, removeTransient);
				}
			}
		}
	}

	public interface ISubscriptionManager<T>
	{
		void Subscribe( T subscriber, string eventOperation );
		void Unsubscribe( T subscriber, string eventOperation );
	}
}