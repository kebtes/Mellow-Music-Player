using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mellow_Music_Player.UI
{
    partial class panelFeed : Form
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
            this.searchBoxImage = new System.Windows.Forms.Panel();
            this.searchBoxTextArea = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rightSidePanel = new System.Windows.Forms.Panel();
            this.searchBoxImage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.resultPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMusic
            // 
            this.labelMusic.AutoSize = true;
            this.labelMusic.Font = new System.Drawing.Font("Geist", 18F, System.Drawing.FontStyle.Bold);
            this.labelMusic.ForeColor = System.Drawing.Color.White;
            this.labelMusic.Location = new System.Drawing.Point(12, 99);
            this.labelMusic.Name = "labelMusic";
            this.labelMusic.Size = new System.Drawing.Size(121, 38);
            this.labelMusic.TabIndex = 0;
            this.labelMusic.Text = "Musics";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.panel1.Location = new System.Drawing.Point(4, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 2);
            this.panel1.TabIndex = 1;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Transparent;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(14)))), ((int)(((byte)(21)))));
            this.buttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.Image")));
            this.buttonRefresh.Location = new System.Drawing.Point(554, 118);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(27, 23);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.UseVisualStyleBackColor = false;
            // 
            // buttonDirectory
            // 
            this.buttonDirectory.FlatAppearance.BorderSize = 0;
            this.buttonDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDirectory.ForeColor = System.Drawing.Color.White;
            this.buttonDirectory.Image = ((System.Drawing.Image)(resources.GetObject("buttonDirectory.Image")));
            this.buttonDirectory.Location = new System.Drawing.Point(521, 118);
            this.buttonDirectory.Name = "buttonDirectory";
            this.buttonDirectory.Size = new System.Drawing.Size(27, 23);
            this.buttonDirectory.TabIndex = 3;
            this.buttonDirectory.UseVisualStyleBackColor = true;
            // 
            // searchBoxImage
            // 
            this.searchBoxImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchBoxImage.BackgroundImage")));
            this.searchBoxImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchBoxImage.Controls.Add(this.searchBoxTextArea);
            this.searchBoxImage.Location = new System.Drawing.Point(19, 12);
            this.searchBoxImage.Name = "searchBoxImage";
            this.searchBoxImage.Size = new System.Drawing.Size(368, 37);
            this.searchBoxImage.TabIndex = 4;
            this.searchBoxImage.MouseEnter += new System.EventHandler(this.searchBoxImage_MouseEnter);
            this.searchBoxImage.MouseLeave += new System.EventHandler(this.searchBoxImage_MouseLeave);
            // 
            // searchBoxTextArea
            // 
            this.searchBoxTextArea.AutoCompleteCustomSource.AddRange(new string[] {
            ""});
            this.searchBoxTextArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.searchBoxTextArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.searchBoxTextArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBoxTextArea.Font = new System.Drawing.Font("Geist", 8.25F);
            this.searchBoxTextArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.searchBoxTextArea.Location = new System.Drawing.Point(54, 9);
            this.searchBoxTextArea.MaxLength = 500;
            this.searchBoxTextArea.Name = "searchBoxTextArea";
            this.searchBoxTextArea.Size = new System.Drawing.Size(273, 18);
            this.searchBoxTextArea.TabIndex = 0;
            this.searchBoxTextArea.TextChanged += new System.EventHandler(this.searchBoxTextArea_TextChanged);
            this.searchBoxTextArea.MouseEnter += new System.EventHandler(this.searchBoxTextArea_MouseEnter);
            this.searchBoxTextArea.MouseLeave += new System.EventHandler(this.searchBoxTextArea_MouseLeave);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(593, 567);
            this.flowLayoutPanel.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(587, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 540);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 540);
            this.panel3.TabIndex = 3;
            // 
            // resultPanel
            // 
            this.resultPanel.Controls.Add(this.flowLayoutPanel);
            this.resultPanel.Location = new System.Drawing.Point(4, 146);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(561, 529);
            this.resultPanel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Geist", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(592, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Lyrics";
            // 
            // rightSidePanel
            // 
            this.rightSidePanel.Location = new System.Drawing.Point(595, 146);
            this.rightSidePanel.Name = "rightSidePanel";
            this.rightSidePanel.Size = new System.Drawing.Size(284, 536);
            this.rightSidePanel.TabIndex = 9;
            // 
            // panelFeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(14)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(876, 694);
            this.Controls.Add(this.rightSidePanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.searchBoxImage);
            this.Controls.Add(this.buttonDirectory);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelMusic);
            this.DoubleBuffered = true;
            this.Name = "panelFeed";
            this.Text = "Form1";
            this.searchBoxImage.ResumeLayout(false);
            this.searchBoxImage.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.resultPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMusic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonDirectory;
        private System.Windows.Forms.Panel searchBoxImage;
        private System.Windows.Forms.TextBox searchBoxTextArea;
        private Panel panel2;
        private Panel resultPanel;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel;
        private Panel panel3;
        private Panel rightSidePanel;
    }
}