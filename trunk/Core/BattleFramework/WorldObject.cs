/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/26/2008
 */

using System;
namespace YatesMorrison.RolePlay.BattleFramework
{
	public interface IWorldObject
	{
		ObjectPosition Position { get; set; }
		event EventHandler<ValueChangedEventArgs<ObjectPosition>> PositionChanged;

		ObjectSize Size { get; set; }
		event EventHandler<ValueChangedEventArgs<ObjectSize>> SizeChanged;
		
		IDisplayObject DisplayObject { get; set; }
	}

	public interface IWorldActor : IWorldObject
	{
		string ActorId { get; set; }
	}

	public class WorldActor : IWorldActor
	{
		public ObjectPosition Position
		{
			get;
			set;
		}
		#region PositionChanged Event
		public event EventHandler<ValueChangedEventArgs<ObjectPosition>> PositionChanged
		{
			add { m_PositionChanged += value; }
			remove { m_PositionChanged -= value; }
		}
		protected void OnPositionChanged( ValueChangedEventArgs<ObjectPosition> e )
		{
			if( m_PositionChanged != null )
			{
				m_PositionChanged(this, e);
			}
		}
		EventHandler<ValueChangedEventArgs<ObjectPosition>> m_PositionChanged;
		#endregion

		public ObjectSize Size
		{
			get;
			set;
		}
		#region SizeChanged Event
		public event EventHandler<ValueChangedEventArgs<ObjectSize>> SizeChanged
		{
			add { m_SizeChanged += value; }
			remove { m_SizeChanged -= value; }
		}
		protected void OnSizeChanged( ValueChangedEventArgs<ObjectSize> e )
		{
			if( m_SizeChanged != null )
			{
				m_SizeChanged(this, e);
			}
		}
		EventHandler<ValueChangedEventArgs<ObjectSize>> m_SizeChanged;
		#endregion

		public IDisplayObject DisplayObject
		{
			get;
			set;
		}

		public string ActorId
		{
			get;
			set;
		}
	}
}