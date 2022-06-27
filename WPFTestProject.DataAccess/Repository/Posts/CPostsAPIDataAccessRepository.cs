using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WPFTestProject.DataAccess.Models.Posts;

namespace WPFTestProject.DataAccess.Repository.Posts
{
    public class CPostsAPIDataAccessRepository : IPostsDataAccessRepository
    {
        IHttpClientFactory _clientFactory;
        const string _baseUrl = "https://jsonplaceholder.typicode.com/posts";
        public CPostsAPIDataAccessRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<PostDA>> GetPosts()
        {
            var res = await this.SendBaseRequest<List<PostDA>>("");
            return res;
        }

        private async Task<T> SendBaseRequest<T>(string url) where T : new()
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
