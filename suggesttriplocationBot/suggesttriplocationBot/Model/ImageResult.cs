﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suggesttriplocationBot.Model
{
    public class ImageResult
    {
        public string suggestedText { get; set; }
        public List<SimilarImage> similarImages { get; set; }
    }

    public class SimilarImage
    {
        public string HostPageDisplayUrl { get; set; }

        public string HostPageUrl { get; set; }

        public string Name { get; set; }

        public string ThumbnailUrl { get; set; }

        public string WebSearchUrl { get; set; }

    }
}