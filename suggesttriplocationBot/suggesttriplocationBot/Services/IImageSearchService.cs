﻿using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace suggesttriplocationBot.Services
{
    internal interface IImageSearchService
    {
        /// <summary>
        /// Gets a list of visually similar products from an image stream.
        /// </summary>
        /// <param name="stream">The stream to an image.</param>
        /// <returns>List of visually similar products' images.</returns>
        //TODO: Update Interface name
        Task<IList<ImageResult>> GetSimilarProductImagesAsync(Stream stream);

        /// <summary>
        /// Gets a list of visually similar products from an image URL.
        /// </summary>
        /// <param name="url">The URL of an image.</param>
        /// <returns>List of visually similar products' images.</returns>
        Task<IList<ImageResult>> GetSimilarProductImagesAsync(string url);

    }
}
