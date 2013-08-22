using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogSystem.Client.Models;
using System.Net;
using Newtonsoft.Json;

namespace BlogSystem.Tests
{
    [TestClass]
    public class UserControllerTests
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

        [TestMethod]
        public void Register_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                UserName = "ValidUser1",
                DisplayName = "ValidNick1",
                AuthCode = new string('a', 40)
            };

            var httpServer = new InMemoryHttpServer("http://localhost/");
            var response = httpServer.CreatePostRequest("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Content);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<UserLoggedModel>(contentString);
            Assert.AreEqual(testUser.DisplayName, model.DisplayName);
            Assert.IsNotNull(model.SessionKey);
        }
    }
}
