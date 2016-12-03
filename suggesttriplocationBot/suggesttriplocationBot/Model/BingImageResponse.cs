namespace suggesttriplocationBot.Model
{
    using System.Collections.Generic;

    public class BingImageResponse
    {
        public string _type { get; set; }
        public Instrumentation instrumentation { get; set; }
        public BestRepresentativeQuery bestRepresentativeQuery { get; set; }
        public List<VisuallySimilarImages> visuallySimilarImages { get; set; }
        public string imageInsightsToken { get; set; }
    }

    public class Instrumentation
    {
        public string pingUrlBase { get; set; }
        public string pageLoadPingUrl { get; set; }
    }

    public class BestRepresentativeQuery
    {
        public string text { get; set; }
        public string displayText { get; set; }
        public string webSearchUrl { get; set; }
        public string webSearchUrlPingSuffix { get; set; }
    }

    public class Thumbnail
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class VisuallySimilarImages
    {
        public string name { get; set; }
        public string webSearchUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public string datePublished { get; set; }
        public string contentUrl { get; set; }
        public string hostPageUrl { get; set; }
        public string contentSize { get; set; }
        public string encodingFormat { get; set; }
        public string hostPageDisplayUrl { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Thumbnail thumbnail { get; set; }
        public string imageInsightsToken { get; set; }
        public string imageId { get; set; }
        public string accentColor { get; set; }
    }
}