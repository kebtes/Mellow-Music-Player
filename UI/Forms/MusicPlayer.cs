using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using NAudio.Wave;

using Mellow_Music_Player.Source.Services;
using Mellow_Music_Player.Source.Models;
using Mellow_Music_Player.Source;

namespace Mellow_Music_Player.UI.Forms
{
    public partial class MusicPlayerPanel : Form
    {
        private SongQueue songQueue;
        private Song currentSong;
        private BindingSource bindingSource;
        private AudioService audioService;

        private bool isPlaying = false;

        public MusicPlayerPanel()
        {
            InitializeComponent();

            songQueue = new SongQueue();
            bindingSource = new BindingSource();
            currentSong = songQueue.GetCurrentSong();
            audioService = new AudioService();

            bindingSource.DataSource = currentSong;

            albumArtPanel.DataBindings.Clear();
            musicTitleLabel.DataBindings.Clear();

            Binding imageBinding = new Binding("BackgroundImage", bindingSource, "AlbumArt");

            imageBinding.Format += (s, e) =>
            {
                if (e.Value is Image originalImage)
                {
                    e.Value = ScaleImage.scaleImage(originalImage, this.albumArtPanel.Width, this.albumArtPanel.Height);
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
            audioService.Play();
            playPauseButton.Refresh();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            isPlaying = true;
            currentSong = songQueue.GetPrevSong();
            bindingSource.DataSource = currentSong;
            bindingSource.ResetBindings(false);
            audioService.Play();
            playPauseButton.Refresh();
        }

        private void playPauseButton_Click(object sender, EventArgs e)
        {
            if (isPlaying) audioService.Stop();
            else audioService.Play();

            isPlaying = !isPlaying;

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
                playPauseButton.Image = ScaleImage.scaleImage(Image.FromFile(Constants.PauseButtonSelectedIcon), 21, 21);
            }
            else
            {
                playPauseButton.Image = ScaleImage.scaleImage(Image.FromFile(Constants.PlayButtonSelectedIcon), 21, 21);
            }

            playPauseButton.Refresh();
        }

        private void playPauseButton_MouseLeave(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                playPauseButton.Image = ScaleImage.scaleImage(Image.FromFile(Constants.PauseButtonIcon), 21, 21);
            }
            else
            {
                playPauseButton.Image = ScaleImage.scaleImage(Image.FromFile(Constants.PlayButtonIcon), 21, 21);
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
    }
}
