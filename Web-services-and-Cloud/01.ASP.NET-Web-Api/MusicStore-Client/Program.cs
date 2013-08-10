using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore_Model;

namespace MusicStore_Client
{
    class Program
    {
        //seed some objects in database
        static void Main()
        {
            MusicStoreEntities dbcon = new MusicStoreEntities();
            Album album1 = new Album()
            {
                Title = "Album1",
                Year = 1995,
                Producer = "Producer1"
            };

            album1.Artists.Add(
                new Artist()
                {
                    Name = "Artist1",
                    Country = "Bulgaria",
                    DateOfBirth = new DateTime(1912, 5, 12)
                });
            album1.Artists.Add(
                new Artist()
                {
                    Name = "Artist2",
                    Country = "Germany",
                    DateOfBirth = new DateTime(1982, 1, 24)
                });

            album1.Songs.Add(
                new Song()
                {
                    Title = "Song1",
                    Year = 1896,
                    Genre = "Jazz",
                    ArtistId = 11
                });
            album1.Songs.Add(
                new Song()
                {
                    Title = "Song2",
                    Year = 1932,
                    Genre = "Jazz",
                    ArtistId = 11
                });
            album1.Songs.Add(
                new Song()
                {
                    Title = "Song3",
                    Year = 1999,
                    Genre = "Pop",
                    ArtistId = 12
                });

            dbcon.Albums.Add(album1);
            dbcon.SaveChanges();
        }
    }
}
