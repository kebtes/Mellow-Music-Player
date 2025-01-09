using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Mellow_Music_Player.Source;
using Mellow_Music_Player.Source.Services;
using Mellow_Music_Player.Source.Services.Database_Services;
using Mellow_Music_Player.UI.Forms;

namespace Mellow_Music_Player.UI
{
    public partial class panelFeed : Form
    {
        //private FileService fileService;
        private AudioService audioService;

        public panelFeed(AudioService audioService)
        {
            //fileService = new FileService();
            this.audioService = audioService;
            InitializeComponent();
            LoadSongs();
        }

        private void LoadSongs()
        {
            const int cardWidth = 723;
            const int cardHeight = 61;

            //Panel selectedCard = null;

            DatabaseService.GetSongs().ForEach(s =>
            {
                bool isHovered = false;
                bool isSelected = false;

                //Panel to hold the song
                Panel panelSongCard = new Panel
                {
                    Size = new Size(cardWidth, cardHeight),
                    BackColor = ColorTranslator.FromHtml(Constants.DarkBlue),
                    BorderStyle = BorderStyle.None,
                    ForeColor = Color.White

                };

                Label lblSongTitle = new Label
                {
                    Text = s.Title,
                    Size = new Size(193, 13),
                    Font = new Font(Constants.ProjectFont, 7, FontStyle.Bold),
                    Location = new Point(74, 20)
                };

                Label lblArtist = new Label()
                {
                    Text = string.Join(", ", s.Artists),
                    Size = new Size(190, 10),
                    Font = new Font(Constants.ProjectFont, 5, FontStyle.Regular),
                    Location = new Point(74, 36)
                };

                Panel panelAlbumArt = new Panel
                {
                    Size = new Size(45, 45),
                    Location = new Point(20, 8),
                    BackgroundImage = ScaleImage.Scale(s.AlbumArt),

                };

                Button playButton = new Button
                {
                    Size = new Size(30, 30),
                    BackgroundImage = ScaleImage.Scale(Image.FromFile(Constants.PlayButtonSmallIcon), 30, 30),
                    Location = new Point(500, 15),
                };

                playButton.MouseClick += (sender, e) =>
                {
                    audioService.PlaySong(s);
                };

                playButton.MouseEnter += (sender, e) =>
                {
                    playButton.BackgroundImage = ScaleImage.Scale(Image.FromFile(Constants.PlayButtonSmallSelectedIcon), 30, 30);
                };

                playButton.MouseLeave += (sender, e) =>
                {
                    playButton.BackgroundImage = ScaleImage.Scale(Image.FromFile(Constants.PlayButtonSmallIcon), 30, 30);
                };


                playButton.FlatStyle = FlatStyle.Flat;
                playButton.FlatAppearance.BorderSize = 0;

                panelSongCard.MouseEnter += (sender, e) =>
                {
                    if (isSelected) return;

                    isHovered = true;
                    panelSongCard.Invalidate();

                };

                panelSongCard.MouseLeave += (sender, e) =>
                {
                    if (isSelected) return;

                    isHovered = false;
                    panelSongCard.Invalidate();
                };

                panelSongCard.MouseClick += (sender, e) =>
                {
                    isSelected = !isSelected;
                    panelSongCard.Invalidate();
                };

                panelSongCard.Paint += (sender, e) =>
                {
                    if (isSelected)
                    {
                        panelSongCard.BackColor = ColorTranslator.FromHtml(Constants.HoverBlue);

                        using (Pen pen = new Pen(ColorTranslator.FromHtml(Constants.OrangeColor), Constants.HoverPenWidth))
                        {
                            e.Graphics.DrawLine(pen, 0, 0, 0, panelSongCard.Height);
                        }
                    }
                    else if (isHovered)
                    {
                        //panelSongCard.BackColor = ColorTranslator.FromHtml(Constants.HoverBlue);
                        using (Pen pen = new Pen(ColorTranslator.FromHtml(Constants.HoverGrey), Constants.HoverPenWidth))
                        {
                            e.Graphics.DrawLine(pen, 0, 0, 0, panelSongCard.Height);
                        }
                    }
                    else
                    {
                        panelSongCard.BackColor = ColorTranslator.FromHtml(Constants.DarkBlue);
                    }
                };

                panelSongCard.Controls.Add(lblSongTitle);
                panelSongCard.Controls.Add(lblArtist);
                panelSongCard.Controls.Add(panelAlbumArt);
                panelSongCard.Controls.Add(playButton);

                flowLayoutPanel.Controls.Add(panelSongCard);
            });
        }

        private void labelMusic_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelFeed_Load(object sender, EventArgs e)
        {

        }

        private void searchBoxImage_MouseEnter(object sender, EventArgs e)
        {
            searchBoxImage.BackgroundImage = ScaleImage.Scale(Image.FromFile(Constants.SearchBarSelected), 368, 38);
        }

        private void searchBoxImage_MouseLeave(object sender, EventArgs e)
        {
            searchBoxImage.BackgroundImage = ScaleImage.Scale(Image.FromFile(Constants.SearchBar), 368, 38);
        }

        private void searchBoxTextArea_MouseEnter(object sender, EventArgs e)
        {
            searchBoxImage.BackgroundImage = ScaleImage.Scale(Image.FromFile(Constants.SearchBarSelected), 368, 38);
        }

        private void searchBoxTextArea_MouseLeave(object sender, EventArgs e)
        {
            searchBoxImage.BackgroundImage = ScaleImage.Scale(Image.FromFile(Constants.SearchBar), 368, 38);
        }
    }
}
