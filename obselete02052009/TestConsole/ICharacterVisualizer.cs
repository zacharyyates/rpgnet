/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/12/2007
 */

using System;
using System.IO;
using System.Text;

namespace YatesMorrison.RolePlay.Test
{
	public interface ICharacterVisualizer
	{
		void Visualize( Character character, Stream outputStream );
		void Visualize( Character character, StringBuilder output );
	}
}