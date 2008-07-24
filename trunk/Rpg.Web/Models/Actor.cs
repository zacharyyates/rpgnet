/* Zachary Yates
 * Copyright 2007 YatesMorrison Software, LLC.
 * 11/3/2007
 */

namespace YatesMorrison.Rpg
{
	public class Actor
	{
		public virtual string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}
		string m_Name;

		public string Description { get; set; }

		public virtual double Weight
		{
			get { return m_Weight; }
			set { m_Weight = value; }
		}
		protected double m_Weight = 0;

		public double Height { get; set; }

		public virtual SizeCategory SizeCategory
		{
			get { return m_SizeCategory; }
			set { m_SizeCategory = value; }
		}
		protected SizeCategory m_SizeCategory;

		public string Alignment { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}