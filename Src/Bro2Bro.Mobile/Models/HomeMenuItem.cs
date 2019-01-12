namespace Bro2Bro.Mobile.Models
{
    public enum MenuItemType
    {
        Browse,
        FindBros
    }

    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}