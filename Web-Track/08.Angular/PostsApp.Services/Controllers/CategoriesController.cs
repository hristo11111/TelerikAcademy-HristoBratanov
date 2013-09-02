using PostsApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PostsApp.Services.Controllers
{
    public class CategoriesController : ApiController
    {
        private List<Category> Categories { get; set; }
        static Random rand = new Random();

        public CategoriesController()
        {
            this.Categories = new List<Category>();
            for (int i = 1; i < 8; i++)
            {
                Category category = new Category();
                category.Id = i;
                category.Name = "Category #" + i;

                List<Post> posts = new List<Post>();
                for (int j = 0; j < 4; j++)
                {
                    Post post = new Post();
                    post.Id = j + 1;
                    post.Title = "Post #" + i + "." + j;
                    post.Content = "Content for post with id=" + (j + 1);
                    post.DateCreated = DateTime.Now;

                    posts.Add(post);
                }

                category.Posts = posts;
                this.Categories.Add(category);
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return this.Categories;
        }

        public IEnumerable<Post> GetById(int id)
        {
            var posts = this.Categories.FirstOrDefault(cat => cat.Id == id);

            return posts.Posts;
        }
    }
}