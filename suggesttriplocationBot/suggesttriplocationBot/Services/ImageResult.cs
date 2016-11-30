using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suggesttriplocationBot.Services
{
    //TODO: Change model for suggestion result
    public class ImageResult
    {
        public string HostPageDisplayUrl { get; set; }

        public string HostPageUrl { get; set; }

        public string Name { get; set; }

        public string ThumbnailUrl { get; set; }

        public string WebSearchUrl { get; set; }
    }
}