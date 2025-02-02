using System.Windows.Forms;

namespace Mellow_Music_Player.UI
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelLeftSide = new System.Windows.Forms.Panel();
            this.MellowIcon = new System.Windows.Forms.Button();
            this.panelPage = new System.Windows.Forms.Panel();
            this.buttonPlaylist = new System.Windows.Forms.Button();
            this.buttonFeed = new System.Windows.Forms.Button();
            this.pannelFooter = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeftSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeftSide
            // 
            this.panelLeftSide.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelLeftSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(14)))), ((int)(((byte)(21)))));
            this.panelLeftSide.Controls.Add(this.MellowIcon);
            this.panelLeftSide.Controls.Add(this.panelPage);
            this.panelLeftSide.Controls.Add(this.buttonPlaylist);
            this.panelLeftSide.Controls.Add(this.buttonFeed);
            this.panelLeftSide.Location = new System.Drawing.Point(-1, 0);
            this.panelLeftSide.Name = "panelLeftSide";
            this.panelLeftSide.Size = new System.Drawing.Size(152, 717);
            this.panelLeftSide.TabIndex = 0;
            // 
            // MellowIcon
            // 
            this.MellowIcon.BackColor = System.Drawing.Color.Transparent;
            this.MellowIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MellowIcon.FlatAppearance.BorderSize = 0;
            this.MellowIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MellowIcon.Image = ((System.Drawing.Image)(resources.GetObject("MellowIcon.Image")));
            this.MellowIcon.Location = new System.Drawing.Point(39, 25);
            this.MellowIcon.Name = "MellowIcon";
            this.MellowIcon.Size = new System.Drawing.Size(73, 53);
            this.MellowIcon.TabIndex = 3;
            this.MellowIcon.UseVisualStyleBackColor = false;
            // 
            // panelPage
            // 
            this.panelPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelPage.Location = new System.Drawing.Point(154, 3);
            this.panelPage.Name = "panelPage";
            this.panelPage.Size = new System.Drawing.Size(928, 714);
            this.panelPage.TabIndex = 2;
            // 
            // buttonPlaylist
            // 
            this.buttonPlaylist.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPlaylist.BackColor = System.Drawing.Color.Transparent;
            this.buttonPlaylist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPlaylist.FlatAppearance.BorderSize = 0;
            this.buttonPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlaylist.Font = new System.Drawing.Font("Geist", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlaylist.ForeColor = System.Drawing.Color.White;
            this.buttonPlaylist.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlaylist.Image")));
            this.buttonPlaylist.Location = new System.Drawing.Point(1, 133);
            this.buttonPlaylist.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPlaylist.Name = "buttonPlaylist";
            this.buttonPlaylist.Size = new System.Drawing.Size(151, 30);
            this.buttonPlaylist.TabIndex = 1;
            this.buttonPlaylist.Text = "Playlist";
            this.buttonPlaylist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPlaylist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPlaylist.UseVisualStyleBackColor = false;
            this.buttonPlaylist.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonPlaylist_Paint);
            this.buttonPlaylist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonPlaylist_MouseClick);
            this.buttonPlaylist.MouseEnter += new System.EventHandler(this.buttonPlaylist_MouseEnter);
            this.buttonPlaylist.MouseLeave += new System.EventHandler(this.buttonPlaylist_MouseLeave);
            // 
            // buttonFeed
            // 
            this.buttonFeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonFeed.BackColor = System.Drawing.Color.Transparent;
            this.buttonFeed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFeed.FlatAppearance.BorderSize = 0;
            this.buttonFeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFeed.Font = new System.Drawing.Font("Geist", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFeed.ForeColor = System.Drawing.Color.White;
            this.buttonFeed.Image = ((System.Drawing.Image)(resources.GetObject("buttonFeed.Image")));
            this.buttonFeed.Location = new System.Drawing.Point(0, 103);
            this.buttonFeed.Margin = new System.Windows.Forms.Padding(0);
            this.buttonFeed.Name = "buttonFeed";
            this.buttonFeed.Size = new System.Drawing.Size(151, 30);
            this.buttonFeed.TabIndex = 0;
            this.buttonFeed.Text = "Feed";
            this.buttonFeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFeed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFeed.UseVisualStyleBackColor = false;
            this.buttonFeed.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonFeed_Paint);
            this.buttonFeed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonFeed_MouseClick);
            this.buttonFeed.MouseEnter += new System.EventHandler(this.buttonFeed_MouseEnter);
            this.buttonFeed.MouseLeave += new System.EventHandler(this.buttonFeed_MouseLeave);
            // 
            // pannelFooter
            // 
            this.pannelFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pannelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.pannelFooter.Location = new System.Drawing.Point(0, 692);
            this.pannelFooter.Name = "pannelFooter";
            this.pannelFooter.Size = new System.Drawing.Size(1087, 86);
            this.pannelFooter.TabIndex = 1;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelRight.Location = new System.Drawing.Point(150, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(934, 693);
            this.panelRight.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1082, 777);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.pannelFooter);
            this.Controls.Add(this.panelLeftSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Mellow Music Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.panelLeftSide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void LoadPage(Form page)
        {
            panelRight.Controls.Clear();

            page.TopLevel = false;
            page.FormBorderStyle = FormBorderStyle.None;
            page.Dock = DockStyle.Fill;
            panelRight.Controls.Add(page);
            page.Show();
        }

        private void LoadPlayerPage(Form page)
        {
            pannelFooter.Controls.Clear();

            page.TopLevel = false;
            page.FormBorderStyle = FormBorderStyle.None;    
            page.Dock = DockStyle.Fill;
            pannelFooter.Controls.Add(page);
            page.Show();
        }

        #endregion

        private System.Windows.Forms.Panel panelLeftSide;
        private System.Windows.Forms.Panel pannelFooter;
        private System.Windows.Forms.Button buttonFeed;
        private System.Windows.Forms.Button buttonPlaylist;
        private Panel panelPage;
        private Panel panelRight;
        private Button MellowIcon;
    }
}

