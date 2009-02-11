/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.10.2009
 */
namespace YatesMorrison.RolePlay
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class Log
	{
		public ReadOnlyCollection<Entry> Entries
		{
			get { return new ReadOnlyCollection<Entry>(m_Entries); }
		}
		List<Entry> m_Entries = new List<Entry>();
	}

	public class Entry
	{
		public string Message { get; set; }
		public DateTime EnteredAt { get; set; }
		public EntryType Type { get; set; }
	}

	public enum EntryType
	{
		Combat,
		Story,
		Talk,
		Status
	}
}