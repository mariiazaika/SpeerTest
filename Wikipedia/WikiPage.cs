using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wikipedia
{
    internal class WikiPage
    {
        public string Link { get; set; }   
        public string Url { get; set; } 

        public WikiPage(string link, string url)
        {
            Link = link;
            Url = url;
        }
        public bool IsVisible() { return Link != null && Url != null; }    

    }
}
