using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo
{
    public class MenuItem
    {
        private string title;
        private string url;

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string Url
        {
            get { return this.url; }
            set { this.url = value; }
        }
    }
}