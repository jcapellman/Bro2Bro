using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Bro2Bro.Mobile.Models;

using Xamarin.Forms;

namespace Bro2Bro.Mobile.ViewModels 
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }

        public Command LoadItemsCommand { get; set; }

        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.BroName;

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                Items.Clear();

                var items = await DataStore.GetItemsAsync(true);

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}