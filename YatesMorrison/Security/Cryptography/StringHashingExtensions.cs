/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.26.2009
 */
namespace YatesMorrison.Security.Cryptography
{
	using System;
	using System.Security.Cryptography;
	using YatesMorrison.Text;

	public static class StringHashingExtensions
	{
		// todo: xml comment these methods
		public static string ToHash(this string str)
		{
			return ToHash(str, HashAlgorithmType.MD5);
		}
		public static string ToHash(this string str, HashAlgorithmType type)
		{
			return ToHash(str, type, RandomSalt());
		}
		public static string ToHash(this string str, HashAlgorithmType type, byte[] salt)
		{
			if (salt == null) salt = RandomSalt();
			// convert to byte[] and salt
			byte[] plainBytes = str.ToByte(EncodingType.UTF8);
			byte[] plainWithSaltBytes = plainBytes.Join(salt);
			// compute hash
			var hash = GetHashAlgorithm(type);
			byte[] hashedBytes = hash.ComputeHash(plainWithSaltBytes);
			byte[] hashedWithSaltBytes = hashedBytes.Join(salt);
			return Convert.ToBase64String(hashedWithSaltBytes);
		}
		
		public static bool VerifyAgainstHash(this string str, string hashedStr)
		{
			return VerifyAgainstHash(str, hashedStr, HashAlgorithmType.MD5);
		}
		public static bool VerifyAgainstHash(this string str, string hashedStr, HashAlgorithmType type)
		{
			return VerifyAgainstHash(str, hashedStr, type, GetSalt(Convert.FromBase64String(hashedStr), type));
		}
		public static bool VerifyAgainstHash(this string str, string hashedStr, HashAlgorithmType type, byte[] salt)
		{
			byte[] hashedWithSaltBytes = Convert.FromBase64String(hashedStr);
			// verify the string is long enough
			int hashLength = GetHashLength(type);
			if (hashedWithSaltBytes.Length < hashLength) return false;

			string expectedHashedStr = ToHash(str, type, salt);
			return string.Equals(expectedHashedStr, hashedStr);
		}

		static HashAlgorithm GetHashAlgorithm(HashAlgorithmType type)
		{
			switch (type)
			{
				case HashAlgorithmType.SHA1: return new SHA1Managed();
				case HashAlgorithmType.SHA256: return new SHA256Managed();
				case HashAlgorithmType.SHA384: return new SHA384Managed();
				case HashAlgorithmType.SHA512: return new SHA512Managed();
				
				default:
				case HashAlgorithmType.MD5: return new MD5CryptoServiceProvider();
			}
		}

		/// <summary>
		/// Gets the length of a hashed value based on the <see cref="HashAlgorithmType"/>
		/// </summary>
		/// <returns>Length in bytes</returns>
		static int GetHashLength(HashAlgorithmType type)
		{
			int lengthInBits = 0;
			switch (type)
			{
				case HashAlgorithmType.SHA1: lengthInBits = 160; break;
				case HashAlgorithmType.SHA256: lengthInBits = 256; break;
				case HashAlgorithmType.SHA384: lengthInBits = 384; break;
				case HashAlgorithmType.SHA512: lengthInBits = 512; break;

				default:
				case HashAlgorithmType.MD5: lengthInBits = 128; break;
			}
			return lengthInBits / 8; // convert to bytes
		}

		/// <summary>
		/// Generates a random length, random value salt using <see cref="RNGCryptoServiceProvider" />
		/// </summary>
		static byte[] RandomSalt()
		{
			// todo: possibly specify min & max salt length in config
			int saltSize = new Random().Next(4, 8); // 4 <= saltSize <= 8
			byte[] saltBytes = new byte[saltSize];
			new RNGCryptoServiceProvider().GetNonZeroBytes(saltBytes);
			return saltBytes;
		}

		/// <summary>
		/// Returns the salt bytes from the end of a hashed byte[]
		/// </summary>
		static byte[] GetSalt(byte[] hashedWithSaltBytes, HashAlgorithmType type)
		{
			return hashedWithSaltBytes.SubArray(GetHashLength(type));	
		}
	}

	public enum HashAlgorithmType
	{
		SHA1,
		SHA256,
		SHA384,
		SHA512,
		MD5
	}
}