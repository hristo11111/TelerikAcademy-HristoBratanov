using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bank.Models;

namespace Bank.Services_Kendo.Models
{
    public class UserDetailsModel
    {
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public IEnumerable<TransactionInOut> Transactions { get; set; }
    }
}