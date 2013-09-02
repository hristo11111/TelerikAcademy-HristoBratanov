using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "userId")]
        public int UserId { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "userName")]
        public string UserName { get; set; }
        [DataMember(Name = "authCode")]
        public string AuthCode { get; set; }
        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }
        [DataMember(Name = "balance")]
        public Decimal Balance { get; set; }

        [DataMember(Name = "transactions")]
        public virtual ICollection<Transaction> Transactions { get; set; }

        public User()
        {
            this.Transactions = new HashSet<Transaction>();
        }

    }
}
