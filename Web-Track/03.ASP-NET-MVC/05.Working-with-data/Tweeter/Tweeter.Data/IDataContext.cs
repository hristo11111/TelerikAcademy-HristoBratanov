using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Tweeter.Models;

namespace Tweeter.Data
{
    interface IDataContext
    {
        IDbSet<Tweet> Tweets { get; set; }
        IDbSet<Tag> Tags { get; set; }
    }
}
