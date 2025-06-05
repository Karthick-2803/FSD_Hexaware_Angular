using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection2.Models;

namespace Collection2.Interface
{
    public interface IPlaylist
    {
        void Add(Song song);
        void Remove(int SongId);
        Song GetSongById(int songId);
        Song GetSongByName(string songName);
        List<Song> GetAllSongs();


    }
}
