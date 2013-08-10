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
    public class ArtistsController : ApiController
    {
        IRepository<Artist> artistRepository;

        public ArtistsController(IRepository<Artist> repository)
        {
            artistRepository = repository; 
        }

        public IEnumerable<ArtistModel> Get()
        {
            var artists = this.artistRepository.All();

            var artistModel =
                from entity in artists
                select new ArtistModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Country = entity.Country,
                    DateOfBirth = entity.DateOfBirth,
                    Songs = (from songEntity in entity.Songs
                             select new SongModel()
                             {
                                 Title = songEntity.Title
                             })
                };

            return artistModel;
        }

        // GET api/artists/5
        public HttpResponseMessage Get(int id)
        {
            var artists = this.artistRepository.All().Where(a => a.Id == id);

            if (artists == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Artist not found!");
            }

            var artistModel =
                from entity in artists
                select new ArtistModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Country = entity.Country,
                    DateOfBirth = entity.DateOfBirth,
                    Songs = (from songEntity in entity.Songs
                             select new SongModel()
                             {
                                 Title = songEntity.Title
                             }),
                    Albums = (from albumEntity in entity.Albums
                              select new AlbumModel()
                              {
                                  Title = albumEntity.Title
                              })
                };


            return this.Request.CreateResponse(HttpStatusCode.OK, artistModel);
        }

        // POST api/artists
        public void Post([FromBody]Artist artist)
        {
            this.artistRepository.Add(artist);
        }

        // PUT api/artists/5
        public void Put(int id, [FromBody]Artist updatedArtist)
        {
            var artist = this.artistRepository.Get(id);

            if (artist.Name != null)
            {
                artist.Name = updatedArtist.Name;
            }
            if (artist.Country != null)
            {
                artist.Country = updatedArtist.Country;
            }
            if (artist.DateOfBirth != null)
            {
                artist.DateOfBirth = updatedArtist.DateOfBirth;
            }

            this.artistRepository.Update(id, artist);
        }

        // DELETE api/artists/5
        public void Delete(int id)
        {
            this.artistRepository.Delete(id);
        }
    }
}
