using Bro2Bro.Mobile.Models;

namespace Bro2Bro.Mobile.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }

        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.BroName;

            Item = item;
        }
    }
}