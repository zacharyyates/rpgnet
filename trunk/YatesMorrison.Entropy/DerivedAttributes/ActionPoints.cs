/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/6/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class ActionPoints : DerivedAttribute
	{
		public ActionPoints() : base("Action Points", "AP", "", "Agility", 0) { }

		public override double Base
		{
			get { return Math.Floor(Parent.Total / 2) + 5; }
		}
	}
}