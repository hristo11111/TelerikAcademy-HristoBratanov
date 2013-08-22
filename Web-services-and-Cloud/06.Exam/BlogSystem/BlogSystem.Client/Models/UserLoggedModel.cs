using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Client.Models
{
    public class UserLoggedModel
    {
        public string DisplayName { get; set; }
        public string SessionKey { get; set; }
    }
}