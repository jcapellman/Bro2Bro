using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Bro2Bro.lib.HttpHandlers.Base
{
    public class BaseHttpHandler
    {
        private readonly string _baseWebServiceUrl;
        
        private readonly HttpClient _httpClient;

        public BaseHttpHandler(string baseWebServiceUrl, string broId = null)
        {
            _baseWebServiceUrl = baseWebServiceUrl;   
            
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Add("BroId", broId);
        }

        public async Task<T> PostAsync<T>(string url, params string[] param)
        {
            var parameters = param.ToDictionary(a => nameof(a), v => v);

            var encodedContent = new FormUrlEncodedContent(parameters);

            var response = await _httpClient.PostAsync(url, encodedContent);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public async Task<T> GetAsync<T>(string url, params string[] param)
        {
            var parameters = param.ToDictionary(a => nameof(a), v => v);
            
            var uri = $"{_baseWebServiceUrl}{url}?{string.Join("&", parameters.Select(a => $"{a.Key}={a.Value}"))}";

            var response = await _httpClient.GetAsync(uri);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}