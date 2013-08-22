using Forum.Client.Models;
using Forum.Data;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Forum.Client.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int MinUserNameLength = 6;
        private const int MaxUserNameLength = 30;
        private const int MinNickNameLength = 4;
        private const int MaxNickNameLength= 30;
        private const string ValidUserNameChars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890._";
        private const string ValidNickNameChars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_. -";
        private const string ValidSessionKeyChars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private static readonly Random rand = new Random();
        private const int Sha1Length = 40;
        private const int SessionKeyLength = 50;

        [ActionName("Register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {

                    var context = new ForumContext();

                    using (context)
                    {
                        this.ValidateUserName(model.UserName);
                        this.ValidateNickName(model.NickName);
                        this.ValidateAuthCode(model.AuthCode);

                        var userNameToLower = model.UserName.ToLower();
                        var nickNameToLower = model.NickName.ToLower();

                        var user = context.Users.FirstOrDefault(
                            usr => usr.UserName == userNameToLower &&
                                usr.NickName == usr.NickName);

                        if (user != null)
                        {
                            throw new InvalidOperationException("User exists!");
                        }

                        user = new User()
                        {
                            UserName = userNameToLower,
                            NickName = model.NickName,
                            AuthCode = model.AuthCode
                        };

                        context.Users.Add(user);
                        context.SaveChanges();

                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();

                        var loggedModel = new UserLoggedModel()
                        {
                            Nickname = user.NickName,
                            SessionKey = user.SessionKey
                        };

                        var response = this.Request.CreateResponse(HttpStatusCode.Created,
                            loggedModel);

                        return response;
                    }
                });

            return responseMsg;
            }

        [ActionName("Login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {

                    this.ValidateUserName(model.UserName);
                    this.ValidateAuthCode(model.AuthCode);
                    var userNameToLower = model.UserName.ToLower();

                    var context = new ForumContext();
                    using (context)
                    {
                        var user = context.Users.FirstOrDefault(
                            usr => usr.UserName == userNameToLower &&
                                usr.AuthCode == model.AuthCode);
                        if (user == null)
                        {
                            throw new InvalidOperationException("Invalid username or password");
                        }
                        if (user.SessionKey == null)
                        {
                            user.SessionKey = this.GenerateSessionKey(user.Id);
                            context.SaveChanges();
                        }

                        var loggedModel = new UserLoggedModel()
                        {
                            Nickname = user.NickName,
                            SessionKey = user.SessionKey
                        };

                        var response = this.Request.CreateResponse(HttpStatusCode.Created,
                            loggedModel);

                        return response;
                    }
                });

            return responseMsg;
        }

        [ActionName("Logout")]
        public HttpResponseMessage PutUserLogout(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    this.ValidateSessionKey(sessionKey);
                    var context = new ForumContext();
                    using (context)
                    {
                        var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                        if (user == null)
                        {
                            throw new InvalidOperationException("Invalid user authentication");
                        }
                        user.SessionKey = null;
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

        private string GenerateSessionKey(int userId)
        {
            StringBuilder skeyBuilder = new StringBuilder(SessionKeyLength);
            skeyBuilder.Append(userId);
            while (skeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(ValidSessionKeyChars.Length);
                skeyBuilder.Append(ValidSessionKeyChars[index]);
            }
            return skeyBuilder.ToString();
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Count() != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted!");
            }
        }

        private void ValidateNickName(string nickname)
        {
            if (nickname == null)
            {
                throw new ArgumentNullException("NickName cannot be null!");
            }
            if (nickname.Count() < MinNickNameLength)
            {
                throw new ArgumentOutOfRangeException(string.Format(
                    "NickName must be at last {0} characters long", MinNickNameLength));
            }
            if (nickname.Count() > MaxNickNameLength)
            {
                throw new ArgumentOutOfRangeException(string.Format(
                    "NickName cannot be more that {0} characters long", MaxNickNameLength));
            }
            if (nickname.Any(ch => !ValidNickNameChars.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(string.Format(
                    "NickName must contain letters, digits, intervals, . and _"));
            }
        }
  
        private void ValidateUserName(string userName)
        {
            if (userName == null)
            {
                throw new ArgumentNullException("UserName cannot be null!");
            }
            if (userName.Count() < MinUserNameLength)
            {
                throw new ArgumentOutOfRangeException(string.Format(
                    "UserName must be at last {0} characters long!", MinUserNameLength));
            }
            if (userName.Count() > MaxUserNameLength)
            {
                throw new ArgumentOutOfRangeException(string.Format(
                    "UserName cannot be more than {0} characters long!", MaxUserNameLength));
            }
            if (userName.Any(ch => !ValidUserNameChars.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(string.Format(
                    "UserName must contain only letters, digits, . and _"));
            }
        }
    }
}