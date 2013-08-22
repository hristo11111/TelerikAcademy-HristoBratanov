using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Client.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string AuthCode { get; set; }
    }
}