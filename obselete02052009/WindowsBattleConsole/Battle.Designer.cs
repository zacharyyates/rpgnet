namespace WindowsBattleConsole
{
	partial class Battle
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mnuMain = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.hostBattleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.joinBattleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hostBattleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.joinBattleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bgcMain = new WindowsBattleConsole.Controls.BattleGridControl();
			this.mnuMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ));
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
			this.mnuMain.Size = new System.Drawing.Size(1005, 27);
			this.mnuMain.TabIndex = 1;
			// 
			// fileToolStripMenuItem1
			// 
			this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hostBattleToolStripMenuItem1,
            this.joinBattleToolStripMenuItem1,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
			this.fileToolStripMenuItem1.Size = new System.Drawing.Size(45, 23);
			this.fileToolStripMenuItem1.Text = "File";
			// 
			// hostBattleToolStripMenuItem1
			// 
			this.hostBattleToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.fromFileToolStripMenuItem});
			this.hostBattleToolStripMenuItem1.Name = "hostBattleToolStripMenuItem1";
			this.hostBattleToolStripMenuItem1.Size = new System.Drawing.Size(155, 24);
			this.hostBattleToolStripMenuItem1.Text = "Host Battle";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// fromFileToolStripMenuItem
			// 
			this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
			this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
			this.fromFileToolStripMenuItem.Text = "From File...";
			// 
			// joinBattleToolStripMenuItem1
			// 
			this.joinBattleToolStripMenuItem1.Name = "joinBattleToolStripMenuItem1";
			this.joinBattleToolStripMenuItem1.Size = new System.Drawing.Size(155, 24);
			this.joinBattleToolStripMenuItem1.Text = "Join Battle!";
			this.joinBattleToolStripMenuItem1.Click += new System.EventHandler(this.joinBattleToolStripMenuItem1_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(45, 23);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// hostBattleToolStripMenuItem
			// 
			this.hostBattleToolStripMenuItem.Name = "hostBattleToolStripMenuItem";
			this.hostBattleToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
			this.hostBattleToolStripMenuItem.Text = "Host Battle";
			// 
			// joinBattleToolStripMenuItem
			// 
			this.joinBattleToolStripMenuItem.Name = "joinBattleToolStripMenuItem";
			this.joinBattleToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
			this.joinBattleToolStripMenuItem.Text = "Join Battle";
			// 
			// bgcMain
			// 
			this.bgcMain.AutoScroll = true;
			this.bgcMain.AutoSize = true;
			this.bgcMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.bgcMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bgcMain.Location = new System.Drawing.Point(0, 27);
			this.bgcMain.Name = "bgcMain";
			this.bgcMain.Size = new System.Drawing.Size(1005, 583);
			this.bgcMain.TabIndex = 2;
			this.bgcMain.TileGutter = 5;
			this.bgcMain.TileSize = 100;
			this.bgcMain.World = null;
			this.bgcMain.TileClick += new System.EventHandler<WindowsBattleConsole.Controls.TileClickEventArgs>(this.bgcMain_TileClick);
			// 
			// Battle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1005, 610);
			this.Controls.Add(this.bgcMain);
			this.Controls.Add(this.mnuMain);
			this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "Battle";
			this.Text = "Battle";
			this.Load += new System.EventHandler(this.Battle_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Battle_FormClosing);
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mnuMain;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hostBattleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem joinBattleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem hostBattleToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem joinBattleToolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private WindowsBattleConsole.Controls.BattleGridControl bgcMain;
	}
}