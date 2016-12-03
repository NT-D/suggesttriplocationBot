﻿using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Headers;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using Newtonsoft.Json;
using suggesttriplocationBot.Model;

namespace suggesttriplocationBot.Services
{
    /// <summary>
    /// A client that handles the interactions with the Bing Image Search API.
    /// <remarks>
    /// </remarks>
    /// </summary>

    public class BingImageSearchService : IImageSearchService
    {
        /// <summary>
        /// Microsoft Computer Vision API key.
        /// </summary>
        private static readonly string ApiKey = WebConfigurationManager.AppSettings["BingSearchApiKey"];

        /// <summary>
        /// The bing API URL.
        /// </summary>
        private static readonly string BingApiUrl = "https://api.cognitive.microsoft.com/bing/v5.0/images/search?modulesRequested=All&mkt=en-us&form=BCSPRD";

        /// <summary>
        /// Gets a list of visually similar products from an image URL.
        /// </summary>
        /// <param name="url">The URL of an image.</param>
        /// <returns>List of visually similar products' images.</returns>
        public async Task<IList<ImageResult>> GetSimilarImagesAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ApiKey);

                string apiUrl = BingApiUrl + $"&imgUrl={HttpUtility.UrlEncode(url)}";

                var text = await httpClient.GetStringAsync(apiUrl);
                var response = JsonConvert.DeserializeObject<BingImageResponse>(text);

                return response
                    ?.visuallySimilarImages
                    ?.Select(i => new ImageResult
                    {
                        HostPageDisplayUrl = i.hostPageDisplayUrl,
                        HostPageUrl = i.hostPageUrl,
                        Name = i.name,
                        ThumbnailUrl = i.thumbnailUrl,
                        WebSearchUrl = i.webSearchUrl
                    })
                    .ToList();
            }
        }

        /// <summary>
        /// Gets a list of visually similar products from an image stream.
        /// </summary>
        /// <param name="stream">The stream to an image.</param>
        /// <returns>List of visually similar images.</returns>
        public async Task<IList<ImageResult>> GetSimilarImagesAsync(Stream stream)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ApiKey);

                var strContent = new StreamContent(stream);
                strContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { FileName = "Any-Name-Works" };

                var content = new MultipartFormDataContent();
                content.Add(strContent);

                var postResponse = await httpClient.PostAsync(BingApiUrl, content);
                var text = await postResponse.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<BingImageResponse>(text);

                return response
                    ?.visuallySimilarImages
                    ?.Select(i => new ImageResult
                    {
                        HostPageDisplayUrl = i.hostPageDisplayUrl,
                        HostPageUrl = i.hostPageUrl,
                        Name = i.name,
                        ThumbnailUrl = i.thumbnailUrl,
                        WebSearchUrl = i.webSearchUrl
                    })
                    .ToList();
            }
        }
    }
}