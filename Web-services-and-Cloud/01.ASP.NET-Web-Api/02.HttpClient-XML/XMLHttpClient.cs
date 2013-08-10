using MusicStore_Model;
using MusicStoreMvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _02.HttpClient_XML
{
    public static class XMLHttpClient
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

        static void Main()
        {
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

                var postArtistResponse = xmlClient.PostAsJsonAsync("api/artists", artist).Result;
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

                var postSongResponse = xmlClient.PostAsJsonAsync("api/songs", song).Result;
                if (postSongResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song added!");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)postSongResponse.StatusCode, postSongResponse.ReasonPhrase);
                }
            }

            private static void RemoveArtist()
            {
                Console.Write("Id to delete: ");
                int artistId = int.Parse(Console.ReadLine());

                var deleteArtistResponse = xmlClient.DeleteAsync("api/artists/" + artistId).Result;
                if (deleteArtistResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Artist deleted!");
                }
                else
                {
                    Console.WriteLine("{0}, ({1})", (int)deleteArtistResponse.StatusCode, deleteArtistResponse.ReasonPhrase);
                }
            }

            private static void RemoveAlbum()
            {
                Console.Write("Id to delete: ");
                int albumId = int.Parse(Console.ReadLine());

                var deleteAlbumResponse = xmlClient.DeleteAsync("api/albums/" + albumId).Result;
                if (deleteAlbumResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Album deleted!");
                }
                else
                {
                    Console.WriteLine("{0}, ({1})", (int)deleteAlbumResponse.StatusCode, deleteAlbumResponse.ReasonPhrase);
                }
            }

            private static void RemoveSong()
            {
                Console.Write("Id to delete: ");
                int removeId = int.Parse(Console.ReadLine());

                var deleteSongResponse = xmlClient.DeleteAsync("api/songs/" + removeId).Result;
                if (deleteSongResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song deleted!");
                }
                else
                {
                    Console.WriteLine("{0}, ({1})", (int)deleteSongResponse.StatusCode, deleteSongResponse.ReasonPhrase);
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

                var putArtistResponse = xmlClient.PutAsJsonAsync("api/artists/" + idForUpdate, updatedArtist).Result;
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

                var putAlbumResponse = xmlClient.PutAsJsonAsync("api/albums/" + idForUpdate, updatedAlbum).Result;
                if (putAlbumResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Artist updated!");
                }
                else
                {
                    Console.WriteLine("{0}, ({1})", (int)putAlbumResponse.StatusCode, putAlbumResponse.ReasonPhrase);
                }
            }

            static void UpdateSong()
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

                var putSongResponse = xmlClient.PutAsJsonAsync("api/songs/" + idForUpdate, updatedSong).Result;
                if (putSongResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song updated!");
                }
                else
                {
                    Console.WriteLine("{0}, ({1})", (int)putSongResponse.StatusCode, putSongResponse.ReasonPhrase);
                }
            }

            static void DeleteArtist()
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

            static void DeleteAlbum()
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

            static void DeleteSong()
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
    }

