/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2/3/2009
 */
namespace YatesMorrison.RolePlay
{
	public struct Range
	{
		public Range(double maximum, double nominal)
		{
			m_Maximum = maximum;
			m_Nominal = nominal;
		}

		public double Maximum
		{
			get { return m_Maximum; }
		}
		double m_Maximum;

		public double Nominal
		{
			get { return m_Nominal; }
		}
		double m_Nominal;
	}
}