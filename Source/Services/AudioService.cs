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
        private float volume = 1.0f;

        private MusicPlayerPanel _musicPlayerPanelInstance;

        private TimeSpan playBackPosition = TimeSpan.Zero;

        public void Play(bool fromPlayBackPos = true)
        {
            try
            {
                currentSong = songQueue.GetCurrentSong();

                Stop();

                waveOut = new WaveOutEvent();
                audioFile = new AudioFileReader(currentSong.FilePath)
                {
                    Volume = volume
                };

                audioFile.CurrentTime = fromPlayBackPos ? playBackPosition : TimeSpan.Zero;
                
                waveOut.Init(audioFile);
                waveOut.Play();

                playBackPosition = TimeSpan.Zero;

            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Stop()
        {
            if (waveOut != null && audioFile != null)
            {
                playBackPosition = audioFile.CurrentTime;
            }

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
                audioFile = new AudioFileReader(currentSong.FilePath)
                {
                    Volume = volume
                };

                if (currentSong.FilePath == song.FilePath && playBackPosition != TimeSpan.Zero)
                {
                    audioFile.CurrentTime = playBackPosition;
                }

                waveOut.Init(audioFile);
                waveOut.Play();

                _musicPlayerPanelInstance.setCurrentSong(currentSong);

                playBackPosition = TimeSpan.Zero;

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

        public bool IsPlaying()
        {
            return waveOut?.PlaybackState == PlaybackState.Playing;
        }

        public void SetVolume(float newVolume)
        {
            newVolume = Math.Min(1.0f, Math.Max(0.0f, newVolume));
            volume = newVolume;

            audioFile.Volume = volume;
        }
    }
}
