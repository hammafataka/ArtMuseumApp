using System.Collections.Generic;

using ArtMuseumApp.models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

using Xamarin.Essentials;

namespace ArtMuseumApp.Services
{
    public class ApiService
    {
        public async  static Task<List<ArtObject>> GetArts(string ArtistName)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                string key = "ngZ3b7Ti";
                string url = $"https://www.rijksmuseum.nl/api/nl/collection?key={key}&involvedMaker={ArtistName}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage message = await client.GetAsync(url);
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    Root root = JsonConvert.DeserializeObject<Root>(json);
                    return root.artObjects;
                }
            }
            return new List<ArtObject>();
        }
        public async static Task<ArtObject> GetArtDetail(string ArtId)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                string key = "ngZ3b7Ti";
                string url = $"https://www.rijksmuseum.nl/api/en/collection/{ArtId}?key={key}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage message = await client.GetAsync(url);
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    Root art = JsonConvert.DeserializeObject<Root>(json);
                    return art.artObject;
                }
            }
            return new ArtObject();
        }
    }
}
