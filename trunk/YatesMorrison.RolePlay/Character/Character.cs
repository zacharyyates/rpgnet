/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1.31.2009
 */
namespace YatesMorrison.RolePlay
{
	using System;

	[Serializable]
	public class Character : Actor
	{
		// [ZLY 11.04.2007] I think all of the attributes here can be abstracted into an attribute class, 
		// then dependency injected into a character object at runtime to abstract the entire system from the rule set.
		// However, that would be out of scope for this project, so I leave it up to myself at a later date, 
		// or someone else all together...
		// Or maybe I'll just do it...
		// [ZLY 6.24.2008] I obviously did it already.
		// [ZLY 1.31.2009] Crap. Have to change all of it.

		public event EventHandler<ActionEventArgs> Action
		{
			add { m_Action += value; }
			remove { m_Action -= value; }
		}
		event EventHandler<ActionEventArgs> m_Action;

		protected void OnAction(ActionEventArgs e)
		{
			if (m_Action != null) m_Action(this, e);
		}

		public void Use(Ability ability, Actor target)
		{
			OnAction(new ActionEventArgs()
			{
				Initiator = this,
				Ability = ability,
				Target = target
			});
		}
	}
}