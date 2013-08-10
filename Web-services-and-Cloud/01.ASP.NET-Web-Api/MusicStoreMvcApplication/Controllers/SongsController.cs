using MusicStore_Model;
using MusicStoreMvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicStoreMvcApplication.Controllers
{
    public class SongsController : ApiController
    {
        IRepository<Song> SongsRepository;

        public SongsController(IRepository<Song> repository)
        {
            SongsRepository = repository;
        }

        // GET api/songs
        public IEnumerable<SongModel> Get()
        {
            var songs = this.SongsRepository.All();

            var songModel =
                from songEntity in songs
                select new SongModel()
                {
                    Title = songEntity.Title,
                    Id = songEntity.Id,
                    Year = songEntity.Year,
                    ArtistId = songEntity.ArtistId,
                    Genre = songEntity.Genre,
                    AlbumId = songEntity.AlbumId,
                    SongArtist = songEntity.Artist.Name
                };

            return songModel;
        }

        // GET api/songs/5
        public HttpResponseMessage Get(int id)
        {
            var songs = this.SongsRepository.All().Where(s => s.Id == id);

            if (songs == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Song not found!");
            }

            var songModel =
                from songEntity in songs
                select new SongModel()
                {
                    Title = songEntity.Title,
                    Id = songEntity.Id,
                    Year = songEntity.Year,
                    ArtistId = songEntity.ArtistId,
                    Genre = songEntity.Genre,
                    AlbumId = songEntity.AlbumId,
                    SongArtist = songEntity.Artist.Name,
                    AlbumTitle = songEntity.Album.Title
                };

            return this.Request.CreateResponse(HttpStatusCode.OK, songModel);
        }

        // POST api/songs
        public void Post([FromBody]Song value)
        {
            this.SongsRepository.Add(value);
        }

        // PUT api/songs/5
        public void Put(int id, [FromBody]Song updatedSong)
        {
            var song = this.SongsRepository.Get(id);

            if (updatedSong.Title != null)
            {
                song.Title = updatedSong.Title;
            }
            if (updatedSong.Year != null)
            {
                song.Year = updatedSong.Year;
            }
            if (updatedSong.Genre != null)
            {
                song.Genre = updatedSong.Genre;
            }
            if (updatedSong.ArtistId != null)
            {
                song.ArtistId = updatedSong.ArtistId;
            }
            if (updatedSong.AlbumId != null)
            {
                song.AlbumId = updatedSong.AlbumId;
            }

            this.SongsRepository.Update(id, song);
        }

        // DELETE api/songs/5
        public void Delete(int id)
        {
            this.SongsRepository.Delete(id);
        }
    }
}
