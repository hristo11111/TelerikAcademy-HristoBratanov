using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogSystem.Client.Models;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlogSystem.Tests
{
    [TestClass]
    public class PostControllerTests
    {
        [TestMethod]
        public void CreatePost_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                UserName = "ValidUser",
                DisplayName = "ValidNick",
                AuthCode = new string('b', 40)
            };

            var httpServer = new InMemoryHttpServer("http://localhost/");
            var response = httpServer.CreatePostRequest("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<UserLoggedModel>(contentString);

            var testPost = new PostModel
            {
                Title = "NEW POST",
                Tags = new List<string>() { "post" },
                Text = "this is just a test post"
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;

            //var postResponse = httpServer.CreatePostRequest("api/posts", testPost, headers);

            //Assert.AreEqual(HttpStatusCode.Created, postResponse.StatusCode);
            //Assert.IsNotNull(postResponse.Content);

            //var contentString = response.Content.ReadAsStringAsync().Result;
            //var model = JsonConvert.DeserializeObject<CreatePostResponseModel>(contentString);
            //Assert.AreEqual(testPost.Title, model.Title);
            //Assert.IsNotNull(model.Id > 0);
        }
    }
}
