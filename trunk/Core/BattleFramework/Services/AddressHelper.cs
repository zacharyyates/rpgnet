/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 02.07.2008
 */

using System.ServiceModel;
using System;
namespace YatesMorrison
{
	public static class AddressHelper
	{
		public static EndpointAddress ToEndpointAddress( string address )
		{
			return new EndpointAddress(ToUri(address));
		}

		public static Uri ToUri( string address )
		{
			return new Uri(address);
		}
	}
}