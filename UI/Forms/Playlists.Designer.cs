using System.Windows.Forms;

namespace Mellow_Music_Player.UI.Forms
{
    partial class Playlists
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
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
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Playlists));
            this.separator = new System.Windows.Forms.Panel();
            this.playlistName = new System.Windows.Forms.Label();
            this.verticalSeparator = new System.Windows.Forms.Panel();
            this.songLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.playlistLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.deletePlaylistLbl = new System.Windows.Forms.Label();
            this.playlistCreatedDate = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.songLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Geist", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(574, 492);
            label1.TabIndex = 0;
            label1.Text = "Choose a Playlist to show!!";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // separator
            // 
            this.separator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.separator.Location = new System.Drawing.Point(4, 142);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(950, 2);
            this.separator.TabIndex = 2;
            // 
            // playlistName
            // 
            this.playlistName.AutoSize = true;
            this.playlistName.Font = new System.Drawing.Font("Geist", 18F, System.Drawing.FontStyle.Bold);
            this.playlistName.ForeColor = System.Drawing.Color.White;
            this.playlistName.Location = new System.Drawing.Point(4, 80);
            this.playlistName.Name = "playlistName";
            this.playlistName.Size = new System.Drawing.Size(218, 38);
            this.playlistName.TabIndex = 1;
            this.playlistName.Text = "Your Playlists";
            // 
            // verticalSeparator
            // 
            this.verticalSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.verticalSeparator.Location = new System.Drawing.Point(587, 142);
            this.verticalSeparator.Name = "verticalSeparator";
            this.verticalSeparator.Size = new System.Drawing.Size(2, 540);
            this.verticalSeparator.TabIndex = 3;
            // 
            // songLayoutPanel
            // 
            this.songLayoutPanel.Controls.Add(label1);
            this.songLayoutPanel.Location = new System.Drawing.Point(4, 150);
            this.songLayoutPanel.Name = "songLayoutPanel";
            this.songLayoutPanel.Size = new System.Drawing.Size(577, 492);
            this.songLayoutPanel.TabIndex = 4;
            // 
            // playlistLayoutPanel
            // 
            this.playlistLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.playlistLayoutPanel.Location = new System.Drawing.Point(595, 150);
            this.playlistLayoutPanel.Name = "playlistLayoutPanel";
            this.playlistLayoutPanel.Size = new System.Drawing.Size(269, 440);
            this.playlistLayoutPanel.TabIndex = 5;
            this.playlistLayoutPanel.WrapContents = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(711, 636);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 25);
            this.panel1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Geist", 8.25F);
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.Location = new System.Drawing.Point(15, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 18);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Geist SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(613, 643);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "New Playlist";
            // 
            // deletePlaylistLbl
            // 
            this.deletePlaylistLbl.AutoSize = true;
            this.deletePlaylistLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deletePlaylistLbl.Font = new System.Drawing.Font("Geist SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletePlaylistLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.deletePlaylistLbl.Location = new System.Drawing.Point(240, 645);
            this.deletePlaylistLbl.Name = "deletePlaylistLbl";
            this.deletePlaylistLbl.Size = new System.Drawing.Size(106, 18);
            this.deletePlaylistLbl.TabIndex = 8;
            this.deletePlaylistLbl.Text = "Delete Playlist";
            this.deletePlaylistLbl.Visible = false;
            this.deletePlaylistLbl.Click += new System.EventHandler(this.deletePlaylistLbl_Click);
            this.deletePlaylistLbl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.deletePlaylistLbl_MouseClick);
            this.deletePlaylistLbl.MouseEnter += new System.EventHandler(this.deletePlaylistLbl_MouseEnter);
            this.deletePlaylistLbl.MouseLeave += new System.EventHandler(this.deletePlaylistLbl_MouseLeave);
            // 
            // playlistCreatedDate
            // 
            this.playlistCreatedDate.Font = new System.Drawing.Font("Geist", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playlistCreatedDate.ForeColor = System.Drawing.Color.Silver;
            this.playlistCreatedDate.Location = new System.Drawing.Point(8, 116);
            this.playlistCreatedDate.Name = "playlistCreatedDate";
            this.playlistCreatedDate.Size = new System.Drawing.Size(255, 23);
            this.playlistCreatedDate.TabIndex = 9;
            this.playlistCreatedDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Playlists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(14)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(876, 694);
            this.Controls.Add(this.playlistCreatedDate);
            this.Controls.Add(this.deletePlaylistLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playlistLayoutPanel);
            this.Controls.Add(this.songLayoutPanel);
            this.Controls.Add(this.verticalSeparator);
            this.Controls.Add(this.playlistName);
            this.Controls.Add(this.separator);
            this.DoubleBuffered = true;
            this.Name = "Playlists";
            this.ShowIcon = false;
            this.Text = "Playlists";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.songLayoutPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel separator;
        private System.Windows.Forms.Label playlistName;
        private System.Windows.Forms.Panel verticalSeparator;
        private System.Windows.Forms.FlowLayoutPanel songLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel playlistLayoutPanel;
        private Label label2;
        private Panel panel1;
        private TextBox textBox1;
        private Label label3;
        private Label deletePlaylistLbl;
        private Label playlistCreatedDate;
    }
}