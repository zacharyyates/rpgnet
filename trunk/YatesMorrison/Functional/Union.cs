/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.15.2009
 */
namespace YatesMorrison.Functional
{
	public struct Union<T1, T2>
	{
		public Union(T1 first, T2 second)
		{
			m_First = first;
			m_Second = second;
		}

		public T1 First
		{
			get { return m_First; }
		}
		T1 m_First;

		public T2 Second
		{
			get { return m_Second; }
		}
		T2 m_Second;
	}
}