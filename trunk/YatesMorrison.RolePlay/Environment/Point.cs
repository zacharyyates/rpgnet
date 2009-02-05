/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2/3/2009
 */
namespace YatesMorrison.RolePlay
{
	using System;
	using YatesMorrison.Math;

	[Serializable]
	public struct Point
	{
		public Point(double x, double y, double z)
		{
			m_X = x;
			m_Y = y;
			m_Z = z;
		}

		public double X
		{
			get { return m_X; }
		}
		double m_X;

		public double Y
		{
			get { return m_Y; }
		}
		double m_Y;

		public double Z
		{
			get { return m_Z; }
		}
		double m_Z;

		public double DistanceTo(Point point)
		{
			return MathExtensions.Distance(
				this.X, this.Y, this.Z, 
				point.X, point.Y, point.Z);
		}
	}
}