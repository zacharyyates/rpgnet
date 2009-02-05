/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.1.2009
 */
namespace YatesMorrison.Linq
{
	using System.Data.Linq;
	using YatesMorrison.IO;

	public static class BinaryExtensions
	{
		public static Binary ToBinary(this object me)
		{
			return new Binary(me.ToByte());
		}

		public static T ToInstance<T>(this Binary me)
			where T : class
		{
			return BinaryExtensions.ToInstance<T>(me.ToArray());
		}

		public static Binary Compress(this Binary sourceBinary)
		{
			return new Binary(CompressionExtensions.Compress(sourceBinary.ToArray()));
		}

		public static byte[] Decompress(this Binary sourceBinary)
		{
			return CompressionExtensions.Decompress(sourceBinary.ToArray());
		}
	}
}