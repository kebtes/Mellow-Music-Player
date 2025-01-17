using System;
using System.Drawing;
using System.Windows.Forms;

using Mellow_Music_Player.Source.Services;
using Mellow_Music_Player.Source.Models;
using Mellow_Music_Player.Source;
using Mellow_Music_Player.Source.Services.Database_Services;

namespace Mellow_Music_Player.UI.Forms
{
    public partial class MusicPlayerPanel : Form
    {
        private SongQueue songQueue;
        private Song currentSong;
        private BindingSource bindingSource;
        private AudioService audioService;
        //private Settings settings;
        private TimeSpan songCurrentTime = TimeSpan.Zero;
        private panelFeed feed;

        private static bool isPlaying = false;

        private void InitializeTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
            {
                if (audioService.IsPlaying())
                {
                    songCurrentTime = songCurrentTime.Add(TimeSpan.FromSeconds(1));
                    IncrementProgress();
                    UpdateCurrentTimeLabel();
                }
            };
            timer.Start();
        }


        public MusicPlayerPanel(AudioService audioService, panelFeed panelFeed)
        {
            //this.settings = settings;
            this.feed = panelFeed;

            songQueue = new SongQueue();
            bindingSource = new BindingSource();
            currentSong = songQueue.GetCurrentSong();

            this.audioService = audioService;
            this.audioService.SetMusicPlayerInstance(this);

            InitializeComponent();

            if (currentSong != null)
            {
                bindingSource.DataSource = currentSong;

                albumArtPanel.DataBindings.Clear();
                musicTitleLabel.DataBindings.Clear();

                Binding imageBinding = new Binding("BackgroundImage", bindingSource, "AlbumArt");
                imageBinding.Format += (s, e) =>
                {
                    if (e.Value is Image originalImage)
                    {
                        e.Value = ScaleImage.Scale(originalImage, this.albumArtPanel.Width, this.albumArtPanel.Height);
                    }
                };
                this.albumArtPanel.DataBindings.Add(imageBinding);

                Binding artistBinding = new Binding("Text", bindingSource, "Artists");
                artistBinding.Format += (s, e) =>
                {
                    if (e.Value is string[] artistArray)
                    {
                        e.Value = string.Join(", ", artistArray);
                    }
                };

                this.artistNameLabel.DataBindings.Add(artistBinding);
                this.musicTitleLabel.DataBindings.Add("Text", bindingSource, "Title");

                Binding totalTimeBinding = new Binding("Text", bindingSource, "Duration");
                totalTimeBinding.Format += (s, e) =>
                {
                    if (e.Value is TimeSpan timeSpan)
                    {
                        e.Value = timeSpan.ToString(@"mm\:ss");
                    }
                };

                this.totalTime.DataBindings.Add(totalTimeBinding);
                UpdateHeart();
            }
            else
            {
                // default values when no song is loaded
                this.albumArtPanel.BackgroundImage = null;
                this.artistNameLabel.Text = "No Artist";
                this.musicTitleLabel.Text = "No Song Selected";
                this.totalTime.Text = "00:00";
            }

            InitializeTimer();
        }

        private void UpdateHeart()
        {
            bool likedSong = DatabaseService.IsSongInPlaylist("Liked Songs", currentSong);

            if (likedSong)
            {
                heartButton.Image = Image.FromFile(Constants.HeartIconSelected);
            }
            else
            {
                heartButton.Image = Image.FromFile(Constants.HeartIcon);
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            isPlaying = true;
            currentSong = songQueue.GetNextSong();
            bindingSource.DataSource = currentSong;
            bindingSource.ResetBindings(false);
            ClearProgress();
            songCurrentTime = TimeSpan.Zero;
            audioService.Next();
            //audioService.Play(false);
            UpdatePlayPauseButton();
            feed.LoadLyrics();
            UpdateHeart();
            feed.RemoveHighlight();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            isPlaying = true;
            currentSong = songQueue.GetPrevSong();
            bindingSource.DataSource = currentSong;
            bindingSource.ResetBindings(false);
            ClearProgress();
            songCurrentTime = TimeSpan.Zero;
            audioService.Prev();
            //audioService.Play(false);
            UpdatePlayPauseButton();
            feed.LoadLyrics();
            UpdateHeart();
            feed.RemoveHighlight();
        }

        private void playPauseButton_Click(object sender, EventArgs e)
        {
            if (isPlaying) audioService.Stop();
            else audioService.Play();

            isPlaying = !isPlaying;
            SetProgressMaximum();

            UpdatePlayPauseButton();
            feed.LoadLyrics();
        }

        public void UpdatePlayPauseButton()
        {
            if (isPlaying)
            {
                playPauseButton.Image = ScaleImage.Scale(Image.FromFile(Constants.PauseButtonIcon), 21, 21);
            }
            else
            {
                playPauseButton.Image = ScaleImage.Scale(Image.FromFile(Constants.PlayButtonIcon), 21, 21);
            }
        }

        private void playPauseButton_MouseEnter(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                playPauseButton.Image = ScaleImage.Scale(Image.FromFile(Constants.PauseButtonSelectedIcon), 21, 21);
            }
            else
            {
                playPauseButton.Image = ScaleImage.Scale(Image.FromFile(Constants.PlayButtonSelectedIcon), 21, 21);
            }

            UpdatePlayPauseButton();
        }

