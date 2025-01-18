using Mellow_Music_Player.Source;
using Mellow_Music_Player.Source.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mellow_Music_Player.UI;
using Mellow_Music_Player.Source.Services.Database_Services;
using Mellow_Music_Player.Source.Services.DatabaseServices;
using Mellow_Music_Player.Source.Services;

namespace Mellow_Music_Player.UI.Forms
{
    public partial class Page : Form
    {
        private Album album;
        private MusicPlayerPanel musicPlayerPanel;
        private AudioService audioService;
        private panelFeed feed;

        public Page(Album album, MusicPlayerPanel musicPlayerPanel, AudioService audioService, panelFeed feed)
        {
            this.DoubleBuffered = true;

            this.album = album;
            this.musicPlayerPanel = musicPlayerPanel;
            this.audioService = audioService;
            this.feed = feed;

            InitializeComponent();
            LoadAlbum();
            
        }

        private void LoadAlbum()
        {
            this.albumArt.BackgroundImage = ScaleImage.Scale(album.AlbumArt, 120, 120);
            this.albumTitleLabel.Text = album.AlbumName;
            this.albumArtistLbl.Text = album.Artists;
            this.albumSize.Text = $"{album.Songs.Count} Songs";
            this.releaseDate.Text = $"Released on {FileService.GetReleaseDate(album.Songs[0].FilePath)}";

            this.album.Songs.ForEach(s =>
            {
                CreateSongCard(s, this.songCardLayout);
            });
        }

        private Panel currentlySelectedPanel = null;
        public void CreateSongCard(Song s, Panel parentComponent)
        {
            const int cardWidth = 723;
            const int cardHeight = 61;

            bool isHovered = false;

            // Panel to hold the song
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
                ForeColor = Color.White,
                Location = new Point(74, 20)
            };

            Label lblArtist = new Label()
            {
                Text = string.Join(", ", s.Artists),
                Size = new Size(190, 10),
                Font = new Font(Constants.ProjectFont, 5, FontStyle.Regular),
                ForeColor = Color.White,
                Location = new Point(74, 36)
            };

            Label lblAlbum = new Label()
            {
                Text = s.Album,
                Size = new Size(193, 20),
                Font = new Font(Constants.ProjectFont, 7, FontStyle.Regular),
                ForeColor = Color.White,
                Location = new Point((int)parentComponent.Width / 2, 22),
                Cursor = Cursors.Hand
            };

            Panel panelAlbumArt = new Panel
            {
                Size = new Size(45, 45),
                Location = new Point(20, 8),
                BackgroundImage = ScaleImage.Scale(s.AlbumArt)
            };

            Button playButton = new Button
            {
                Size = new Size(30, 30),
                BackgroundImage = ScaleImage.Scale(Image.FromFile(Constants.PlayButtonSmallIcon), 30, 30),
                Location = new Point(songCardLayout.Width - 110, 15),
            };
            Button addToPlaylistBtn = new Button
            {
                Size = new Size(25, 25),
                BackgroundImage = ScaleImage.Scale(Image.FromFile(Constants.AddIcon), 25, 25),
                Location = new Point(songCardLayout.Width - 80, 18),
            };

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            List<Playlist> playlists = DatabaseService.GetPlaylists();
            playlists.ForEach(p =>
            {
                ToolStripMenuItem playlistName = new ToolStripMenuItem(p.PlaylistName);
                playlistName.TextAlign = ContentAlignment.MiddleLeft;
                playlistName.Font = new Font(Constants.ProjectFont, 7, FontStyle.Regular);
                playlistName.BackColor = ColorTranslator.FromHtml(Constants.HoverGrey);
                playlistName.ForeColor = Color.White;

                playlistName.MouseEnter += (sender, e) =>
                {
                    playlistName.BackColor = ColorTranslator.FromHtml(Constants.HoverGrey);
                    playlistName.Font = new Font(Constants.ProjectFont, 7, FontStyle.Regular | FontStyle.Underline);
                    //playlistName.ForeColor = ColorTranslator.FromHtml(Constants.OrangeColor);

                };

                playlistName.MouseLeave += (sender, e) =>
                {
                    playlistName.BackColor = ColorTranslator.FromHtml(Constants.HoverGrey);
                    playlistName.Font = new Font(Constants.ProjectFont, 7, FontStyle.Regular);
                    //playlistName.ForeColor = Color.White;
                };

                contextMenuStrip.Items.Add(playlistName);
            });
            //contextMenuStrip.BackColor = ColorTranslator.FromHtml(Constants.HoverGrey);
            //contextMenuStrip.BackgroundImage = null;

