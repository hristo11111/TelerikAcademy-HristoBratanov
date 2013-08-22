using System;
using System.Net;
using System.Transactions;
using Forum.Client.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Forum.Tests
{
    [TestClass]
    public class ThreadsControllerIntegrationTests
    {
        static TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }
        
        //[TestMethod]
        //public void GetAll_WhenDataInDatabase_ShouldReturnData()
        //{
        //    var httpServer = new InMemoryHttpServer("http://localhost/");

        //    var response = httpServer.CreateGetRequest("api/threads");

        //}

        [TestMethod]
        public void Register_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                UserName = "ValidUser",
                NickName = "ValidNick",
                AuthCode = new string('b', 40)
            };

            var httpServer = new InMemoryHttpServer("http://localhost/");
            var response = httpServer.CreatePostRequest("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Content);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<UserLoggedModel>(contentString);
            Assert.AreEqual(testUser.NickName, model.Nickname);
            Assert.IsNotNull(model.SessionKey);
        }

        [TestMethod]
        public void Login_WhenLoggedModelValid_RetrunData()
        {
            var testUser = new UserModel()
            {
                UserName = "ValidUser",
                NickName = "ValidNick",
                AuthCode = new string('b', 40)
            };

            var testUserLogin = new UserModel()
            {
                UserName = "ValidUser",
                AuthCode = new string('b', 40)
            };

            var httpServer = new InMemoryHttpServer("http://localhost/");
            httpServer.CreatePostRequest("api/users/register", testUser);
            var response = httpServer.CreatePostRequest("api/users/login", testUserLogin);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Content);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<UserLoggedModel>(contentString);
            Assert.AreEqual(testUser.NickName, model.Nickname);
            Assert.IsNotNull(model.SessionKey);
        }
    }
}
