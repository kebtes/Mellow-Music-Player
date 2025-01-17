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
            this.separator = new System.Windows.Forms.Panel();
            this.playlistName = new System.Windows.Forms.Label();
            this.verticalSeparator = new System.Windows.Forms.Panel();
            this.songLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.playlistLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.songLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Geist", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(574, 532);
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
            this.playlistName.Location = new System.Drawing.Point(12, 101);
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
            this.songLayoutPanel.Size = new System.Drawing.Size(577, 532);
            this.songLayoutPanel.TabIndex = 4;
            // 
            // playlistLayoutPanel
            // 
            this.playlistLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.playlistLayoutPanel.Location = new System.Drawing.Point(595, 150);
            this.playlistLayoutPanel.Name = "playlistLayoutPanel";
            this.playlistLayoutPanel.Size = new System.Drawing.Size(269, 459);
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
            // Playlists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(14)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(876, 694);
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
    }
}