/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/4/2007
 */
namespace YatesMorrison.RolePlay
{
	using System;

	[Serializable]
	public class Modifier : IChildOf<Aspect>
	{
		public string AspectName { get; set; }
		public Aspect Aspect { get; set; }
		public IEffect Effect { get; set; }
		public Operator Operator { get; set; }
		public double Value { get; set; }
		
		public virtual double Bonus
		{
			get
			{
				double originalValue = Aspect.Normal;
				double value = originalValue;

				switch (Operator)
				{
					case Operator.Add: value += Value; break;
					case Operator.Multiply: value *= Value; break;
					case Operator.Subtract: value -= Value; break;
					case Operator.Divide: value /= Value; break;

					default: break;
				}

				// this property only returns the bonus, not the final score
				return value - originalValue;
			}
		}

		public void AddTo(Aspect parent)
		{
			Aspect = parent;
		}
		public void RemoveFrom(Aspect parent)
		{
			Aspect = null;
		}
	}

	public enum Operator
	{
		Add,
		Subtract,
		Multiply,
		Divide
	}
}