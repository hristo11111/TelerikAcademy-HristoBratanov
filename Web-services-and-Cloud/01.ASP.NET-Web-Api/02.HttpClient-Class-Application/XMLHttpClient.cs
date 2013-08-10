using MusicStore_Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

static class XMLHttpClient
{
    static HttpClient xmlClient = SetXmlClient();

    private static HttpClient SetXmlClient()
    {
        var xmlClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5718/")
        };

        xmlClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

        return xmlClient;
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

    //Post method
    //Artist newArtist = new Artist()
    //{
    //    Name = "Gosho",
    //    Country = "Sweden",
    //    DateOfBirth = new DateTime(1966, 06, 06)
    //};

    //var postArtistResponse = xmlClient.PostAsXmlAsync("api/artists", newArtist).Result;

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

    //int idForUpdate = 16;

    //var putArtistResponse = xmlClient.PutAsXmlAsync("api/artists/" + idForUpdate, updatedArtist).Result;

    //if (putArtistResponse.IsSuccessStatusCode)
    //{
    //    Console.WriteLine("Artist updated!");
    //}
    //else
    //{
    //    Console.WriteLine("{0}, ({1})", (int)putArtistResponse.StatusCode, putArtistResponse.ReasonPhrase);
    //}

    ////Delete method
    //int idToDelete = 17;

    //var deleteArtistResponse = xmlClient.DeleteAsync("api/artists/" + idToDelete).Result;

    //if (deleteArtistResponse.IsSuccessStatusCode)
    //{
    //    Console.WriteLine("Artist deleted!");
    //}
    //else
    //{
    //    Console.WriteLine("{0}, ({1})", (int)deleteArtistResponse.StatusCode, deleteArtistResponse.ReasonPhrase);
    //}

    public static void CreateArtist()
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

        var postArtistResponse = xmlClient.PostAsXmlAsync("api/artists", artist).Result;
        if (postArtistResponse.IsSuccessStatusCode)
        {
            Console.WriteLine("Artist added!");
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)postArtistResponse.StatusCode, postArtistResponse.ReasonPhrase);
        }
    }

    public static void CreateAlbum()
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

        var postAlbumResponse = xmlClient.PostAsXmlAsync("api/albums", album).Result;
        if (postAlbumResponse.IsSuccessStatusCode)
        {
            Console.WriteLine("Album added!");
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)postAlbumResponse.StatusCode, postAlbumResponse.ReasonPhrase);
        }
    }

    public static void CreateSong()
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

        var postSongResponse = xmlClient.PostAsXmlAsync("api/songs", song).Result;
        if (postSongResponse.IsSuccessStatusCode)
        {
            Console.WriteLine("Song added!");
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)postSongResponse.StatusCode, postSongResponse.ReasonPhrase);
        }
    }

    //READ DOES NOT WORK FOR XML
    public static void ReadArtists()
    {
        HttpResponseMessage getAllResponse = xmlClient.GetAsync("api/artists").Result;

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

    public static void ReadAlbums()
    {
        HttpResponseMessage getAllResponse = xmlClient.GetAsync("api/albums").Result;

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

    public static void ReadSongs()
    {
        HttpResponseMessage getAllResponse = xmlClient.GetAsync("api/songs").Result;

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

    public static void ReadArtistById()
    {
        Console.Write("Id to read: ");
        int idToRead = int.Parse(Console.ReadLine());

        HttpResponseMessage getByIdResponse = xmlClient.GetAsync("api/artists/" + idToRead).Result;
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

    public static void ReadAlbumById()
    {
        Console.Write("Id to read: ");
        int idToRead = int.Parse(Console.ReadLine());

        HttpResponseMessage getByIdResponse = xmlClient.GetAsync("api/albums/" + idToRead).Result;

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

    public static void ReadSongsById()
    {
        Console.Write("Id to read: ");
        int idToRead = int.Parse(Console.ReadLine());

        HttpResponseMessage getByIdResponse = xmlClient.GetAsync("api/songs/" + idToRead).Result;

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

    public static void UpdateArtist()
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

        var putArtistResponse = xmlClient.PutAsXmlAsync("api/artists/" + idForUpdate, updatedArtist).Result;
        if (putArtistResponse.IsSuccessStatusCode)
        {
            Console.WriteLine("Artist updated!");
        }
        else
        {
            Console.WriteLine("{0}, ({1})", (int)putArtistResponse.StatusCode, putArtistResponse.ReasonPhrase);
        }
    }

    public static void UpdateAlbum()
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

        var putAlbumResponse = xmlClient.PutAsXmlAsync("api/albums/" + idForUpdate, updatedAlbum).Result;
        if (putAlbumResponse.IsSuccessStatusCode)
        {
            Console.WriteLine("Artist updated!");
        }
        else
        {
            Console.WriteLine("{0}, ({1})", (int)putAlbumResponse.StatusCode, putAlbumResponse.ReasonPhrase);
        }
    }

    public static void UpdateSong()
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

        var putSongResponse = xmlClient.PutAsXmlAsync("api/songs/" + idForUpdate, updatedSong).Result;
        if (putSongResponse.IsSuccessStatusCode)
        {
            Console.WriteLine("Song updated!");
        }
        else
        {
            Console.WriteLine("{0}, ({1})", (int)putSongResponse.StatusCode, putSongResponse.ReasonPhrase);
        }
    }

    public static void DeleteArtist()
    {
        Console.Write("Id to delete: ");
        int idToDelete = int.Parse(Console.ReadLine());
        var deleteArtistResponse = xmlClient.DeleteAsync("api/artists/" + idToDelete).Result;
        if (deleteArtistResponse.IsSuccessStatusCode)
        {
            Console.WriteLine("Artist deleted!");
        }
        else
        {
            Console.WriteLine("{0}, ({1})", (int)deleteArtistResponse.StatusCode, deleteArtistResponse.ReasonPhrase);
        }
    }

    public static void DeleteAlbum()
    {
        Console.Write("Id to delete: ");
        int idToDelete = int.Parse(Console.ReadLine());

        var deleteAlbumResponse = xmlClient.DeleteAsync("api/albums/" + idToDelete).Result;
        if (deleteAlbumResponse.IsSuccessStatusCode)
        {
            Console.WriteLine("Album deleted!");
        }
        else
        {
            Console.WriteLine("{0}, ({1})", (int)deleteAlbumResponse.StatusCode, deleteAlbumResponse.ReasonPhrase);
        }
    }

    public static void DeleteSong()
    {
        Console.Write("Id to delete: ");
        int idToDelete = int.Parse(Console.ReadLine());

        var deleteSongResponse = xmlClient.DeleteAsync("api/songs/" + idToDelete).Result;
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
