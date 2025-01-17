using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Mellow_Music_Player.Source;
using Mellow_Music_Player.Source.Models;
using Mellow_Music_Player.Source.Services;
using Mellow_Music_Player.Source.Services.Database_Services;
using Mellow_Music_Player.Source.Services.DatabaseServices;
using Mellow_Music_Player.UI.Forms;

namespace Mellow_Music_Player.UI
{
    public partial class panelFeed : Form
    {
        //private FileService fileService;
        private AudioService audioService;
        private MusicPlayerPanel musicPlayerPanel;
        private Main mainUi;
        //private MusicPlayerPanel musicPlayerPanel;

        public panelFeed(AudioService audioService, MusicPlayerPanel musicPlayerPanel, Main mainUi)
        {
            //fileService = new FileService();
            this.DoubleBuffered = true;

            this.mainUi = mainUi;
            this.audioService = audioService;
            this.musicPlayerPanel = musicPlayerPanel;

            InitializeComponent();
            LoadSongs();
            LoadLyrics();
        }

        /*
         Helper function to create a song card and add it to the parent component.
         */
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
                Location = new Point(500, 15),
            };
            Button addToPlaylistBtn = new Button
            {
                Size = new Size(25, 25),
                BackgroundImage = ScaleImage.Scale(Image.FromFile(Constants.AddIcon), 25, 25),
                Location = new Point(530, 18),
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
                audioService.Play(s);
                LoadLyrics();
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

            lblAlbum.Click += (sender, e) =>
            {
                Album album = new Album
                {
                    AlbumName = s.Album,
                    AlbumArt = s.AlbumArt,
                    Artists = string.Join(" ", s.Artists)
                };

                album.Songs = DatabaseService.GetAlbumSongs(album.AlbumName);
                mainUi.LoadPage(new Page(album, musicPlayerPanel, audioService, this));
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


            if (fieldHighlight.HasValue)
            {
                switch (fieldHighlight.Value)
                {
                    case Fields.Title:
                        lblSongTitle.ForeColor = ColorTranslator.FromHtml(Constants.HighlightColor);
                        break;
                    case Fields.Artist:
                        lblArtist.ForeColor = ColorTranslator.FromHtml(Constants.HighlightColor);
                        break;
                    default:
                        break;
                }
            }

            panelSongCard.Controls.Add(lblSongTitle);
            panelSongCard.Controls.Add(lblArtist);
            panelSongCard.Controls.Add(panelAlbumArt);
            panelSongCard.Controls.Add(playButton);
            panelSongCard.Controls.Add(addToPlaylistBtn);
            panelSongCard.Controls.Add(lblAlbum);

            parentComponent.Controls.Add(panelSongCard);
        }

        private void LoadSongs()
        {
            //Panel selectedCard = null;
            flowLayoutPanel.Controls.Clear();

            DatabaseService.GetSongs().ForEach(s =>
            {
                CreateSongCard(s, flowLayoutPanel);
            });
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

        private void searchBoxTextArea_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel.Controls.Clear();

            if (searchBoxTextArea.Text.Length == 0)
            {
                LoadSongs();
                return;
            }
            

            List<Tuple<Song, Fields>> searchResulst = SearchService.Search(searchBoxTextArea.Text);
            foreach (var item in searchResulst)
            {
                Song song = item.Item1;
                Fields highlightField = item.Item2;

                CreateSongCard(song, flowLayoutPanel, highlightField);
            }

         
        }

        public void LoadLyrics()
        {
            //if (audioService.GetCurrentSong() == null) return;

            bool lyricsExist = DatabaseService.CheckLyricsExist(audioService.GetCurrentSong());
            
            if (lyricsExist)
            {
                try
                {
                    rightSidePanel.Controls.Clear();

                    TextBox lyricsTextBox = new TextBox()
                    {
                        Text = "Loading lyrics...",
                        ForeColor = ColorTranslator.FromHtml("#181B22"),
                        //Dock = DockStyle.Fill,
                        Size = new Size(rightSidePanel.Width + 25, rightSidePanel.Height),
                        Multiline = true,
                        BackColor = ColorTranslator.FromHtml(Constants.DarkBlue),
                        Font = new Font(Constants.ProjectFont, 9, FontStyle.Regular),
                        BorderStyle = BorderStyle.None,
                    };
                    lyricsTextBox.ScrollBars = ScrollBars.Both;
                    
                    Song song = audioService.GetCurrentSong();

                    var lyrics = DatabaseService.GetSongLyrics(song);
                    lyricsTextBox.ForeColor = Color.White;
                    lyricsTextBox.TextAlign = HorizontalAlignment.Left;
                    lyricsTextBox.Text = lyrics;

                    rightSidePanel.Controls.Add(lyricsTextBox);
                }
                catch (Exception)
                {
                    ErrorLoadingLyrics();
                    return;
                }
            }
            else
            {
                DownloadSongLyricsPrompt();
            }
        }

        public void RemoveHighlight()
        {
            if (currentlySelectedPanel != null)
            {
                currentlySelectedPanel.BackColor = ColorTranslator.FromHtml(Constants.DarkBlue);
                currentlySelectedPanel.Invalidate(true);
            }
        }

        public void DownloadSongLyricsPrompt()
        {
            rightSidePanel.Controls.Clear();

            Button downloadButton = new Button
            {
                Size = new Size(23, 23),
                Image = Image.FromFile(Constants.DownloadIcon),
                Location = new Point(130, 252),
                FlatAppearance = { BorderSize = 0 },
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            Label promptText = new Label
            {
                Text = "Click here to download lyrics",
                Size = new Size(210, 16),
                Location = new Point(48, 278),
                ForeColor = Color.White,
                Font = new Font(Constants.ProjectFont, 8, FontStyle.Regular)
            };

            downloadButton.MouseEnter += (sender, e) =>
            {
                downloadButton.Image = Image.FromFile(Constants.DownloadSelectedIcon);
            };
            downloadButton.MouseLeave += (sender, e) =>
            {
                downloadButton.Image = Image.FromFile(Constants.DownloadIcon);
            };
            
            downloadButton.Click += async (sender, e) =>
            {
                downloadButton.Visible = false;
                promptText.Text = "Downloading lyrics...";
                promptText.Location = new Point(80, 252);
                try
                {
                    await LyricsService.GetLyrics(audioService.GetCurrentSong());
                    LoadLyrics();
                }
                catch (Exception)
                {
                    ErrorLoadingLyrics();
                    return;
                }
            };

            rightSidePanel.Controls.Add(downloadButton);
            rightSidePanel.Controls.Add(promptText);
        }


        public void ErrorLoadingLyrics()
        {
            rightSidePanel.Controls.Clear();

            Button errorButton = new Button
            {
                Size = new Size(23, 23),
                Image = Image.FromFile(Constants.ErrorIcon),
                Location = new Point(130, 252),
                FlatAppearance = { BorderSize = 0 },
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            Label promptText = new Label
            {
                Text = "Error loading lyrics, try again later",
                Size = new Size(210, 16),
                Location = new Point(47, 278),
                ForeColor = Color.White,
                Font = new Font(Constants.ProjectFont, 8, FontStyle.Regular)
            };

            rightSidePanel.Controls.Add(errorButton);
            rightSidePanel.Controls.Add(promptText);
        }
        public void SetMusicPlayerPanelInstance(MusicPlayerPanel musicPlayerPanel)
        {
            this.musicPlayerPanel = musicPlayerPanel;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonDirectory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                folderBrowser.Description = "Select the directory where your music is stored";
                folderBrowser.SelectedPath = "C:\\Users\\CompUser\\Music";
                
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderBrowser.SelectedPath;

                    Settings.SongsDirectory = selectedFolder;
                    
                    FileService.Refresh();

                    LoadSongs();
                    LoadLyrics();
                }
            }
        }
    }
}
