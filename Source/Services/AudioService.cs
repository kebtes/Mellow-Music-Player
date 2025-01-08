using System;
using System.Diagnostics;
using System.Windows.Forms;
using Mellow_Music_Player.Source.Models;
using Mellow_Music_Player.UI.Forms;
using NAudio.Wave;

namespace Mellow_Music_Player.Source.Services
{
    public class AudioService
    {
        private IWavePlayer waveOut;
        private AudioFileReader audioFile;
        private SongQueue songQueue = new SongQueue();
        private Song currentSong;

        private MusicPlayerPanel _musicPlayerPanelInstance;

        public void Play()
        {
            try
            {
                Stop();

                currentSong = songQueue.GetCurrentSong();
                
                waveOut = new WaveOutEvent();
                audioFile = new AudioFileReader(currentSong.FilePath);
                waveOut.Init(audioFile);
                waveOut.Play();

            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Stop()
        {
            waveOut?.Stop();
            waveOut?.Dispose();
            waveOut = null;

            audioFile?.Dispose();
            audioFile = null;
        }

        public void PlaySong(Song song)
        {
            try
            {
                Stop();

                currentSong = song;

                waveOut = new WaveOutEvent();
                audioFile = new AudioFileReader(currentSong.FilePath);
                waveOut.Init(audioFile);
                waveOut.Play();
                _musicPlayerPanelInstance.setCurrentSong(currentSong);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void SetMusicPlayerInstance(MusicPlayerPanel instance)
        {
            _musicPlayerPanelInstance = instance;
        }
    }
}
