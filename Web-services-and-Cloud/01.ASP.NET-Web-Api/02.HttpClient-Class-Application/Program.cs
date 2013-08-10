using MusicStore_Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _02.HttpClient_Class_Application
{
    class ConsoleApplication
    {
        static HttpClient jsonClient;

        static void Main()
        {
            Console.WriteLine("Press 1 for JSON\nPress 2 for XML");

            int formatCmd;

            while (true)
            {
                try
                {
                    formatCmd = int.Parse(Console.ReadLine());
                    if (formatCmd < 0 || formatCmd > 2)
                    {
                        Console.WriteLine("Please, Enter 1 or 2!");
                        continue;
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please, Enter 1 or 2!");
                }
            }

            
            Console.WriteLine("Choose CRUD operation\n1 for Create\n2 for ReadAll" + 
                "\n3 for ReadById\n4 for Update\n5 for Delete");

            int crudCmd;

            while (true)
            {
                try
                {
                    crudCmd = int.Parse(Console.ReadLine());
                    if (crudCmd < 0 || crudCmd > 5)
                    {
                        Console.WriteLine("Please, Enter 1, 2, 3, 4 or 5!");
                        continue;
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please, Enter 1, 2, 3, 4 or 5!");
                }
            }

            Console.WriteLine("Choose object:\n1 for Artist\n2 for Album\n3 for Song");

            int objectCmd;

            while (true)
            {
                try
                {
                    objectCmd = int.Parse(Console.ReadLine());
                    if (objectCmd < 0 || objectCmd > 3)
                    {
                        Console.WriteLine("Please, Enter 1, 2 or 3!");
                        continue;
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please, Enter 1, 2 or 3!");
                }
            }

            jsonClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5718/")
            };

            jsonClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Json
            if (formatCmd == 1)
            {
                if (crudCmd == 1)
                {
                    if (objectCmd == 1)
                    {
                        CreateArtist();
                    }
                    else if (objectCmd == 2)
                    {
                        CreateAlbum();
                    }
                    else if (objectCmd == 3)
                    {
                        CreateSong();
                    }
                }
                else if (crudCmd == 2)
                {
                    if (objectCmd == 1)
                    {
                        ReadArtists();
                    }
                    else if (objectCmd == 2)
                    {
                        ReadAlbums();
                    }
                    else if (objectCmd == 3)
                    {
                        ReadSongs();
                    }
                }
                else if (crudCmd == 3)
                {
                    if (objectCmd == 1)
                    {
                        ReadArtistById();
                    }
                    else if (objectCmd == 2)
                    {
                        ReadAlbumById();
                    }
                    else if (objectCmd == 3)
                    {
                        ReadSongsById();
                    }
                }
                else if (crudCmd == 4)
                {
                    if (objectCmd == 1)
                    {
                        UpdateArtist();
                    }
                    else if (objectCmd == 2)
                    {
                        UpdateAlbum();
                    }
                    else if (objectCmd == 3)
                    {
                        UpdateSong();
                    }
                }
                else if (crudCmd == 5)
                {
                    if (objectCmd == 1)
                    {
                        DeleteArtist();
                    }
                    else if (objectCmd == 2)
                    {
                        DeleteAlbum();
                    }
                    else if (objectCmd == 3)
                    {
                        DeleteSong();
                    }
                }
            }

            //XML
            else if (formatCmd == 2)
            {
                if (crudCmd == 1)
                {
                    if (objectCmd == 1)
                    {
                        XMLHttpClient.CreateArtist();
                    }
                    else if (objectCmd == 2)
                    {
                        XMLHttpClient.CreateAlbum();
                    }
                    else if (objectCmd == 3)
                    {
                        XMLHttpClient.CreateSong();
                    }
                }
                else if (crudCmd == 2)
                {
                    if (objectCmd == 1)
                    {
                        XMLHttpClient.ReadArtists();
                    }
                    else if (objectCmd == 2)
                    {
                        XMLHttpClient.ReadAlbums();
                    }
                    else if (objectCmd == 3)
                    {
                        XMLHttpClient.ReadSongs();
                    }
                }
                else if (crudCmd == 3)
                {
                    if (objectCmd == 1)
                    {
                        XMLHttpClient.ReadArtistById();
                    }
                    else if (objectCmd == 2)
                    {
                        XMLHttpClient.ReadAlbumById();
                    }
                    else if (objectCmd == 3)
                    {
                        XMLHttpClient.ReadSongsById();
                    }
                }
                else if (crudCmd == 4)
                {
                    if (objectCmd == 1)
                    {
                        XMLHttpClient.UpdateArtist();
                    }
                    else if (objectCmd == 2)
                    {
                        XMLHttpClient.UpdateAlbum();
                    }
                    else if (objectCmd == 3)
                    {
                        XMLHttpClient.UpdateSong();
                    }
                }
                else if (crudCmd == 5)
                {
                    if (objectCmd == 1)
                    {
                        XMLHttpClient.DeleteArtist();
                    }
                    else if (objectCmd == 2)
                    {
                        XMLHttpClient.DeleteAlbum();
                    }
                    else if (objectCmd == 3)
                    {
                        XMLHttpClient.DeleteSong();
                    }
                }
            }

            ////Get method
            //HttpResponseMessage getAllResponse = client.GetAsync("api/artists").Result;

            //if (getAllResponse.IsSuccessStatusCode)
            //{
            //    var artists = getAllResponse.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
            //    foreach (var a in artists)
            //    {
            //        Console.WriteLine("{0,4} {1,-10} {2} {3}", a.Id, a.Name, a.Country, a.DateOfBirth);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("{0} ({1})", (int)getAllResponse.StatusCode, getAllResponse.ReasonPhrase);
            //}
            ////Get method - id
            //int getId = 11;
            //HttpResponseMessage getByIdResponse = client.GetAsync("api/artists/" + getId).Result;
            //if (getByIdResponse.IsSuccessStatusCode)
            //{
            //    var artist = getByIdResponse.Content.ReadAsAsync<Artist>().Result;
            //    Console.WriteLine("{0,4} {1,-10} {2} {3}", artist.Id, artist.Name, artist.Country, artist.DateOfBirth);
            //}
            //else
            //{
            //    Console.WriteLine("{0} ({1})", (int)getByIdResponse.StatusCode, getByIdResponse.ReasonPhrase);
            //}
            ////Post method
            //Artist newArtist = new Artist()
            //{
            //    Name = "Gosho",
            //    Country = "Sweden",
            //    DateOfBirth = new DateTime(1966, 06, 06)
            //};
            //var postArtistResponse = client.PostAsJsonAsync("api/artists", newArtist).Result;
            //if (postArtistResponse.IsSuccessStatusCode)
            //{
            //    Console.WriteLine("Artist added!");
            //}
            //else
            //{
            //    Console.WriteLine("{0} ({1})", (int)postArtistResponse.StatusCode, postArtistResponse.ReasonPhrase);
            //}
            ////Update method
            //Artist updatedArtist = new Artist()
            //{
            //    Name = "Pesho",
            //    Country = "Sweden",
            //    DateOfBirth = new DateTime(1966, 06, 06)
            //};
            //int idForUpdate = 15;
            //var putArtistResponse = client.PutAsJsonAsync("api/artists/" + idForUpdate, updatedArtist).Result;
            //if (putArtistResponse.IsSuccessStatusCode)
            //{
            //    Console.WriteLine("Artist updated!");
            //}
            //else
            //{
            //    Console.WriteLine("{0}, ({1})", (int)putArtistResponse.StatusCode, putArtistResponse.ReasonPhrase);
            //}
            ////Delete method
            //int idToDelete = 15;
            //var deleteArtistResponse = client.DeleteAsync("api/artists/" + idToDelete).Result;
            //if (deleteArtistResponse.IsSuccessStatusCode)
            //{
            //    Console.WriteLine("Artist deleted!");
            //}
            //else
            //{
            //    Console.WriteLine("{0}, ({1})", (int)deleteArtistResponse.StatusCode, deleteArtistResponse.ReasonPhrase);
            //}
        }

        private static void CreateArtist()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Country: ");
            string country = Console.ReadLine();
            Console.Write("Date of birth (yyyy-mm-dd): ");
            DateTime dateOfBirth = DateTime.ParseExact(Console.ReadLine(),
                "yyyy-mm-dd", CultureInfo.InvariantCulture);

            Artist artist = new Artist()
            {
                Name = name,
                Country = country,
                DateOfBirth = dateOfBirth
            };

            var postArtistResponse = jsonClient.PostAsJsonAsync("api/artists", artist).Result;
            if (postArtistResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)postArtistResponse.StatusCode, postArtistResponse.ReasonPhrase);
            }
        }

        private static void CreateAlbum()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Producer: ");
            string producer = Console.ReadLine();

            Album album = new Album()
            {
                Title = title,
                Year = year,
                Producer = producer
            };

            var postAlbumResponse = jsonClient.PostAsJsonAsync("api/albums", album).Result;
            if (postAlbumResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)postAlbumResponse.StatusCode, postAlbumResponse.ReasonPhrase);
            }
        }

        private static void CreateSong()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Genre: ");
            string genre = Console.ReadLine();
            Console.Write("AlbumId: ");
            int albumId = int.Parse(Console.ReadLine());
            Console.Write("ArtistId: ");
            int artistId = int.Parse(Console.ReadLine());

            Song song = new Song()
            {
                Title = title,
                Year = year,
                Genre = genre,
                AlbumId = albumId,
                ArtistId = artistId
            };

            var postSongResponse = jsonClient.PostAsJsonAsync("api/songs", song).Result;
            if (postSongResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)postSongResponse.StatusCode, postSongResponse.ReasonPhrase);
            }
        }

        private static void ReadArtists()
        {
            HttpResponseMessage getAllResponse = jsonClient.GetAsync("api/artists").Result;

            if (getAllResponse.IsSuccessStatusCode)
            {
                var artists = getAllResponse.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                foreach (var a in artists)
                {
                    Console.WriteLine("{0,4} {1,-10} {2} {3}", a.Id, a.Name, a.Country, a.DateOfBirth);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)getAllResponse.StatusCode, getAllResponse.ReasonPhrase);
            }
        }

        private static void ReadAlbums()
        {
            HttpResponseMessage getAllResponse = jsonClient.GetAsync("api/albums").Result;

            if (getAllResponse.IsSuccessStatusCode)
            {
                var albums = getAllResponse.Content.ReadAsAsync<IEnumerable<Album>>().Result;
                foreach (var a in albums)
                {
                    Console.WriteLine("{0,4} {1,-10} {2} {3}", a.Id, a.Title, a.Year, a.Producer);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)getAllResponse.StatusCode, getAllResponse.ReasonPhrase);
            }
        }

        private static void ReadSongs()
        {
            HttpResponseMessage getAllResponse = jsonClient.GetAsync("api/songs").Result;

            if (getAllResponse.IsSuccessStatusCode)
            {
                var songs = getAllResponse.Content.ReadAsAsync<IEnumerable<Song>>().Result;
                foreach (var s in songs)
                {
                    Console.WriteLine("{0,4} {1,-10} {2} {3} {4} {5}", 
                        s.Id, s.Title, s.Year, s.Genre, s.ArtistId, s.AlbumId);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)getAllResponse.StatusCode, getAllResponse.ReasonPhrase);
            }
        }

        private static void ReadArtistById()
        {
            Console.Write("Id to read: ");
            int idToRead = int.Parse(Console.ReadLine());

            HttpResponseMessage getByIdResponse = jsonClient.GetAsync("api/artists/" + idToRead).Result;
            if (getByIdResponse.IsSuccessStatusCode)
            {
                var artist = getByIdResponse.Content.ReadAsAsync<Artist>().Result;
                Console.WriteLine("{0,4} {1,-10} {2} {3}", artist.Id, artist.Name, artist.Country, artist.DateOfBirth);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)getByIdResponse.StatusCode, getByIdResponse.ReasonPhrase);
            }
        }

        private static void ReadAlbumById()
        {
            Console.Write("Id to read: ");
            int idToRead = int.Parse(Console.ReadLine());

            HttpResponseMessage getByIdResponse = jsonClient.GetAsync("api/albums/" + idToRead).Result;

            if (getByIdResponse.IsSuccessStatusCode)
            {
                var albums = getByIdResponse.Content.ReadAsAsync<IEnumerable<Album>>().Result;
                foreach (var a in albums)
                {
                    Console.WriteLine("{0,4} {1,-10} {2} {3}", a.Id, a.Title, a.Year, a.Producer);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)getByIdResponse.StatusCode, getByIdResponse.ReasonPhrase);
            }
        }

        private static void ReadSongsById()
        {
            Console.Write("Id to read: ");
            int idToRead = int.Parse(Console.ReadLine());

            HttpResponseMessage getByIdResponse = jsonClient.GetAsync("api/songs/" + idToRead).Result;

            if (getByIdResponse.IsSuccessStatusCode)
            {
                var songs = getByIdResponse.Content.ReadAsAsync<IEnumerable<Song>>().Result;
                foreach (var s in songs)
                {
                    Console.WriteLine("{0,4} {1,-10} {2} {3} {4} {5}",
                        s.Id, s.Title, s.Year, s.Genre, s.ArtistId, s.AlbumId);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)getByIdResponse.StatusCode, getByIdResponse.ReasonPhrase);
            }
        }

        private static void UpdateArtist()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Country: ");
            string country = Console.ReadLine();
            Console.Write("Date of birth (yyyy-mm-dd): ");
            DateTime dateOfBirth = DateTime.ParseExact(Console.ReadLine(),
                "yyyy-mm-dd", CultureInfo.InvariantCulture);

            Artist updatedArtist = new Artist()
            {
                Name = name,
                Country = country,
                DateOfBirth = dateOfBirth
            };
            Console.Write("Id to update: ");
            int idForUpdate = int.Parse(Console.ReadLine());

            var putArtistResponse = jsonClient.PutAsJsonAsync("api/artists/" + idForUpdate, updatedArtist).Result;
            if (putArtistResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist updated!");
            }
            else
            {
                Console.WriteLine("{0}, ({1})", (int)putArtistResponse.StatusCode, putArtistResponse.ReasonPhrase);
            }
        }

        private static void UpdateAlbum()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Producer: ");
            string producer = Console.ReadLine();

            Album updatedAlbum = new Album()
            {
                Title = title,
                Year = year,
                Producer = producer
            };

            Console.Write("Id to update: ");
            int idForUpdate = int.Parse(Console.ReadLine());

            var putAlbumResponse = jsonClient.PutAsJsonAsync("api/albums/" + idForUpdate, updatedAlbum).Result;
            if (putAlbumResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist updated!");
            }
            else
            {
                Console.WriteLine("{0}, ({1})", (int)putAlbumResponse.StatusCode, putAlbumResponse.ReasonPhrase);
            }
        }

        private static void UpdateSong()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Genre: ");
            string genre = Console.ReadLine();
            Console.Write("AlbumId: ");
            int albumId = int.Parse(Console.ReadLine());
            Console.Write("ArtistId: ");
            int artistId = int.Parse(Console.ReadLine());

            Song updatedSong = new Song()
            {
                Title = title,
                Year = year,
                Genre = genre,
                AlbumId = albumId,
                ArtistId = artistId
            };

            Console.Write("Id to update: ");
            int idForUpdate = int.Parse(Console.ReadLine());

            var putSongResponse = jsonClient.PutAsJsonAsync("api/songs/" + idForUpdate, updatedSong).Result;
            if (putSongResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Song updated!");
            }
            else
            {
                Console.WriteLine("{0}, ({1})", (int)putSongResponse.StatusCode, putSongResponse.ReasonPhrase);
            }
        }

        private static void DeleteArtist()
        {
            Console.Write("Id to delete: ");
            int idToDelete = int.Parse(Console.ReadLine());
            var deleteArtistResponse = jsonClient.DeleteAsync("api/artists/" + idToDelete).Result;
            if (deleteArtistResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist deleted!");
            }
            else
            {
                Console.WriteLine("{0}, ({1})", (int)deleteArtistResponse.StatusCode, deleteArtistResponse.ReasonPhrase);
            }
        }

        private static void DeleteAlbum()
        {
            Console.Write("Id to delete: ");
            int idToDelete = int.Parse(Console.ReadLine());

            var deleteAlbumResponse = jsonClient.DeleteAsync("api/albums/" + idToDelete).Result;
            if (deleteAlbumResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Album deleted!");
            }
            else
            {
                Console.WriteLine("{0}, ({1})", (int)deleteAlbumResponse.StatusCode, deleteAlbumResponse.ReasonPhrase);
            }
        }

        private static void DeleteSong()
        {
            Console.Write("Id to delete: ");
            int idToDelete = int.Parse(Console.ReadLine());

            var deleteSongResponse = jsonClient.DeleteAsync("api/songs/" + idToDelete).Result;
            if (deleteSongResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Song deleted!");
            }
            else
            {
                Console.WriteLine("{0}, ({1})", (int)deleteSongResponse.StatusCode, deleteSongResponse.ReasonPhrase);
            }
        }
    }
}
