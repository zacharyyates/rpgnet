/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1.31.2009
 */
namespace YatesMorrison.RolePlay
{
	using System;

	[Serializable]
	public class Requisite
	{
		public string AspectName { get; set; }
		public string NotSatisfiedMessage { get; set; }
		
		public Comparison Operator { get; set; }
		public double Value { get; set; }

		public bool IsSatisfied(double value)
		{
			switch (Operator)
			{
				case Comparison.EqualTo: return (Value == value);
				case Comparison.NotEqualTo: return (Value != value);
				case Comparison.GreaterThan: return (Value > value);
				case Comparison.GreaterThanOrEqualTo: return (Value >= value);
				case Comparison.LessThan: return (Value < value);
				case Comparison.LessThanOrEqualTo: return (Value <= value);

				default: return false;
			}
		}
	}

	public enum Comparison
	{
		LessThan,
		LessThanOrEqualTo,
		EqualTo,
		NotEqualTo,
		GreaterThanOrEqualTo,
		GreaterThan
	}
}