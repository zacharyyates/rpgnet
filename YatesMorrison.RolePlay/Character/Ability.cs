/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2/3/2009
 */
namespace YatesMorrison.RolePlay
{
	public abstract class Ability
	{
		public Ability() { }
		public Ability(string name, string abbreviation, string description)
		{
			Name = name;
			Abbreviation = abbreviation;
			Description = description;
		}

		public virtual string Name { get; set; }  // todo: create an interface for these 3 properties
		public virtual string Abbreviation { get; set; }
		public virtual string Description { get; set; }

		public abstract void Use(Actor initiator, Actor target);
	}
}