using Collection2.Models;
using Collection2.Services;

namespace Collection2
{
    class Program
    {
        static void Main()
        {
            MyPlayList playlist = new MyPlayList();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n1: Add Song\n2: Remove Song by Id\n3: Get Song by Id\n4: Get Song by Name\n5: Get All Songs\n6: Exit");
                Console.Write("Choice: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Song ID: "); int id = int.Parse(Console.ReadLine());
                        Console.Write("Song Name: "); string name = Console.ReadLine();
                        Console.Write("Song Genre: "); string genre = Console.ReadLine();
                        playlist.Add(new Song { SongId = id, SongName = name, SongGenre = genre });
                        break;
                    case "2":
                        Console.Write("Song ID to remove: "); int rid = int.Parse(Console.ReadLine());
                        playlist.Remove(rid);
                        break;
                    case "3":
                        Console.Write("Song ID: "); int sid = int.Parse(Console.ReadLine());
                        var songById = playlist.GetSongById(sid);
                        if (songById != null)
                            Console.WriteLine($"ID: {songById.SongId}, Name: {songById.SongName}, Genre: {songById.SongGenre}");
                        else Console.WriteLine("Not found.");
                        break;
                    case "4":
                        Console.Write("Song Name: "); string sname = Console.ReadLine();
                        var songByName = playlist.GetSongByName(sname);
                        if (songByName != null)
                            Console.WriteLine($"ID: {songByName.SongId}, Name: {songByName.SongName}, Genre: {songByName.SongGenre}");
                        else Console.WriteLine("Not found.");
                        break;
                    case "5":
                        var songs = playlist.GetAllSongs();
                        foreach (var s in songs)
                            Console.WriteLine($"ID: {s.SongId}, Name: {s.SongName}, Genre: {s.SongGenre}");
                        break;
                    case "6":
                        running = false;
                        break;
                }
            }
        }
    }
}
