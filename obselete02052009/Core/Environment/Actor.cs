/* Zachary Yates
 * Copyright 2007 YatesMorrison Software, LLC.
 * 11/3/2007
 */

namespace YatesMorrison.RolePlay
{
	public class Actor
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public virtual double Weight
		{
			get { return m_Weight; }
			set { m_Weight = value; }
		}
		protected double m_Weight = 0;

		public virtual SizeCategory SizeCategory
		{
			get { return m_SizeCategory; }
			set { m_SizeCategory = value; }
		}
		protected SizeCategory m_SizeCategory;

		public override string ToString()
		{
			return Name;
		}
	}
}