            contextMenuStrip.ItemClicked += (sender, e) =>
            {
                ToolStripItem clickedItem = e.ClickedItem;
                DatabaseService.AddToPlaylist(clickedItem.Text, s);
            };


            playButton.MouseClick += (sender, e) =>
            {
                // Deselect previously selected panel
                if (currentlySelectedPanel != null)
                {
                    currentlySelectedPanel.BackColor = ColorTranslator.FromHtml(Constants.DarkBlue);
                    currentlySelectedPanel.Invalidate(true);
                }

                currentlySelectedPanel = panelSongCard;
                panelSongCard.BackColor = ColorTranslator.FromHtml(Constants.HoverBlue);
                panelSongCard.Invalidate();

                musicPlayerPanel.ClearProgress();
                musicPlayerPanel.SetPlaying(true);
                musicPlayerPanel.UpdatePlayPauseButton();
                musicPlayerPanel.UpdateHeart();
                audioService.Play(s);
                feed.LoadLyrics();
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
            addToPlaylistBtn.FlatStyle = FlatStyle.Flat;
            addToPlaylistBtn.FlatAppearance.BorderSize = 0;

            addToPlaylistBtn.Click += (sender, e) =>
            {
                contextMenuStrip.Show(addToPlaylistBtn, new Point(0, addToPlaylistBtn.Height));
            };

            lblAlbum.MouseEnter += (sender, e) =>
            {
                lblAlbum.Font = new Font(Constants.ProjectFont, 7, FontStyle.Regular | FontStyle.Underline);
            };

            lblAlbum.MouseLeave += (sender, e) =>
            {
                lblAlbum.Font = new Font(Constants.ProjectFont, 7, FontStyle.Regular);
            };

            panelSongCard.MouseEnter += (sender, e) =>
            {
                if (panelSongCard == currentlySelectedPanel) return;

                isHovered = true;
                panelSongCard.Invalidate();
            };

            panelSongCard.MouseLeave += (sender, e) =>
            {
                if (panelSongCard == currentlySelectedPanel) return;

                isHovered = false;
                panelSongCard.Invalidate();
            };

            panelSongCard.MouseClick += (sender, e) =>
            {
                // Deselect previously selected panel
                if (currentlySelectedPanel != null)
                {
                    currentlySelectedPanel.BackColor = ColorTranslator.FromHtml(Constants.DarkBlue);
                    currentlySelectedPanel.Invalidate(true);

                }

                currentlySelectedPanel = panelSongCard;
                panelSongCard.BackColor = ColorTranslator.FromHtml(Constants.HoverBlue);
                panelSongCard.Invalidate();
            };

            panelSongCard.Paint += (sender, e) =>
            {
                if (panelSongCard == currentlySelectedPanel)
                {
                    panelSongCard.BackColor = ColorTranslator.FromHtml(Constants.HoverBlue);

                    using (Pen pen = new Pen(ColorTranslator.FromHtml(Constants.OrangeColor), Constants.HoverPenWidth))
                    {
                        e.Graphics.DrawLine(pen, 0, 0, 0, panelSongCard.Height);
                    }
                }
                else if (isHovered)
                {
                    //using (Pen pen = new Pen(ColorTranslator.FromHtml(Constants.HoverGrey), Constants.HoverPenWidth))
                    //{
                    //    e.Graphics.DrawLine(pen, 0, 0, 0, panelSongCard.Height);
                    //}

                    panelSongCard.BackColor = ColorTranslator.FromHtml(Constants.HoverGrey);
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
            panelSongCard.Controls.Add(addToPlaylistBtn);
            panelSongCard.Controls.Add(lblAlbum);

            parentComponent.Controls.Add(panelSongCard);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
