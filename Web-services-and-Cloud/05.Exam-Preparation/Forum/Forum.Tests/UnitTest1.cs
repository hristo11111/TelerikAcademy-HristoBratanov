using System;
using System.Transactions;
using Forum.WebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Newtonsoft.Json;

namespace Forum.Tests
{
    [TestClass]
    public class ThreadsControllerIntegrationTests
    {
        [TestMethod]
        public void GetAll_WhenDataInDatabase_ShouldReturnData()
        {
            var httpServer = new InMemoryHttpServer("http://localhost/");

            var response = httpServer.CreateGetRequest("api/threads");

            //Assert
        }

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
                 Username = "VALIDUSER",
                 Nickname = "VALIDNICK",
                 AuthCode = new string('b', 40)
             };
            var httpServer = new InMemoryHttpServer("http://localhost/");
            var response = httpServer.CreatePostRequest("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Content);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);
            Assert.AreEqual(testUser.Nickname, model.Nickname);
            Assert.IsNotNull(model.SessionKey);
        }
    }
}
