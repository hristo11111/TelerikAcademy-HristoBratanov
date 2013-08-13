using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace FeedZillaArtSearch
{
    [DataContract]
    public class FZResult
    {
        [DataMember(Name = "articles")]
        public List<Article> Articles { get; set; }
    }
}
