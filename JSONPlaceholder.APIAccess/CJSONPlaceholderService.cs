using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DnDApp.DataAccess.API.Services
{
    public class CJSONPlaceholderService// : IDnDAPIService
    {
        IHttpClientFactory _clientFactory;
        const string _baseUrl = "https://www.dnd5eapi.co/api";
        public CJSONPlaceholderService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> SendBaseRequest<T>(string url) where T : new()
        {
            var result = new T();
            var baseurl = $"{_baseUrl}";
            baseurl += url;

            var request = new HttpRequestMessage(HttpMethod.Get, baseurl);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<T>();
            }
            else
            {
                //result.ErrorString = response.ReasonPhrase;
            }
            return result;
        }       
    }
}
