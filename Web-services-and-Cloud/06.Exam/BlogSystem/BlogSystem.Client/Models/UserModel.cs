using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Client.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string AuthCode { get; set; }
    }
}