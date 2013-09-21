using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    [DataContract]
    public class Transaction
    {
        [DataMember(Name = "transactionId")]
        public int TransactionId { get; set; }
        [DataMember(Name = "user")]
        public virtual User User { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }
    }
}
