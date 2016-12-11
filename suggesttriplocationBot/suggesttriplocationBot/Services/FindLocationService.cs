using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using suggesttriplocationBot.Model;

namespace suggesttriplocationBot.Services
{
    public class BingMapService
    {
        //static information for FindLocation API
        private static readonly string ApiKey = WebConfigurationManager.AppSettings["BingMapApiKey"];
        private static string ApiEndpoint = $"http://dev.virtualearth.net/REST/v1/Locations?key={ApiKey}";

        //static information for Creating Custom Map URL
        private static string CustomMapUrl = "http://bing.com/maps/default.aspx?";

        public async Task<FindLocationResponse> FindLocation(string placeName)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string apiUrl = ApiEndpoint + $"&q={HttpUtility.UrlEncode(placeName)}";

                var text = await httpClient.GetStringAsync(apiUrl);
                var response = JsonConvert.DeserializeObject<FindLocationResponse>(text);
                return response;
            }
        }

        //Create Custom Map Url for search
        public string CreateCustomMapUrl (FindLocationResponse locationInfo)
        {
            Address address = locationInfo.resourceSets[0].resources[0].address;
            string searchQuery = $"{address.landmark},{address.adminDistrict},{address.countryRegion}";
            return $"{CustomMapUrl}where1={HttpUtility.UrlEncode(searchQuery)}";
        }
    }
}