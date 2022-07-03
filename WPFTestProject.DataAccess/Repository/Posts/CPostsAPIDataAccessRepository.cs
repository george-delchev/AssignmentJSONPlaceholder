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
        const string _baseUrl = "https://jsonplaceholder.typicode.com/";
        public CPostsAPIDataAccessRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<PostDA>> GetPosts()
        {
            var methodBase = System.Reflection.MethodBase.GetCurrentMethod();
            var res = await this.SendBaseRequest<List<PostDA>>("posts", methodBase.Name);
            return res;
        }

        private async Task<T> SendBaseRequest<T>(string url, string methodBaseName) where T : new()
        {
            System.Diagnostics.Trace.WriteLine($"CPostsAPIDataAccessRepository\\SendBaseRequest: Sending request from: {methodBaseName}");
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
                var errorMsg = $"CPostsAPIDataAccessRepository\\SendBaseRequest: Failed request from: {methodBaseName}; StatusCode:{response.StatusCode}";
                System.Diagnostics.Trace.Fail(errorMsg);
                throw new System.Exception(errorMsg);
            }
            return result;
        }       
    }
}
