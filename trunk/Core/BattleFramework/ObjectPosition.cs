/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 01.26.2008
 */

using System.Runtime.Serialization;

namespace YatesMorrison.RolePlay.BattleFramework
{
	[DataContract]
	public class ObjectPosition
	{
		public double X
		{
			get;
			set;
		}

		public double Y
		{
			get;
			set;
		}

		public double Z
		{
			get;
			set;
		}

		public override bool Equals( object obj )
		{
			ObjectPosition objPos = obj as ObjectPosition;
			if( objPos != null )
			{
				return (
					( objPos.X == X ) &&
					( objPos.Y == Y ) &&
					( objPos.Z == Z ) );
			}
			else
			{
				return base.Equals(obj);
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("({0}, {1}, {2})", X, Y, Z);
		}
	}
}