using BlogSystem.Client.Models;
using BlogSystem.Data;
using BlogSystem.Client.Controllers;
using BlogSystem.WebAPI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ValueProviders;
using System.Web.Mvc;

namespace BlogSystem.Client.Controllers
{
    public class TagsController : BaseApiController
    {
        private const int SessionKeyLength = 50;
        private const string ValidSessionKeyChars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        public IQueryable<IEnumerable<TagModel>> GetAll(
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
                var postsModels =
                    (from postEntity in postEntities
                     select new PostTagsModel()
                     {
                         Tags =
                         (from tagEntity in postEntity.Tags
                          select new TagModel()
                          {
                              Id = postEntity.Id,
                              Name = tagEntity.Name,
                              Posts = tagEntity.Posts.Count
                          })
                     });

                var tagModels = postsModels.Select(p => p.Tags);

                return tagModels;
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
