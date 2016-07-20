﻿using Newtonsoft.Json;

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bro2Bro.PCL.Handlers {
    public abstract class BaseHandler {
        private readonly Guid? _userGUID;

        protected BaseHandler(Guid? userGUID = null) {
            _userGUID = userGUID;
        }

        protected abstract string BaseControllerName();

        private HttpClient GetHttpClient() {
            var handler = new HttpClientHandler();

            var client = new HttpClient(handler) { Timeout = TimeSpan.FromMinutes(1) };

            if (_userGUID == null) {
                return client;
            }
            
            client.DefaultRequestHeaders.Add("UserGUID", _userGUID.Value.ToString());

            return client;
        }

        private string generateURL(string arguments) => string.IsNullOrEmpty(arguments) ? $"{Common.Constants.WEBAPI_ADDRESS}{BaseControllerName()}" : $"{Common.Constants.WEBAPI_ADDRESS}{BaseControllerName()}?{arguments}";

        public async Task<T> GetAsync<T>() => await GetAsync<T>(string.Empty);

        protected async Task<T> GetAsync<T>(string urlArguments) {
            var str = await GetHttpClient().GetStringAsync(generateURL(urlArguments));

            return JsonConvert.DeserializeObject<T>(str);
        }

        protected async void GetAsync(string urlArguments) {
            await GetHttpClient().GetStringAsync(generateURL(urlArguments));
        }

        private StringContent getStringContent<T>(T obj) => new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

        protected async Task<TK> PostAsync<T, TK>(T obj) {
            var response = await GetHttpClient().PostAsync(generateURL(string.Empty), getStringContent(obj));

            var responseStr = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TK>(responseStr);
        }

        protected async Task<TK> PutAsync<T, TK>(T obj) => await PutAsync<T, TK>(string.Empty, obj);

        protected async Task<TK> PutAsync<T, TK>(string urlArguments, T obj) {
            var response = await GetHttpClient().PutAsync(generateURL(string.Empty), getStringContent(obj));

            var responseStr = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TK>(responseStr);
        }
    }
}