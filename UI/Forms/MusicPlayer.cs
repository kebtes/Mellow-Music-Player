using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ReaLTaiizor.Colors;

using Mellow_Music_Player.Source.Services;
using Mellow_Music_Player.Source.Models;
using Mellow_Music_Player.Source;
using ReaLTaiizor.Manager;

namespace Mellow_Music_Player.UI.Forms
{
    public partial class MusicPlayerPanel : Form
    {
        private SongQueue songQueue;
        private Song currentSong;
        private BindingSource bindingSource;
        private AudioService audioService;
        private Settings settings;

        private bool isPlaying = false;

        private readonly MaterialSkinManager materialSkinManager;

        private void InitializeTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
            {
                if (audioService.IsPlaying())
                {
                    IncrementProgress();
                }
            };
            timer.Start();
        }

        public MusicPlayerPanel(AudioService audioService, Settings settings)
        {
            this.settings = settings;

            InitializeComponent();
            InitializeTimer();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ColorScheme = new MaterialColorScheme(Constants.OrangeColor, Constants.OrangeColor, Constants.OrangeColor, Constants.HoverGrey, Constants.OrangeColor);
            
            songQueue = new SongQueue();
            bindingSource = new BindingSource();
            currentSong = songQueue.GetCurrentSong();

            this.audioService = audioService;
            this.audioService.SetMusicPlayerInstance(this);

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
            
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            isPlaying = true;
            currentSong = songQueue.GetNextSong();
            bindingSource.DataSource = currentSong;
            bindingSource.ResetBindings(false);
            ClearProgress();
            audioService.Play(false);
            playPauseButton.Refresh();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            isPlaying = true;
            currentSong = songQueue.GetPrevSong();
            bindingSource.DataSource = currentSong;
            bindingSource.ResetBindings(false);
            ClearProgress();
            audioService.Play(false);
            playPauseButton.Refresh();
        }

        private void playPauseButton_Click(object sender, EventArgs e)
        {
            if (isPlaying) audioService.Stop();
            else audioService.Play();

            isPlaying = !isPlaying;
            SetProgressMaximum();

            playPauseButton.Refresh();
        }

        private void playPauseButton_Paint(object sender, PaintEventArgs e)
        {
            //if (isPlaying)
            //{
            //    playPauseButton.Image = ScaleImage.scaleImage(Image.FromFile(Constants.PauseButtonIcon), 21, 21);
            //}
            //else
            //{
            //    playPauseButton.Image = ScaleImage.scaleImage(Image.FromFile(Constants.PlayButtonIcon), 21, 21);
            //}
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

            playPauseButton.Refresh();
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

            playPauseButton.Refresh();
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

        private void ClearProgress()
        {
            progressBar.Value = 0;
        }

        private void volumeTrackBar_ValueChanged()
        {
            audioService.SetVolume(volumeTrackBar.Value / 100.0f);
        }
    }
}
