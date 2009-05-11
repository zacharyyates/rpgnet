/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.26.2009
 */
namespace YatesMorrison
{
	using System;

	public static class ArrayExtensions
	{
		public static T[] Join<T>(this T[] array1, T[] array2)
		{
			if (array1 == null) throw new ArgumentNullException("array1");
			if (array2 == null) throw new ArgumentNullException("array2");

			T[] result = new T[array1.Length + array2.Length];
			array1.CopyTo(result, 0);
			array2.CopyTo(result, array1.Length);
			return result;
		}

		public static T[] SubArray<T>(this T[] array, int index)
		{
			if (array == null) throw new ArgumentNullException("array");
			if (index >= array.Length) throw new ArgumentException("index must be less than or equal to the array.Length", "index");

			T[] result = new T[array.Length - index];
			Array.Copy(array, index, result, 0, result.Length);
			return result;
		}

		public static T[] SubArray<T>(this T[] array, int index, int length)
		{
			if (array == null) throw new ArgumentNullException("array");
			if (index >= array.Length) throw new ArgumentException("index must be less than or equal to the array.Length", "index");

			T[] result = new T[length];
			Array.Copy(array, index, result, 0, length);
			return result;
		}
	}
}