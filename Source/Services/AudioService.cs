using Mellow_Music_Player.Source.Models;
using Mellow_Music_Player.UI.Forms;
using NAudio.Wave;
using System;

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
                if (currentSong == null) currentSong = songQueue.GetCurrentSong();

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

        public void Play(Song song)
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

                playBackPosition = TimeSpan.Zero;

                waveOut.Init(audioFile);
                waveOut.Play();

                _musicPlayerPanelInstance.setCurrentSong(currentSong);

                playBackPosition = TimeSpan.Zero;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Next()
        {
            currentSong = songQueue.GetCurrentSong();

            Play(false);
        }

        public void Prev()
        {
            currentSong = songQueue.GetCurrentSong();
            Play(false);
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

        public Song GetCurrentSong()
        {
            if (currentSong == null)
            {
                currentSong = songQueue.GetCurrentSong();
            }
            return currentSong;
        }

        public void SkimBack()
        {
            if (audioFile == null) return;

            double newPlayBackPos = audioFile.CurrentTime.TotalSeconds - 10;
            audioFile.CurrentTime = TimeSpan.FromSeconds(Math.Max(newPlayBackPos, 0.0f));
        }

        public void SkimForward()
        {
            if (audioFile == null || currentSong == null) return;

            double newPlayBackPos = audioFile.CurrentTime.TotalSeconds + 10;
            audioFile.CurrentTime = TimeSpan.FromSeconds(Math.Min(newPlayBackPos, currentSong.Duration.TotalSeconds));
        }
    }
}
