using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Xamarin.Essentials;

using Bro2Bro.lib.HttpHandlers;

using Bro2Bro.Mobile.Models;

namespace Bro2Bro.Mobile.Services
{
    public class ProductionDataStore : IDataStore<Item>
    {
        IEnumerable<Item> items;

        public ProductionDataStore()
        {
            items = new List<Item>();
        }

        bool IsConnected => Connectivity.NetworkAccess != NetworkAccess.Internet;

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var messagesHandler = new MessagesHandler(App.ProductionBackendUrl, App.BroId);
                
                // TODO Add MessagesList
            }

            return items;
        }

        public Task<bool> AddItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {

            }

            return null;
        }
    }
}