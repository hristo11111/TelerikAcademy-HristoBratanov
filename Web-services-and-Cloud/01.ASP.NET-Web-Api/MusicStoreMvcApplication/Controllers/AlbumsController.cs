using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicStore_Model;
using MusicStoreMvcApplication.Models;

namespace MusicStoreMvcApplication.Controllers
{
    public class AlbumsController : ApiController
    {
        IRepository<Album> albumRepository;
        
        public AlbumsController(IRepository<Album> repository)
        {
            albumRepository = repository;
        }

        // GET api/albums
        public IEnumerable<AlbumModel> Get()
        {
            var albums = this.albumRepository.All();

            var albumModel =
                from entity in albums
                select new AlbumModel()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Year = entity.Year,
                    Producer = entity.Producer,
                    Songs = (from songEntity in entity.Songs
                             select new SongModel()
                             {
                                 Title = songEntity.Title
                             }),
                    Artists = (from artistEntity in entity.Artists
                               select new ArtistModel()
                               {
                                   Name = artistEntity.Name
                               })
                };

            return albumModel;
        }

        // GET api/albums/5
        public HttpResponseMessage Get(int id)
        {
            var albums = this.albumRepository.All().Where(x => x.Id == id);

            if (albums == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Album not found");
            }

            var albumModel =
                from entity in albums
                select new AlbumModel()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Year = entity.Year,
                    Producer = entity.Producer,
                    Songs = (from songEntity in entity.Songs
                             select new SongModel()
                             {
                                 Title = songEntity.Title
                             }),
                    Artists = (from artistEntity in entity.Artists
                               select new ArtistModel()
                               {
                                   Name = artistEntity.Name
                               })
                };

            return this.Request.CreateResponse(HttpStatusCode.OK, albumModel);
        }

        // POST api/albums
        public void Post([FromBody]Album album)
        {
            this.albumRepository.Add(album);
        }

        // PUT api/albums/5
        public void Put(int id, [FromBody]Album updatedAlbum)
        {
            var album = this.albumRepository.Get(id);
            if (updatedAlbum.Title != null)
            {
                album.Title = updatedAlbum.Title;
            }
            if (updatedAlbum.Year != null)
            {
                album.Year = updatedAlbum.Year;
            }
            if (updatedAlbum.Producer != null)
            {
                album.Producer = updatedAlbum.Producer;
            }

            this.albumRepository.Update(id, album);
        }

        // DELETE api/albums/5
        public void Delete(int id)
        {
            this.albumRepository.Delete(id);
        }
    }
}
