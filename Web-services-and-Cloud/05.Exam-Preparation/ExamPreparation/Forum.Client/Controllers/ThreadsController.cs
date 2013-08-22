using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.ValueProviders;
using System.Web.Mvc;
using Forum.Client.Attributes;
using Forum.Client.Models;
using Forum.Data;
using Forum.Models;

namespace Forum.Client.Controllers
{
    public class ThreadsController : BaseApiController
    {
        //Improvising - Could me ThreadModel instead
        [ActionName("Create")]
        public HttpResponseMessage PostCreateThread(ThreadModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                if (model == null)
                {
                    throw new InvalidOperationException("Thread cannot be null");
                }

                var context = new ForumContext();
                using (context)
                {
                    User user = context.Users.Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();
                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid sessionkey");
                    }

                    var thread = new Thread()
                    {
                        Title = model.Title,
                        DateCreated = model.DateCreated,
                        Content = model.Content
                    };

                    user.Threads.Add(thread);
                    context.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, model);

                    return response;
                }
            });

            return responseMsg;
        }

        public IQueryable<ThreadModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumContext();

                var user = context.Users.FirstOrDefault(
                    usr => usr.SessionKey == sessionKey);

                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password");
                }

                var threadEntities = context.Threads;

                var models = 
                    (from entityEntry in threadEntities
                    select new ThreadModel()
                    {
                        Id = entityEntry.Id,
                        Title = entityEntry.Title,
                        DateCreated = entityEntry.DateCreated,
                        Content = entityEntry.Content,
                        Categories = (from categoryEntry in entityEntry.Categories
                                      select categoryEntry.Name),
                        Posts = (from postEntry in entityEntry.Posts
                                 select new PostModel()
                                 {
                                    Content = postEntry.Content,
                                    PostDate = postEntry.DatePosted,
                                    PostedBy = postEntry.PostedBy.NickName
                                 })
                    });

                return models.OrderByDescending(thr => thr.DateCreated);
            });

            return responseMsg;
        }

        public IQueryable<ThreadModel> GetThreadsByCategory(string category, 
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var threads = this.GetAll(sessionKey).Where(thr => thr.Categories.Any(cat => cat == category));

                return threads;
            });

            return responseMsg;
        }

        public IQueryable<ThreadModel> GetThreadsByPageAndCount(int page, int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var threads = this.GetAll(sessionKey)
                    .Skip((page - 1) * count)
                    .Take(count);

                return threads;
            });

            return responseMsg;
        }

        [ActionName("Posts")]
        public IQueryable<PostModel> GetPostsInThread(int threadId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumContext();

                var posts = context.Threads.FirstOrDefault(thr => thr.Id == threadId).Posts;

                var postModels =
                    from post in posts
                    select new PostModel()
                    {
                        PostDate = post.DatePosted,
                        Content = post.Content,
                        PostedBy = post.PostedBy.NickName
                    };

                return postModels.AsQueryable();
            });

            return responseMsg;
        }
    }
}
