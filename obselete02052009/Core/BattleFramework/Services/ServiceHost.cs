/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 02.06.2008
 */

using System;
using System.ServiceModel;

namespace YatesMorrison
{
	public class ServiceHost<T> : ServiceHost
	{
		public ServiceHost() : base(typeof(T)) { }
		public ServiceHost( params string[] baseAddresses ) : base(typeof(T), Convert(baseAddresses)) { }
		public ServiceHost( params Uri[] baseAddresses ) : base(typeof(T), baseAddresses) { }

		public ServiceHost( T singletonInstance ) : base(singletonInstance) { }
		public ServiceHost( T singletonInstance, params Uri[] baseAddresses ) : base(singletonInstance, baseAddresses) { }
		public ServiceHost( T singletonInstance, params string[] baseAddresses ) : base(singletonInstance, Convert(baseAddresses)) { }

		static Uri[] Convert( params string[] addresses )
		{
			Converter<string, Uri> convert =
				delegate( string address )
				{
					return new Uri(address);
				};

			return Array.ConvertAll<string, Uri>(addresses, convert);
		}
	}
}