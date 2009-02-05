/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 02.07.2008
 */

using System;
using System.Windows.Forms;

using YatesMorrison.RolePlay.BattleFramework;

namespace WindowsBattleConsole
{
	public partial class JoinBattle : Form
	{
		public JoinBattle()
		{
			InitializeComponent();
		}

		void bConnect_Click( object sender, EventArgs e )
		{
			Battle battleForm = Owner as Battle;
			if( battleForm != null )
			{
				if( !string.IsNullOrEmpty(cboBattleServerAddress.Text) &&
					!string.IsNullOrEmpty(cboCharacterName.Text) )
				{
					battleForm.ConnectToBattleServer(cboBattleServerAddress.Text, cboCharacterName.Text);
				}
				else
				{
					MessageBox.Show("Fix yer durned addresses!");
				}
			}
		}
	}
}