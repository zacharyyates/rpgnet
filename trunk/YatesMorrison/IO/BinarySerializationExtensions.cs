/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 1.30.2009
 */
namespace YatesMorrison.IO
{
	using System.IO;
	using System.Runtime.Serialization.Formatters.Binary;

	public static class BinarySerializationExtensions
	{
		public static byte[] ToByte(this object graph) 
		{
			BinaryFormatter binFormatter = new BinaryFormatter();
			using (MemoryStream ms = new MemoryStream())
			{
				binFormatter.Serialize(ms, graph);
				return ms.ToArray();
			}
		}

		public static object ToInstance(this byte[] bytes)
		{
			BinaryFormatter binFormatter = new BinaryFormatter();
			using (MemoryStream ms = new MemoryStream(bytes))
			{
				return binFormatter.Deserialize(ms);
			}
		}

		public static T ToInstance<T>(this byte[] bytes)
			where T : class
		{
			return ToInstance(bytes) as T;
		}
	}
}