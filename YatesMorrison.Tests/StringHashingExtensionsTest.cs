namespace YatesMorrison.Tests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using YatesMorrison.Security.Cryptography;
	using YatesMorrison.Text;

	[TestClass]
	public class StringHashingExtensionsTest
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void TestToHash1()
		{
			string plain = "This is a plain string !@#$%";
			string hashed = plain.ToHash();
			Assert.AreNotEqual(plain, hashed);
			TestContext.WriteLine("Originial {0}, Hashed {1}", plain, hashed);
			Assert.IsTrue(plain.VerifyAgainstHash(hashed));
		}

		[TestMethod]
		public void TestToHashSHA512()
		{
			string plain = "This is a plain string !@#$%";
			string hashed = plain.ToHash(HashAlgorithmType.SHA512);
			Assert.AreNotEqual(plain, hashed);
			TestContext.WriteLine("Originial {0}, Hashed {1}", plain, hashed);
			Assert.IsTrue(plain.VerifyAgainstHash(hashed, HashAlgorithmType.SHA512));
		}

		[TestMethod]
		public void TestToHashWithSalt()
		{
			string plain = "This is a plain string !@#$%";
			byte[] saltBytes = "SALT".ToByte(EncodingType.UTF8);
			string hashed = plain.ToHash(HashAlgorithmType.SHA512, saltBytes);
			Assert.AreNotEqual(plain, hashed);
			TestContext.WriteLine("Originial {0}, Hashed {1}", plain, hashed);
			Assert.IsTrue(plain.VerifyAgainstHash(hashed, HashAlgorithmType.SHA512, saltBytes));
		}
	}
}