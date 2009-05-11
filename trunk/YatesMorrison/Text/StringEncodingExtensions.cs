/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.26.2009
 */
namespace YatesMorrison.Text
{
	using System.Text;

	public static class StringEncodingExtensions
	{
		public static byte[] ToByte(this string str)
		{
			return Encoding.Default.GetBytes(str);
		}
		public static byte[] ToByte(this string str, Encoding encoding)
		{
			return encoding.GetBytes(str);
		}
		public static byte[] ToByte(this string str, EncodingType encoding)
		{
			return GetEncoding(encoding).GetBytes(str);
		}

		static Encoding GetEncoding(EncodingType textEncoding)
		{
			switch (textEncoding)
			{
				case EncodingType.ASCII: return Encoding.ASCII;
				case EncodingType.BigEndianUnicode: return Encoding.BigEndianUnicode;
				case EncodingType.Unicode: return Encoding.Unicode;
				case EncodingType.UTF32: return Encoding.UTF32;
				case EncodingType.UTF7: return Encoding.UTF7;
				case EncodingType.UTF8: return Encoding.UTF8;
				
				default:
				case EncodingType.Default: return Encoding.Default;
			}
		}
	}

	public enum EncodingType
	{
		ASCII,
		BigEndianUnicode,
		Default,
		Unicode,
		UTF32,
		UTF7,
		UTF8,
	}
}