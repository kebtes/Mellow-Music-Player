using System;
using Mellow_Music_Player.Source.Models;
using NAudio.Wave;

namespace Mellow_Music_Player.Source.Services
{
    internal class AudioService
    {
        private IWavePlayer waveOut;
        private AudioFileReader audioFile;
        private SongQueue songQueue = new SongQueue();
        private Song currentSong;

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
                audioFile = new AudioFileReader(song.FilePath);
                waveOut.Init(audioFile);
                waveOut.Play();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
