using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Client.Models
{
    public class UserLoggedModel
    {
        public string Nickname { get; set; }

        public string SessionKey { get; set; }
    }
}