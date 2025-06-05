using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection2.Interface;
using Collection2.Models;

namespace Collection2.Services
{
    public class MyPlayList : IPlaylist
    {
        public static List<Song> myPlayList = new List<Song>();
        private int capacity = 20;
        private readonly List<string> allowedGenres = new List<string>
        {
            "Pop", "HipHop", "Soul Music", "Jazz", "Rock", "Disco", "Melody", "Classic"
        };

        public void Add(Song song)
        {
            if (myPlayList.Count >= capacity)
            {
                Console.WriteLine("Playlist is full.");
                return;
            }
            if (!allowedGenres.Contains(song.SongGenre))
            {
                Console.WriteLine("Invalid genre.");
                return;
            }
            myPlayList.Add(song);
            Console.WriteLine("Song added.");
        }

        public void Remove(int songId)
        {
            var song = myPlayList.FirstOrDefault(s => s.SongId == songId);
            if (song != null)
            {
                myPlayList.Remove(song);
                Console.WriteLine("Song removed.");
            }
            else Console.WriteLine("Song not found.");
        }

        public Song GetSongById(int songId) =>
            myPlayList.FirstOrDefault(s => s.SongId == songId);

        public Song GetSongByName(string songName) =>
            myPlayList.FirstOrDefault(s => s.SongName.Equals(songName, StringComparison.OrdinalIgnoreCase));

        public List<Song> GetAllSongs() => myPlayList;
    }
}
