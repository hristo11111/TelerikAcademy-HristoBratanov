using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedZillaArtSearch
{
    public class Article
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }
        public string Source { get; set; }
    }
}
