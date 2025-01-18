using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using Mellow_Music_Player.Source.Models;
using Mellow_Music_Player.Source.Services.Database_Services;
using Mellow_Music_Player.Source.Services;
using Mellow_Music_Player.Source;
using Mellow_Music_Player.Source.Services.DatabaseServices;

namespace Mellow_Music_Player.UI.Forms
{
    public partial class Playlists : Form
    {
        AudioService audioService;
        MusicPlayerPanel musicPlayerPanel;
        Playlist selectedPlaylistName = null;

        public Playlists(AudioService audioService, MusicPlayerPanel musicPlayerPanel)
        {
            this.audioService = audioService;
            this.DoubleBuffered = true;
            this.musicPlayerPanel = musicPlayerPanel;

            string lastPlayedPlaylist = Settings.LastOpenedPlaylist;

            if (lastPlayedPlaylist != null) { 
            }
            InitializeComponent();
            LoadPlaylists();
        }

        public void LoadPlaylists()
        {
            playlistLayoutPanel.Controls.Clear();

            List<Playlist> playlists = DatabaseService.GetPlaylists();

            foreach (var playlist in playlists)
            {
                CreatePlaylistLabels(playlist, playlistLayoutPanel);
            }
        }

        private Label selectedPlaylistLabel = null;
        private void CreatePlaylistLabels(Playlist playlist, Panel parentPanel)
        {
            const string unselColor = "#E0DCDC";

            Label playlistNameLabel = new Label
            {
                Text = playlist.PlaylistName,
                Size = new Size(574, 20),
                Font = new Font(Constants.ProjectFont, 8, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml(unselColor),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
            };

            playlistNameLabel.MouseEnter += (sender, e) =>
            {
                if (playlistNameLabel != selectedPlaylistLabel)
                {
                    playlistNameLabel.Font = new Font(Constants.ProjectFont, 8, FontStyle.Bold | FontStyle.Underline);
                }
            };

            playlistNameLabel.MouseLeave += (sender, e) =>
            {
                if (playlistNameLabel != selectedPlaylistLabel)
                {
                    playlistNameLabel.Font = new Font(Constants.ProjectFont, 8, FontStyle.Bold);
                }
            };

            playlistNameLabel.Click += (sender, e) =>
            {
                if (selectedPlaylistLabel != null)
                {
                    selectedPlaylistLabel.Font = new Font(Constants.ProjectFont, 8, FontStyle.Bold);
                    selectedPlaylistLabel.ForeColor = ColorTranslator.FromHtml(unselColor);

                
                }
                playlistName.Text = playlist.PlaylistName;
                selectedPlaylistName = playlist;
                selectedPlaylistLabel = playlistNameLabel;
                selectedPlaylistLabel.Font = new Font(Constants.ProjectFont, 8, FontStyle.Bold | FontStyle.Underline);
                selectedPlaylistLabel.ForeColor = ColorTranslator.FromHtml(Constants.OrangeColor);
                playlistCreatedDate.Text = $"Created at : {playlist.CreatedAt.ToString()}";

                deletePlaylistLbl.Visible = true;

                LoadPlaylistSongs(playlist);
            };

            parentPanel.Controls.Add(playlistNameLabel);
        }

        private void LoadPlaylistSongs(Playlist playlist)
        {
            songLayoutPanel.Controls.Clear();
            List<Song> songs = DatabaseService.GetPlaylistSongs(playlist.PlaylistName);
            
            if (songs.Count == 0)
            {
                PlaylistEmpty();
            }
            else
            {
                foreach (var song in songs)
                {
                    CreateSongCard(song, songLayoutPanel);
                }
            }
        }

        private void PlaylistEmpty()
        {
            songLayoutPanel.Controls.Clear();
            Label playlistEmptyLabel = new Label
            {
                Text = "No songs added to this playlist :(",
                Font = new Font(Constants.ProjectFont, 10, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#181B22"),
                Size = new Size(574, 500),
                Location = new Point(0, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
            };

            songLayoutPanel.Controls.Add(playlistEmptyLabel);
        }

        private Panel currentlySelectedPanel = null;
        public void CreateSongCard(Song s, Panel parentComponent, Fields? fieldHighlight = null)
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
                Location = new Point(500, 15),
            };

            Button removeButton = new Button
            {
                Size = new Size(20, 20),
                BackgroundImage = ScaleImage.Scale(Image.FromFile(Constants.DeleteIcon), 20, 20),
                Location = new Point(530, 20),
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

                //musicPlayerPanel.ClearProgress();
                if (musicPlayerPanel == null)
                {
                    MessageBox.Show("Music Player Panel is null");
                }

                musicPlayerPanel.SetPlaying(true);
                musicPlayerPanel.UpdatePlayPauseButton();
                audioService.Play(s);
            };

            playButton.MouseEnter += (sender, e) =>
            {
                playButton.BackgroundImage = ScaleImage.Scale(Image.FromFile(Constants.PlayButtonSmallSelectedIcon), 30, 30);
            };

            playButton.MouseLeave += (sender, e) =>
            {
                playButton.BackgroundImage = ScaleImage.Scale(Image.FromFile(Constants.PlayButtonSmallIcon), 30, 30);
            };

            removeButton.MouseEnter += (sender, e) =>
            {
                removeButton.BackgroundImage = ScaleImage.Scale(Image.FromFile(Constants.DeleteSelectedIcon), 20, 20);
            };

            removeButton.MouseLeave += (sender, e) =>
            {
                removeButton.BackgroundImage = ScaleImage.Scale(Image.FromFile(Constants.DeleteIcon), 20, 20);
            };

            removeButton.MouseClick += (sender, e) =>
            {
                DatabaseService.RemoveFromPlaylist(selectedPlaylistName.PlaylistName, s);
                LoadPlaylistSongs(selectedPlaylistName);
            };


            playButton.FlatStyle = FlatStyle.Flat;
            playButton.FlatAppearance.BorderSize = 0;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.FlatAppearance.BorderSize = 0;

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
            panelSongCard.Controls.Add(removeButton);

            parentComponent.Controls.Add(panelSongCard);
            parentComponent.Show();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DatabaseService.CreatePlaylist(textBox1.Text);
                LoadPlaylists();
            }
        }

        private void deletePlaylistLbl_MouseEnter(object sender, EventArgs e)
        {
            deletePlaylistLbl.Font = new Font(Constants.ProjectFont, 8, FontStyle.Bold | FontStyle.Underline);
        }

        private void deletePlaylistLbl_MouseLeave(object sender, EventArgs e)
        {
            deletePlaylistLbl.Font = new Font(Constants.ProjectFont, 8, FontStyle.Bold);
        }

        private void deletePlaylistLbl_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void deletePlaylistLbl_Click(object sender, EventArgs e)
        {
            DatabaseService.DeletePlaylist(playlistName.Text);
            LoadPlaylists();
            //LoadPlaylistSongs();
            SelectPlaylistPrompt();
        }

        private void SelectPlaylistPrompt()
        {
            playlistName.Text = "Your Playlists";
            Label tb = new Label()
            {
                //Dock = DockStyle.Fill,
                Font = new Font(Constants.ProjectFont, 10, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml(Constants.DarkBlue2),
                BackColor = ColorTranslator.FromHtml(Constants.DarkBlue),
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.None,
                Size = new Size(574, 492),
                Location = new Point(3, 0),
                Text = "Choose a Playlist to show!!"
            };

            songLayoutPanel.Controls.Clear();
            songLayoutPanel.Controls.Add(tb);

            deletePlaylistLbl.Visible = false;
        }
    }
}
