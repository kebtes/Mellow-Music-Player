namespace Mellow_Music_Player.UI.Forms
{
    partial class Page
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
            this.line = new System.Windows.Forms.Panel();
            this.albumArt = new System.Windows.Forms.Panel();
            this.albumTitleLabel = new System.Windows.Forms.Label();
            this.albumArtistLbl = new System.Windows.Forms.Label();
            this.songCardLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.albumSize = new System.Windows.Forms.Label();
            this.releaseDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.line.Location = new System.Drawing.Point(3, 142);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(869, 2);
            this.line.TabIndex = 4;
            // 
            // albumArt
            // 
            this.albumArt.Location = new System.Drawing.Point(48, 54);
            this.albumArt.Name = "albumArt";
            this.albumArt.Size = new System.Drawing.Size(120, 120);
            this.albumArt.TabIndex = 5;
            // 
            // albumTitleLabel
            // 
            this.albumTitleLabel.AutoSize = true;
            this.albumTitleLabel.Font = new System.Drawing.Font("Geist", 15F, System.Drawing.FontStyle.Bold);
            this.albumTitleLabel.ForeColor = System.Drawing.Color.White;
            this.albumTitleLabel.Location = new System.Drawing.Point(172, 65);
            this.albumTitleLabel.Name = "albumTitleLabel";
            this.albumTitleLabel.Size = new System.Drawing.Size(153, 32);
            this.albumTitleLabel.TabIndex = 6;
            this.albumTitleLabel.Text = "Album Title";
            // 
            // albumArtistLbl
            // 
            this.albumArtistLbl.AutoSize = true;
            this.albumArtistLbl.Font = new System.Drawing.Font("Geist", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.albumArtistLbl.ForeColor = System.Drawing.Color.White;
            this.albumArtistLbl.Location = new System.Drawing.Point(175, 94);
            this.albumArtistLbl.Name = "albumArtistLbl";
            this.albumArtistLbl.Size = new System.Drawing.Size(95, 18);
            this.albumArtistLbl.TabIndex = 7;
            this.albumArtistLbl.Text = "Album Artist";
            // 
            // songCardLayout
            // 
            this.songCardLayout.Location = new System.Drawing.Point(48, 194);
            this.songCardLayout.Name = "songCardLayout";
            this.songCardLayout.Size = new System.Drawing.Size(770, 472);
            this.songCardLayout.TabIndex = 8;
            // 
            // albumSize
            // 
            this.albumSize.AutoSize = true;
            this.albumSize.Font = new System.Drawing.Font("Geist", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.albumSize.ForeColor = System.Drawing.Color.White;
            this.albumSize.Location = new System.Drawing.Point(753, 109);
            this.albumSize.Name = "albumSize";
            this.albumSize.Size = new System.Drawing.Size(65, 16);
            this.albumSize.TabIndex = 9;
            this.albumSize.Text = "20 Songs";
            this.albumSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // releaseDate
            // 
            this.releaseDate.Font = new System.Drawing.Font("Geist", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.releaseDate.ForeColor = System.Drawing.Color.DarkGray;
            this.releaseDate.Location = new System.Drawing.Point(175, 112);
            this.releaseDate.Margin = new System.Windows.Forms.Padding(0);
            this.releaseDate.Name = "releaseDate";
            this.releaseDate.Size = new System.Drawing.Size(164, 15);
            this.releaseDate.TabIndex = 10;
            this.releaseDate.Text = "Released on";
            this.releaseDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.releaseDate.Click += new System.EventHandler(this.label1_Click);
            // 
            // Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(14)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(876, 694);
            this.Controls.Add(this.releaseDate);
            this.Controls.Add(this.albumSize);
            this.Controls.Add(this.songCardLayout);
            this.Controls.Add(this.albumArtistLbl);
            this.Controls.Add(this.albumTitleLabel);
            this.Controls.Add(this.albumArt);
            this.Controls.Add(this.line);
            this.Name = "Page";
            this.Text = "Page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel line;
        private System.Windows.Forms.Panel albumArt;
        private System.Windows.Forms.Label albumTitleLabel;
        private System.Windows.Forms.Label albumArtistLbl;
        private System.Windows.Forms.FlowLayoutPanel songCardLayout;
        private System.Windows.Forms.Label albumSize;
        private System.Windows.Forms.Label releaseDate;
    }
}