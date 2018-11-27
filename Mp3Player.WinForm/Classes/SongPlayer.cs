using Mp3Player.Models;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Mp3Player.WinForm.Classes
{
	public class SongPlayer : BindingList<Mp3File>, IDisposable
	{
		private IWavePlayer _player;
		private Mp3FileReader _reader;
		private readonly string _basePath;
		private bool _playNext = false;
		private int _songIndex = 0;
		private List<int> _songsPlayed = new List<int>();

		public event EventHandler SongPlaying;

		public SongPlayer(string basePath)
		{
			_basePath = basePath;
			_player = new WaveOut();
			_player.PlaybackStopped += PlaybackStopped;
			_playNext = true;
		}

		public new void Add(Mp3File mp3File)
		{			
			base.Add(mp3File);
			Play(Count - 1);
		}

		private void PlaybackStopped(object sender, StoppedEventArgs e)
		{
			_songsPlayed.Add(Current.Id);

			if (_playNext)
			{
				_songIndex = (IsShuffled) ? NextRandom(_songsPlayed) : _songIndex + 1;

				if (_songIndex > Count || _songIndex < 0)
				{
					if (!Repeat) return;
					_songIndex = 0;
					_songsPlayed = new List<int>();
				}

				Play(_songIndex);
			}
		}

		private int NextRandom(List<int> exceptSongsPlayed)
		{
			var candidateSongs = this.AsEnumerable().Where(mp3 => !exceptSongsPlayed.Contains(mp3.Id)).ToArray();
			if (!candidateSongs.Any()) return -1;
			return new Random().Next(candidateSongs.Length + 1);			
		}

		/// <summary>
		/// Next song is chosen at random, but songs already played aren't played again
		/// </summary>
		public bool IsShuffled { get; set; }

		public bool Repeat { get; set; }

		/// <summary>
		/// Plays the first song in the list, then moves to the next
		/// </summary>
		public void Play(int index = 0)
		{
			_player.Stop();
			
			Current = this[index];

			_reader?.Dispose();			
			_reader = new Mp3FileReader(Path.Combine(_basePath, Current.Path));

			_player.Init(_reader);
			_player.Play();
			SongPlaying?.Invoke(Current, new EventArgs());
		}

		public Mp3File Current { get; private set; }

		public void Dispose()
		{
			_player?.Stop();
			_player?.Dispose();
			_reader?.Dispose();
		}
	}
}