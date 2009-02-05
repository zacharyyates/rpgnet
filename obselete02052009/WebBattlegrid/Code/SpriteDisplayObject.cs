/* Zachary Yates
 * Copyright 2007 YatesMorrison Software, LLC.
 * 1/27/2008
 */

using YatesMorrison.RolePlay.BattleFramework;

namespace YatesMorrison.RolePlay.BattleFramework.Web
{
	public class SpriteDisplayObject : IDisplayObject
	{
		public string ActorID
		{
			get;
			set;
		}

		public string ImageUrl
		{
			get { return m_ImageUrl; }
			set { m_ImageUrl = value; }
		}
		string m_ImageUrl = string.Empty;

		public int ScreenWidth
		{
			get { return m_ScreenWidth; }
			set { m_ScreenWidth = value; }
		}
		int m_ScreenWidth = 0;

		public int ScreenHeight
		{
			get { return m_ScreenHeight; }
			set { m_ScreenHeight = value; }
		}
		int m_ScreenHeight = 0;
	}
}