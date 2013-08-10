using AspNetWebApiExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetWebApiExample.Controllers
{
    public class BlogPostsController : ApiController
    {
        private static IList<BlogPost> data = GetAll();

        private static IList<BlogPost> GetAll()
        {
            var data = new List<BlogPost>();
            data.Add(new BlogPost()
                {
                    Title = "post1",
                    Content = "post1 content"
                });
            data.Add(new BlogPost()
            {
                Title = "post2",
                Content = "post2 content"
            });
            data.Add(new BlogPost()
            {
                Title = "post2",
                Content = "post2 content"
            });

            return data;
        }

        // GET api/default1
        public IQueryable<BlogPost> Get()
        {
            return data.AsQueryable();
        }

        // GET api/default1/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/default1
        public void Post([FromBody]string value)
        {
        }

        // PUT api/default1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/default1/5
        public HttpResponseMessage Delete(int id)
        {
            if (id >= data.Count())
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
            }

            data.RemoveAt(id);
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
