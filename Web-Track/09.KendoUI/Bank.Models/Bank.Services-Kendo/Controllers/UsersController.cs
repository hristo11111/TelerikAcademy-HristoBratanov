
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Bank.Data;
using Bank.Models;
using System.Web.Http.ValueProviders;
using Bank.Services_Kendo.Models;

namespace Bank.Services_Kendo.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int MinUserNameLength = 6;
        private const int MaxUserNameLength = 30;
        private const string ValidUserNameChars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890._";
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
                var context = new BankContext();

                using (context)
                {
                    this.ValidateUserName(model.UserName);
                    this.ValidateAuthCode(model.AuthCode);

                    var userNameToLower = model.UserName.ToLower();

                    var user = context.Users.FirstOrDefault(
                        usr => usr.UserName == userNameToLower);

                    if (user != null)
                    {
                        throw new InvalidOperationException("User exists!");
                    }

                    user = new User()
                    {
                        UserName = userNameToLower,
                        AuthCode = model.AuthCode
                    };

                    context.Users.Add(user);
                    context.SaveChanges();

                    user.SessionKey = this.GenerateSessionKey(user.UserId);
                    context.SaveChanges();

                    var loggedModel = new UserLoggedModel()
                    {
                        UserName = user.UserName,
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

                var context = new BankContext();
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
                        user.SessionKey = this.GenerateSessionKey(user.UserId);
                        context.SaveChanges();
                    }

                    var loggedModel = new UserLoggedModel()
                    {
                        UserName = user.UserName,
                        SessionKey = user.SessionKey
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created,
                        loggedModel);

                    return response;
                }
            });

            return responseMsg;
        }

        [ActionName("Withdraw")]
        public HttpResponseMessage PostWithdrawMoney(TransactionInOut transaction,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var context = new BankContext();
                using (context)
                {
                    User user = context.Users.Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();
                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid sessionkey");
                    }

                    var currentBalance = user.Balance - transaction.Amount;
                    user.Balance = currentBalance;

                    var newTransaction = new Transaction()
                    {
                        Type = transaction.Type,
                        Amount = transaction.Amount
                    };

                    user.Transactions.Add(newTransaction);

                    context.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.Created,
                        transaction);

                    return response;
                }
            });

            return responseMsg;
        }

        [ActionName("Deposit")]
        public HttpResponseMessage PostDepositMoney(TransactionInOut transaction,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var context = new BankContext();
                using (context)
                {
                    User user = context.Users.Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();
                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid sessionkey");
                    }

                    var currentBalance = user.Balance + transaction.Amount;
                    user.Balance = currentBalance;

                    var newTransaction = new Transaction()
                    {
                        Type = transaction.Type,
                        Amount = transaction.Amount
                    };

                    user.Transactions.Add(newTransaction);

                    context.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.Created,
                        transaction);

                    return response;
                }
            });

            return responseMsg;
        }


        [ActionName("Logout")]
        public HttpResponseMessage PutUserLogout(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                this.ValidateSessionKey(sessionKey);
                var context = new BankContext();
                using (context)
                {
                    var users = context.Users;
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

        [HttpGet]
        public UserDetailsModel GetUser(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var context = new BankContext();

                var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password");
                }

                var transactions =
                    (from t in user.Transactions
                     select new TransactionInOut()
                     {
                         Type = t.Type,
                         Amount = t.Amount
                     });

                var userDetailed = new UserDetailsModel()
                {
                    Balance = user.Balance,
                    UserName = user.UserName,
                    Transactions = transactions
                };

                return userDetailed;
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