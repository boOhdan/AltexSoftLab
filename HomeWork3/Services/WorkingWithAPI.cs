using FoodOrdering.BLL.Contracts;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoodOrdering.BLL.Services
{
    public class WorkingWithAPI<T> : IWorkingWithAPI<T>
    {
        private HttpClient _client = new HttpClient();
        public string Url { get; }

        public WorkingWithAPI(string url) 
        {
            Url = url;
        }

        public async Task<T> GetInstanceAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Url);

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<T>(responseStream);
            }

            return default;
        }
    }
}
