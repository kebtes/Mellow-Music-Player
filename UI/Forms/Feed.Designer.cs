namespace Mellow_Music_Player.UI
{
    partial class panelFeed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(panelFeed));
            this.labelMusic = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonDirectory = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchBoxTextArea = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMusic
            // 
            this.labelMusic.AutoSize = true;
            this.labelMusic.Font = new System.Drawing.Font("Geist", 20F, System.Drawing.FontStyle.Bold);
            this.labelMusic.ForeColor = System.Drawing.Color.White;
            this.labelMusic.Location = new System.Drawing.Point(12, 99);
            this.labelMusic.Name = "labelMusic";
            this.labelMusic.Size = new System.Drawing.Size(138, 43);
            this.labelMusic.TabIndex = 0;
            this.labelMusic.Text = "Musics";
            this.labelMusic.Click += new System.EventHandler(this.labelMusic_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.panel1.Location = new System.Drawing.Point(20, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 2);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Transparent;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(14)))), ((int)(((byte)(21)))));
            this.buttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.Image")));
            this.buttonRefresh.Location = new System.Drawing.Point(781, 116);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(27, 23);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.UseVisualStyleBackColor = false;
            // 
            // buttonDirectory
            // 
            this.buttonDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(14)))), ((int)(((byte)(21)))));
            this.buttonDirectory.Image = ((System.Drawing.Image)(resources.GetObject("buttonDirectory.Image")));
            this.buttonDirectory.Location = new System.Drawing.Point(814, 116);
            this.buttonDirectory.Name = "buttonDirectory";
            this.buttonDirectory.Size = new System.Drawing.Size(27, 23);
            this.buttonDirectory.TabIndex = 3;
            this.buttonDirectory.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.searchBoxTextArea);
            this.panel2.Location = new System.Drawing.Point(20, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(368, 37);
            this.panel2.TabIndex = 4;
            // 
            // searchBoxTextArea
            // 
            this.searchBoxTextArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.searchBoxTextArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBoxTextArea.Font = new System.Drawing.Font("Geist", 8.25F);
            this.searchBoxTextArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.searchBoxTextArea.Location = new System.Drawing.Point(57, 11);
            this.searchBoxTextArea.MaxLength = 500;
            this.searchBoxTextArea.Name = "searchBoxTextArea";
            this.searchBoxTextArea.Size = new System.Drawing.Size(273, 18);
            this.searchBoxTextArea.TabIndex = 0;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Location = new System.Drawing.Point(20, 153);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(723, 529);
            this.flowLayoutPanel.TabIndex = 5;
            // 
            // panelFeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(14)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(876, 694);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonDirectory);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelMusic);
            this.Name = "panelFeed";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.panelFeed_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMusic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonDirectory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox searchBoxTextArea;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}