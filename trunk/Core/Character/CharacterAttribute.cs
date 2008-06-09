/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/4/2007
 */

namespace YatesMorrison.RolePlay
{
	public class CharacterAttribute
	{
		protected Character m_Character = null;

		public CharacterAttribute( Character character )
		{
			m_Character = character;
		}
		public CharacterAttribute( Character character, string name, double simpleScore ) : 
			this(character)
		{
			Name = name;
			SimpleScore = simpleScore;
		}

		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}
		string m_Name = string.Empty;
		
		protected double EffectModifierTotal
		{
			get{ return m_Character.GetEffectModifierTotalFor(Name); }
		}

		public virtual double SimpleScore
		{
			get { return m_SimpleScore; }
			set { m_SimpleScore = value; }
		}
		double m_SimpleScore = 0;

		public virtual double GetCalculatedScore( double simpleScore )
		{
			return simpleScore;
		}
	}

	/// <summary>
	/// TODO: Consider building this class with a system specific factory
	/// </summary>
	public class DependentCharacterAttribute : CharacterAttribute
	{
		public DependentCharacterAttribute( Character character ) : base(character) { }
		public DependentCharacterAttribute( Character character, string name, double simpleScore, string keyAttribute ) : 
			base(character, name, simpleScore) 
		{
			KeyAttribute = keyAttribute;
		}

		public string KeyAttribute
		{
			get { return m_KeyAttribute; }
			set { m_KeyAttribute = value; }
		}
		string m_KeyAttribute = string.Empty;

		protected double KeyAttributeValue
		{
			get { return m_Character.GetEffectedScoreFor(KeyAttribute); }
		}

		public override double GetCalculatedScore( double simpleScore )
		{
			return simpleScore + KeyAttributeValue;
		}
	}
}