﻿using TeamSilver.DataLayer;
using TeamSilver.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using TeamSilver.WebAPI.Attributes;
using TeamSilver.WebApi.Models;

namespace TeamSilver.WebApi.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const string ValidUsernameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";
        private const string ValidDisplayNameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_. -";
        private const string SessionKeyChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
        private static readonly Random rand = new Random();
        private const int SessionKeyLength = 50;
        private const int Sha1Length = 40;

        public UsersController()
        {
        }

        /*
        {  "Username": "DonchoMinkov",
           "DisplayName": "Doncho Minkov",
           "AuthCode":   "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e" }
        */

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser([FromBody]UserModel userModel)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new StoreContext();
                    using (context)
                    {
                        this.ValidateUsername(userModel.Username);
                        this.ValidateAuthCode(userModel.Password);
                        var usernameToLower = userModel.Username.ToLower();
                        var user = context.Users.FirstOrDefault(
                            usr => usr.Username.ToLower() == usernameToLower);

                        if (user != null)
                        {
                            throw new InvalidOperationException("User exists");
                        }

                        user = new User()
                        {
                            Username = usernameToLower,
                            Password = userModel.Password,
                            Email = userModel.Email,
                            Role = userModel.Role,
                            FirstName = userModel.FirstName,
                            LastName = userModel.LastName,
                        };

                        context.Users.Add(user);
                        context.SaveChanges();

                        user.SessionKey = this.GenerateSessionKey(user.UserId);
                        context.SaveChanges();

                        var loggedModel = new LoggedUserModel()
                        {
                            DisplayName = user.FirstName + " " + user.LastName,
                            SessionKey = user.SessionKey,
                            Role = user.Role
                        };

                        var response =
                            this.Request.CreateResponse(HttpStatusCode.Created,
                            loggedModel);

                        return response;
                    }
                });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel userModel)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  var context = new StoreContext();
                  using (context)
                  {
                      this.ValidateUsername(userModel.Username);
                      this.ValidateAuthCode(userModel.Password);
                      var usernameToLower = userModel.Username.ToLower();
                      var user = context.Users.FirstOrDefault(
                          usr => usr.Username == usernameToLower
                          && usr.Password == userModel.Password);

                      if (user == null)
                      {
                          throw new InvalidOperationException("Invalid Username or password");
                      }
                      if (user.SessionKey == null)
                      {
                          user.SessionKey = this.GenerateSessionKey(user.UserId);
                          context.SaveChanges();
                      }

                      var loggedModel = new LoggedUserModel()
                      {
                          DisplayName = user.FirstName + " " + user.LastName,
                          SessionKey = user.SessionKey,
                          Role = user.Role
                      };

                      var response =
                          this.Request.CreateResponse(HttpStatusCode.Created,
                          loggedModel);

                      return response;
                  }
              });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new StoreContext();
                    using (context)
                    {
                        User user = UsersController.GetUserBySessionKey(sessionKey);

                        if (user == null)
                        {
                            throw new ArgumentException("There is no user with such sessionKey!");
                        }

                        context.Users.
                            FirstOrDefault(usr => usr.SessionKey == sessionKey).
                            SessionKey = null;
                        context.SaveChanges();

                        var response =
                          this.Request.CreateResponse(HttpStatusCode.OK);

                        return response;
                    }
                });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("all-users")]
        public IQueryable<UserModel> GetAllUsers(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new StoreContext();
            using (context)
            {
                var user = UsersController.GetUserBySessionKey(sessionKey);
                if (user == null)
                {
                    throw new ArgumentException("There is no user with such sessionKey!");
                }
                if (user.Role != "admin")
                {
                    throw new ArgumentException("You are not admin!");
                }

                var productsModels =
                    (from p in user.Products
                     select new ProductModel()
                     {
                         ProductId = p.ProductId,
                         ProductsName = p.ProductName
                     }).AsQueryable();

                var newUserModel =
                    (from usr in context.Users
                     select new UserModel()
                     {
                         Username = usr.Username,
                         FirstName = usr.FirstName,
                         LastName = usr.LastName,
                         Email = usr.Email,
                         SessionKey = usr.SessionKey,
                         Password = usr.Password,
                         Role = usr.Role,
                         //Products = productsModels
                     }).ToList();

                return newUserModel.AsQueryable();
            }
        }

        [HttpGet]
        [ActionName("my-products")]
        public IQueryable<ProductModel> GetAllProducts(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new StoreContext();
            using (context)
            {
                var user = UsersController.GetUserBySessionKey(sessionKey);
                if (user == null)
                {
                    throw new ArgumentException("There is no user with such sessionKey!");
                }

                var newProductModel =
                    (from product in user.Products
                     select new ProductModel()
                     {
                         ProductId = product.ProductId,
                         ProductsName = product.ProductName
                     }).ToList();

                return newProductModel.AsQueryable();
            }
        }

        public static User GetUserBySessionKey(string sessionKey)
        {
            var context = new StoreContext();

            var user = context.Users.Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();

            return user;
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder skeyBuilder = new StringBuilder(SessionKeyLength);
            skeyBuilder.Append(userId);
            while (skeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                skeyBuilder.Append(SessionKeyChars[index]);
            }
            return skeyBuilder.ToString();
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted");
            }
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be at least {0} characters long",
                    MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be less than {0} characters long",
                    MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits .,_");
            }
        }
    }
}