        private void playPauseButton_MouseLeave(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                playPauseButton.Image = ScaleImage.Scale(Image.FromFile(Constants.PauseButtonIcon), 21, 21);
            }
            else
            {
                playPauseButton.Image = ScaleImage.Scale(Image.FromFile(Constants.PlayButtonIcon), 21, 21);
            }

            UpdatePlayPauseButton();
        }

        public void setCurrentSong(Song song)
        {
            currentSong = song;
            bindingSource.DataSource = currentSong;
            bindingSource.ResetBindings(false);
            audioService.Play();
        }

        private void volumeTrackBar_Scroll(object sender, EventArgs e)
        {
            audioService.SetVolume(volumeTrackBar.Value);
        }

        private void SetProgressMaximum()
        {
            progressBar.Maximum = (int) currentSong.Duration.TotalSeconds;
        }
        private void IncrementProgress()
        {
            progressBar.Value++;
        }

        public void ClearProgress()
        {
            progressBar.Value = 0;
        }
        public float GetVal()
        {
            return progressBar.Value;
        }

        private void volumeTrackBar_ValueChanged()
        {
            audioService.SetVolume(volumeTrackBar.Value / 100.0f);
        }

        private void currentTime_Click(object sender, EventArgs e)
        {
        }

        public void SetPlaying(bool status)
        {
            isPlaying = status;
            playPauseButton.Invalidate();
        }

        private void UpdateCurrentTimeLabel()
        {
            currentTime.Text = songCurrentTime.ToString(@"mm\:ss");
        }

        private void prevButton_MouseEnter(object sender, EventArgs e)
        {
            prevButton.Image = ScaleImage.Scale(Image.FromFile(Constants.PreviousButtonSelectedIcon), 16, 16);
        }

        private void prevButton_MouseLeave(object sender, EventArgs e)
        {
            prevButton.Image = ScaleImage.Scale(Image.FromFile(Constants.PreviousButtonIcon), 16, 16);
        }

        private void nextButton_MouseEnter(object sender, EventArgs e)
        {
            nextButton.Image = ScaleImage.Scale(Image.FromFile(Constants.NextButtonSelectedIcon), 16, 16);
        }

        private void nextButton_MouseLeave(object sender, EventArgs e)
        {
            nextButton.Image = ScaleImage.Scale(Image.FromFile(Constants.NextButtonIcon), 16, 16);
        }

        private void playPauseButton_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void heartButton_Click(object sender, EventArgs e)
        {
            bool likedSong = DatabaseService.IsSongInPlaylist("Liked Songs", currentSong);
            
            if (likedSong) DatabaseService.RemoveFromPlaylist("Liked Songs", currentSong); 
            else DatabaseService.AddToPlaylist("Liked Songs", currentSong);

            UpdateHeart();
        }

        public void SetFeedPanel(panelFeed feed)
        {
            this.feed = feed;
        }

        private void playPauseButton_Paint_1(object sender, PaintEventArgs e)
        {
            if (isPlaying)
            {
                playPauseButton.Image = ScaleImage.Scale(Image.FromFile(Constants.PlayButtonIcon), 21, 21);
            }

            else
            {
                playPauseButton.Image = ScaleImage.Scale(Image.FromFile(Constants.PauseButtonIcon), 21, 21);
            }
        }
    }
}
