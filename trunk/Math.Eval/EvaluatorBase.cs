/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/24/2007
 */

using System;

namespace YatesMorrison.Math.Eval
{
	public class EvaluatorBase
	{
		public EvaluatorBase() { }

		public virtual double Eval(params double[] args)
		{
			return 0.0;
		}
	}
}