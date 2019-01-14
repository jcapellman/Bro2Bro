using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Bro2Bro.lib.HttpHandlers.Base
{
    public class BaseHttpHandler
    {
        private string _server;

        private readonly HttpClient _httpClient;

        public BaseHttpHandler(string serverConnection)
        {
            _server = serverConnection;

            _httpClient = new HttpClient();
        }

        public async Task<T> PostAsync<T>(string url, params string[] param)
        {
            var parameters = param.ToDictionary(a => nameof(a), v => v);

            var encodedContent = new FormUrlEncodedContent(parameters);

            var response = await _httpClient.PostAsync(url, encodedContent).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}