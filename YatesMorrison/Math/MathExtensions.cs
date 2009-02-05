/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2/3/2009
 */
namespace YatesMorrison.Math
{
	using System;

	public static class MathExtensions
	{
		public static double Distance(double x1, double y1, double z1, double x2, double y2, double z2)
		{
			var dx = x2 - x1;
			var dy = y2 - y1;
			var dz = z2 - z1;
			var distance = Math.Sqrt(dx * dx + dy * dy + dz * dz);
			return distance;
		}
	}
}