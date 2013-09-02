
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
    public class TransactionsController : BaseApiController
    {
        private const string ValidSessionKeyChars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private const int SessionKeyLength = 50;

        [HttpGet]
        public IQueryable<TransactionInOut> GetTransactions(
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
                    (from t in context.Transactions
                     select new TransactionInOut()
                     {
                         Type = t.Type,
                         Amount = t.Amount
                     });


                return transactions;
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