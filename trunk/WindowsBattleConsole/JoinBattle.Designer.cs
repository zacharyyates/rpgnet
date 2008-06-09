namespace WindowsBattleConsole
{
	partial class JoinBattle
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
			this.lBattleServerAddress = new System.Windows.Forms.Label();
			this.cboBattleServerAddress = new System.Windows.Forms.ComboBox();
			this.bConnect = new System.Windows.Forms.Button();
			this.pbConnect = new System.Windows.Forms.ProgressBar();
			this.cboCharacterName = new System.Windows.Forms.ComboBox();
			this.lCharacterName = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lBattleServerAddress
			// 
			this.lBattleServerAddress.AutoSize = true;
			this.lBattleServerAddress.Location = new System.Drawing.Point(12, 9);
			this.lBattleServerAddress.Name = "lBattleServerAddress";
			this.lBattleServerAddress.Size = new System.Drawing.Size(160, 19);
			this.lBattleServerAddress.TabIndex = 0;
			this.lBattleServerAddress.Text = "Battle Server Address";
			// 
			// cboBattleServerAddress
			// 
			this.cboBattleServerAddress.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cboBattleServerAddress.FormattingEnabled = true;
			this.cboBattleServerAddress.Location = new System.Drawing.Point(12, 31);
			this.cboBattleServerAddress.Name = "cboBattleServerAddress";
			this.cboBattleServerAddress.Size = new System.Drawing.Size(402, 27);
			this.cboBattleServerAddress.TabIndex = 1;
			this.cboBattleServerAddress.Text = "http://localhost/BattleServer/RemotePlayerManager";
			// 
			// bConnect
			// 
			this.bConnect.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.bConnect.AutoSize = true;
			this.bConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.bConnect.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ));
			this.bConnect.Location = new System.Drawing.Point(324, 116);
			this.bConnect.Name = "bConnect";
			this.bConnect.Size = new System.Drawing.Size(90, 29);
			this.bConnect.TabIndex = 5;
			this.bConnect.Text = "Connect!";
			this.bConnect.UseVisualStyleBackColor = true;
			this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
			// 
			// pbConnect
			// 
			this.pbConnect.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.pbConnect.Location = new System.Drawing.Point(12, 116);
			this.pbConnect.Name = "pbConnect";
			this.pbConnect.Size = new System.Drawing.Size(306, 29);
			this.pbConnect.TabIndex = 4;
			// 
			// cboCharacterName
			// 
			this.cboCharacterName.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cboCharacterName.FormattingEnabled = true;
			this.cboCharacterName.Location = new System.Drawing.Point(12, 83);
			this.cboCharacterName.Name = "cboCharacterName";
			this.cboCharacterName.Size = new System.Drawing.Size(402, 27);
			this.cboCharacterName.TabIndex = 3;
			this.cboCharacterName.Text = "HIMO LIADON";
			// 
			// lCharacterName
			// 
			this.lCharacterName.AutoSize = true;
			this.lCharacterName.Location = new System.Drawing.Point(12, 61);
			this.lCharacterName.Name = "lCharacterName";
			this.lCharacterName.Size = new System.Drawing.Size(122, 19);
			this.lCharacterName.TabIndex = 2;
			this.lCharacterName.Text = "Character Name";
			// 
			// JoinBattle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 154);
			this.Controls.Add(this.lCharacterName);
			this.Controls.Add(this.cboCharacterName);
			this.Controls.Add(this.pbConnect);
			this.Controls.Add(this.bConnect);
			this.Controls.Add(this.cboBattleServerAddress);
			this.Controls.Add(this.lBattleServerAddress);
			this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "JoinBattle";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Join Battle!";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lBattleServerAddress;
		private System.Windows.Forms.ComboBox cboBattleServerAddress;
		private System.Windows.Forms.Button bConnect;
		private System.Windows.Forms.ProgressBar pbConnect;
		private System.Windows.Forms.ComboBox cboCharacterName;
		private System.Windows.Forms.Label lCharacterName;
	}
}