using System.Web.Http;
using BlogSystem.Client.Models;
using BlogSystem.Data;
using BlogSystem.Models;
using BlogSystem.Client.Controllers;
using BlogSystem.WebAPI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.ValueProviders;

namespace BlogSystem.Client.Controllers
{
    public class PostsController : BaseApiController
    {
        private const int SessionKeyLength = 50;
        private const string ValidSessionKeyChars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        [HttpGet]
        public IQueryable<PostModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var context = new BlogSystemContext();

                var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password");
                }

                var postEntities = context.Posts;
                var models =
                    (from postEntity in postEntities
                     select new PostModel()
                     {
                         Id = postEntity.Id,
                         Title = postEntity.Title,
                         PostedBy = postEntity.User.DisplayName,
                         PostDate = postEntity.DatePosted,
                         Text = postEntity.Text,
                         Tags = (from tagEntity in postEntity.Tags
                                       select tagEntity.Name),
                         Comments = (from commentEntity in postEntity.Comments
                                  select new CommentModel()
                                  {
                                      Text = commentEntity.Text,
                                      CommentedBy = commentEntity.User.DisplayName,
                                      PostDate = commentEntity.DateCommented
                                  }),
                     });

                return models.OrderByDescending(post => post.PostDate);
            });

            return responseMsg;
        }

        public IQueryable<PostModel> GetPage(int page, int count,
           [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var models = this.GetAll(sessionKey)
                    .Skip(page * count)
                    .Take(count);

                return models.OrderByDescending(post => post.PostDate);
            });

            return responseMsg;
        }

        [ActionName("Create")]
        public HttpResponseMessage PostCreatePost(PostModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                this.ValidateSessionKey(sessionKey);

                if (model == null)
                {
                    throw new InvalidOperationException("Model cannot be null");
                }

                var context = new BlogSystemContext();
                using (context)
                {
                    User user = context.Users.Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();
                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid sessionkey");
                    }

                    var titleTags = model.Title.Split(
                        new char[] { '.', ',', ';', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var newTags = new HashSet<Tag>();
                    foreach (var tagName in titleTags)
                    {
                        Tag newtag = new Tag()
                        {
                            Name = tagName.ToLower()
                        };

                        if (!newTags.Contains(newtag))
                        {
                            newTags.Add(newtag);
                        }
                    }

                    foreach (var tagName in model.Tags)
                    {
                        Tag newtag = new Tag()
                        {
                            Name = tagName.ToLower()
                        };

                        if (!newTags.Contains(newtag))
                        {
                            newTags.Add(newtag);
                        }
                    }

                    var newDbTags = new HashSet<Tag>();
                    foreach (var tag in newTags)
                    {
                        var tagDb = context.Tags.FirstOrDefault(tg => tg.Name == tag.Name);
                        if (tagDb == null)
                        {
                            newDbTags.Add(tag);
                        }
                        else
                        {
                            newDbTags.Add(tagDb);
                        }
                    }

                    var post = new Post()
                    {
                        Title = model.Title,
                        Text = model.Text,
                        DatePosted = DateTime.Now,
                        User = user,
                        Tags = newDbTags
                    };

                    user.Posts.Add(post);
                    context.SaveChanges();

                    var responseModel = new CreatePostResponseModel()
                    {
                        Title = post.Title,
                        Id = post.Id
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, responseModel);

                    return response;
                }
            });

            return responseMsg;
        }

        public IQueryable<PostModel> GetSearchPosts(string keyword,
           [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var models = this.GetAll(sessionKey).Where(p => p.Title.Contains(keyword));

                return models.OrderByDescending(post => post.PostDate);
            });

            return responseMsg;
        }

        public IQueryable<PostModel> GetSearchPostsByTags(string tags,
           [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                this.ValidateSessionKey(sessionKey);

                string[] tagsSeparated = tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var models = this.GetAll(sessionKey).Where(x => x.Tags.Intersect(tagsSeparated).Count() == tagsSeparated.Count());

                return models.OrderByDescending(post => post.PostDate);
            });

            return responseMsg;
        }

        [HttpPut, ActionName("comment")]
        public HttpResponseMessage PutCommentPost(int id, [FromBody]CommentModelSimple comment,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                this.ValidateSessionKey(sessionKey);
                var context = new BlogSystemContext();
                using (context)
                {
                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username or password");
                    }

                    var post = context.Posts.FirstOrDefault(p => p.Id == id);

                    post.Comments.Add(new Comment()
                    {
                        Text = comment.Text,
                        DateCommented = DateTime.Now,
                        User = user
                    });

                    context.SaveChanges();
                    
                    var response = this.Request.CreateResponse(HttpStatusCode.OK);

                    return response;
                }
            });

            return responseMsg;
        }

        private void ValidateSessionKey(string sessionKey)
        {
            if (sessionKey.Length != SessionKeyLength || sessionKey.Any(ch => !ValidSessionKeyChars.Contains(ch)))
            {
                throw new InvalidOperationException("Invalid session key");
            }
        }
    }
}
