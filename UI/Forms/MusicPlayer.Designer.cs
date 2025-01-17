using System.Windows.Forms;

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
            this.playPauseButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.progressBar = new ReaLTaiizor.Controls.RibbonProgressBarCenter();
            this.volumeTrackBar = new ReaLTaiizor.Controls.DungeonTrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.currentTime = new System.Windows.Forms.Label();
            this.totalTime = new System.Windows.Forms.Label();
            this.heartButton = new System.Windows.Forms.Button();
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
            // playPauseButton
            // 
            this.playPauseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.playPauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playPauseButton.FlatAppearance.BorderSize = 0;
            this.playPauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playPauseButton.Image = ((System.Drawing.Image)(resources.GetObject("playPauseButton.Image")));
            this.playPauseButton.Location = new System.Drawing.Point(520, 34);
            this.playPauseButton.Name = "playPauseButton";
            this.playPauseButton.Size = new System.Drawing.Size(34, 34);
            this.playPauseButton.TabIndex = 4;
            this.playPauseButton.UseVisualStyleBackColor = false;
            this.playPauseButton.Click += new System.EventHandler(this.playPauseButton_Click);
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
            this.nextButton.Location = new System.Drawing.Point(577, 41);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(20, 20);
            this.nextButton.TabIndex = 5;
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            this.nextButton.MouseEnter += new System.EventHandler(this.nextButton_MouseEnter);
            this.nextButton.MouseLeave += new System.EventHandler(this.nextButton_MouseLeave);
            // 
            // prevButton
            // 
            this.prevButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.prevButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prevButton.FlatAppearance.BorderSize = 0;
            this.prevButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevButton.Image = ((System.Drawing.Image)(resources.GetObject("prevButton.Image")));
            this.prevButton.Location = new System.Drawing.Point(477, 41);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(20, 20);
            this.prevButton.TabIndex = 6;
            this.prevButton.UseVisualStyleBackColor = false;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            this.prevButton.MouseEnter += new System.EventHandler(this.prevButton_MouseEnter);
            this.prevButton.MouseLeave += new System.EventHandler(this.prevButton_MouseLeave);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.Transparent;
            this.progressBar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.progressBar.BorderColor = System.Drawing.Color.Transparent;
            this.progressBar.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(201)))), ((int)(((byte)(205)))));
            this.progressBar.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(186)))), ((int)(((byte)(190)))));
            this.progressBar.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(97)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.progressBar.ForeColor = System.Drawing.Color.Black;
            this.progressBar.HatchType = System.Drawing.Drawing2D.HatchStyle.Shingle;
            this.progressBar.Location = new System.Drawing.Point(367, 23);
            this.progressBar.Maximum = 100;
            this.progressBar.Name = "progressBar";
            this.progressBar.PercentageText = "%";
            this.progressBar.ProgressBorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(97)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.progressBar.ProgressBorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(95)))), ((int)(((byte)(27)))));
            this.progressBar.ProgressColorA = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(95)))), ((int)(((byte)(27)))));
            this.progressBar.ProgressColorB = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(95)))), ((int)(((byte)(27)))));
            this.progressBar.ProgressLineColorA = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.progressBar.ProgressLineColorB = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.progressBar.ShowEdge = false;
            this.progressBar.ShowPercentage = false;
            this.progressBar.Size = new System.Drawing.Size(340, 5);
            this.progressBar.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.progressBar.TabIndex = 9;
            this.progressBar.Text = "ribbonProgressBarCenter1";
            this.progressBar.Value = 0;
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.BorderColor = System.Drawing.Color.Transparent;
            this.volumeTrackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.volumeTrackBar.DrawValueString = false;
            this.volumeTrackBar.EmptyBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.volumeTrackBar.FillBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(95)))), ((int)(((byte)(27)))));
            this.volumeTrackBar.JumpToMouse = false;
            this.volumeTrackBar.Location = new System.Drawing.Point(929, 26);
            this.volumeTrackBar.Maximum = 100;
            this.volumeTrackBar.Minimum = 0;
            this.volumeTrackBar.MinimumSize = new System.Drawing.Size(47, 20);
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(109, 22);
            this.volumeTrackBar.TabIndex = 11;
            this.volumeTrackBar.Text = "dungeonTrackBar1";
            this.volumeTrackBar.ThumbBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(95)))), ((int)(((byte)(27)))));
            this.volumeTrackBar.ThumbBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(95)))), ((int)(((byte)(27)))));
            this.volumeTrackBar.Value = 60;
            this.volumeTrackBar.ValueDivison = ReaLTaiizor.Controls.DungeonTrackBar.ValueDivisor.By1;
            this.volumeTrackBar.ValueToSet = 60F;
            this.volumeTrackBar.ValueChanged += new ReaLTaiizor.Controls.DungeonTrackBar.ValueChangedEventHandler(this.volumeTrackBar_ValueChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(892, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // currentTime
            // 
            this.currentTime.AutoSize = true;
            this.currentTime.Font = new System.Drawing.Font("Geist", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.currentTime.Location = new System.Drawing.Point(323, 20);
            this.currentTime.Name = "currentTime";
            this.currentTime.Size = new System.Drawing.Size(38, 13);
            this.currentTime.TabIndex = 13;
            this.currentTime.Text = "00:00";
            this.currentTime.Click += new System.EventHandler(this.currentTime_Click);
            // 
            // totalTime
            // 
            this.totalTime.AutoSize = true;
            this.totalTime.Font = new System.Drawing.Font("Geist", 6F);
            this.totalTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.totalTime.Location = new System.Drawing.Point(713, 20);
            this.totalTime.Name = "totalTime";
            this.totalTime.Size = new System.Drawing.Size(34, 13);
            this.totalTime.TabIndex = 14;
            this.totalTime.Text = "99:99";
            // 
            // heartButton
            // 
            this.heartButton.BackColor = System.Drawing.Color.Transparent;
            this.heartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.heartButton.FlatAppearance.BorderSize = 0;
            this.heartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.heartButton.Location = new System.Drawing.Point(246, 34);
            this.heartButton.Name = "heartButton";
            this.heartButton.Size = new System.Drawing.Size(23, 23);
            this.heartButton.TabIndex = 15;
            this.heartButton.UseVisualStyleBackColor = false;
            this.heartButton.Click += new System.EventHandler(this.heartButton_Click);
            // 
            // MusicPlayerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1082, 83);
            this.Controls.Add(this.heartButton);
            this.Controls.Add(this.totalTime);
            this.Controls.Add(this.currentTime);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.volumeTrackBar);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.playPauseButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.artistNameLabel);
            this.Controls.Add(this.musicTitleLabel);
            this.Controls.Add(this.albumArtPanel);
            this.DoubleBuffered = true;
            this.Name = "MusicPlayerPanel";
            this.Text = "MusicPlayer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel albumArtPanel;
        private System.Windows.Forms.Label musicTitleLabel;
        private System.Windows.Forms.Label artistNameLabel;
        private System.Windows.Forms.Button playPauseButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button prevButton;
        private ReaLTaiizor.Controls.DungeonTrackBar volumeTrackBar;
        private Button button1;
        private Label currentTime;
        private Label totalTime;
        private ReaLTaiizor.Controls.RibbonProgressBarCenter progressBar;
        private Button heartButton;
    }
}