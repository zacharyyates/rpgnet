/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/26/2008
 */

using System;
namespace YatesMorrison.RolePlay.BattleFramework
{
	public class Tile : IWorldObject
	{
		public ObjectPosition Position
		{
			get { return m_Position; }
			set { m_Position = value; }
		}
		ObjectPosition m_Position;
		
		public event EventHandler<ValueChangedEventArgs<ObjectPosition>> PositionChanged;

		public ObjectSize Size
		{
			get;
			set;
		}

		public event EventHandler<ValueChangedEventArgs<ObjectSize>> SizeChanged;

		public IDisplayObject DisplayObject
		{
			get { return m_DisplayObject; }
			set { m_DisplayObject = value; }
		}
		IDisplayObject m_DisplayObject;
	}
}