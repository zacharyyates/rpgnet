/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 1.30.2009
 */
namespace YatesMorrison.IO
{
	using System.IO;
	using System.IO.Compression;
	using System.Diagnostics;

	public static class CompressionExtensions
	{
		public static byte[] Compress(this byte[] sourceBuffer)
		{
			using (MemoryStream destinationStream = new MemoryStream())
			{
				Compress(sourceBuffer, destinationStream);
				byte[] outputBuffer = destinationStream.ToArray();
				Debug.WriteLine(string.Format("Compression complete. Source: {0}, Output: {1}", sourceBuffer.Length, outputBuffer.Length));
				return destinationStream.ToArray();
			}
		}

		public static void Compress(this byte[] sourceBuffer, Stream destinationStream)
		{
			using (GZipStream outputStream = new GZipStream(destinationStream, CompressionMode.Compress))
			{
				outputStream.Write(sourceBuffer, 0, sourceBuffer.Length);
			}
		}

		public static byte[] Decompress(this byte[] sourceBuffer)
		{
			using (MemoryStream destinationStream = new MemoryStream())
			{
				Decompress(sourceBuffer, destinationStream);
				byte[] outputBuffer = destinationStream.ToArray();
				Debug.WriteLine(string.Format("Decompression complete. Source: {0}, Output: {1}", sourceBuffer.Length, outputBuffer.Length));
				return outputBuffer;
			}
		}

		public static void Decompress(this byte[] sourceBuffer, Stream destinationStream)
		{
			using (MemoryStream sourceStream = new MemoryStream(sourceBuffer))
			using (GZipStream inputStream = new GZipStream(sourceStream, CompressionMode.Decompress, false))
			{
				byte[] outputBuffer = new byte[65536]; // arbitrary length, possibly change if causes problems
				int decompressedLength = inputStream.Read(outputBuffer, 0, outputBuffer.Length);
				destinationStream.Write(outputBuffer, 0, decompressedLength);
			}
		}
	}
}