using Mellow_Music_Player.Source;
using System.Windows.Forms;
using System.Drawing;

namespace Mellow_Music_Player.UI.Forms
{
    partial class MusicPlayerPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlayerPanel));
            this.albumArtPanel = new System.Windows.Forms.Panel();
            this.musicTitleLabel = new System.Windows.Forms.Label();
            this.artistNameLabel = new System.Windows.Forms.Label();
            this.musicProgress = new System.Windows.Forms.ProgressBar();
            this.playPauseButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // albumArtPanel
            // 
            this.albumArtPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.albumArtPanel.BackColor = System.Drawing.Color.Transparent;
            this.albumArtPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.albumArtPanel.Location = new System.Drawing.Point(22, 17);
            this.albumArtPanel.Margin = new System.Windows.Forms.Padding(0);
            this.albumArtPanel.Name = "albumArtPanel";
            this.albumArtPanel.Size = new System.Drawing.Size(53, 50);
            this.albumArtPanel.TabIndex = 0;
            // 
            // musicTitleLabel
            // 
            this.musicTitleLabel.AutoEllipsis = true;
            this.musicTitleLabel.AutoSize = true;
            this.musicTitleLabel.Font = new System.Drawing.Font("Geist", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicTitleLabel.ForeColor = System.Drawing.Color.White;
            this.musicTitleLabel.Location = new System.Drawing.Point(81, 25);
            this.musicTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.musicTitleLabel.Name = "musicTitleLabel";
            this.musicTitleLabel.Size = new System.Drawing.Size(99, 19);
            this.musicTitleLabel.TabIndex = 1;
            this.musicTitleLabel.Text = "Music Name";
            this.musicTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // artistNameLabel
            // 
            this.artistNameLabel.AutoSize = true;
            this.artistNameLabel.Font = new System.Drawing.Font("Geist", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artistNameLabel.ForeColor = System.Drawing.Color.White;
            this.artistNameLabel.Location = new System.Drawing.Point(82, 48);
            this.artistNameLabel.Name = "artistNameLabel";
            this.artistNameLabel.Size = new System.Drawing.Size(86, 15);
            this.artistNameLabel.TabIndex = 2;
            this.artistNameLabel.Text = "ARTIST NAME";
            // 
            // musicProgress
            // 
            this.musicProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(127)))), ((int)(((byte)(13)))));
            this.musicProgress.Location = new System.Drawing.Point(328, 25);
            this.musicProgress.Margin = new System.Windows.Forms.Padding(0);
            this.musicProgress.Name = "musicProgress";
            this.musicProgress.Size = new System.Drawing.Size(398, 3);
            this.musicProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.musicProgress.TabIndex = 3;
            this.musicProgress.Value = 50;
            // 
            // playPauseButton
            // 
            this.playPauseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.playPauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playPauseButton.FlatAppearance.BorderSize = 0;
            this.playPauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playPauseButton.Image = ((System.Drawing.Image)(resources.GetObject("playPauseButton.Image")));
            this.playPauseButton.Location = new System.Drawing.Point(496, 38);
            this.playPauseButton.Name = "playPauseButton";
            this.playPauseButton.Size = new System.Drawing.Size(34, 34);
            this.playPauseButton.TabIndex = 4;
            this.playPauseButton.UseVisualStyleBackColor = false;
            this.playPauseButton.Click += new System.EventHandler(this.playPauseButton_Click);
            this.playPauseButton.Paint += new System.Windows.Forms.PaintEventHandler(this.playPauseButton_Paint);
            this.playPauseButton.MouseEnter += new System.EventHandler(this.playPauseButton_MouseEnter);
            this.playPauseButton.MouseLeave += new System.EventHandler(this.playPauseButton_MouseLeave);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.nextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextButton.FlatAppearance.BorderSize = 0;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Image = ((System.Drawing.Image)(resources.GetObject("nextButton.Image")));
            this.nextButton.Location = new System.Drawing.Point(558, 45);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(20, 20);
            this.nextButton.TabIndex = 5;
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // prevButton
            // 
            this.prevButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.prevButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prevButton.FlatAppearance.BorderSize = 0;
            this.prevButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevButton.Image = ((System.Drawing.Image)(resources.GetObject("prevButton.Image")));
            this.prevButton.Location = new System.Drawing.Point(452, 45);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(20, 20);
            this.prevButton.TabIndex = 6;
            this.prevButton.UseVisualStyleBackColor = false;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // MusicPlayerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1082, 83);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.playPauseButton);
            this.Controls.Add(this.musicProgress);
            this.Controls.Add(this.artistNameLabel);
            this.Controls.Add(this.musicTitleLabel);
            this.Controls.Add(this.albumArtPanel);
            this.Name = "MusicPlayerPanel";
            this.Text = "MusicPlayer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel albumArtPanel;
        private System.Windows.Forms.Label musicTitleLabel;
        private System.Windows.Forms.Label artistNameLabel;
        private System.Windows.Forms.ProgressBar musicProgress;
        private System.Windows.Forms.Button playPauseButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button prevButton;
    }
}