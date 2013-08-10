using MusicStore_Model;
using MusicStoreMvcApplication.Controllers;
using MusicStoreMvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace MusicStoreMvcApplication.DependencyResolver
{
    public class DbDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(ArtistsController))
            {
                var repository = new DbRepository<Artist>();

                return new ArtistsController(repository);
            }
            if (serviceType == typeof(AlbumsController))
            {
                var repository = new DbRepository<Album>();

                return new AlbumsController(repository);
            }
            if (serviceType == typeof(SongsController))
            {
                var repository = new DbRepository<Song>();

                return new SongsController(repository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<Object>();
        }

        public void Dispose()
        {
        }
    }
}