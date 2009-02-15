/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.3.2009
 */
namespace YatesMorrison.RolePlay
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	[Serializable]
	public class Game
	{
		public Game()
		{
			// todo: should the log use a static event aggregator/dispatcher? or should it be instance based and use .net events?
		}

		public ReadOnlyCollection<Actor> Actors
		{
			get { return new ReadOnlyCollection<Actor>(m_Actors); }
		}
		List<Actor> m_Actors = new List<Actor>();

		public void Add(Actor actor)
		{
			m_Actors.Add(actor);
		}
		public void Remove(Actor actor)
		{
			m_Actors.Remove(actor);
		}

		public void Add(Character character)
		{
			m_Actors.Add(character);
			character.Action += HandleAction;
		}
		public void Remove(Character character)
		{
			character.Action -= HandleAction;
			m_Actors.Remove(character);
		}

		protected virtual void HandleAction(object sender, ActionEventArgs e)
		{
			e.Ability.Use();
		}

		public Map Map { get; set; }

		public Log Log
		{
			get { return m_Log; }
		}
		Log m_Log = new Log();
	}
}