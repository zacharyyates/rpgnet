/* Zachary Yates
 * Copyright 2007 YatesMorrison Software, LLC.
 * 11/3/2007
 */

using System;
using YatesMorrison.RolePlay.BattleFramework;

namespace YatesMorrison.RolePlay
{
	public class Actor
	{
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}
		string m_Name = string.Empty;

		public string Description
		{
			get { return m_Description; }
			set { m_Description = value; }
		}
		string m_Description = string.Empty;

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

		public virtual string GetDebugString()
		{
			return Name;
		}
	}
}