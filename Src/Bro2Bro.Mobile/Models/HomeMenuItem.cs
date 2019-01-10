namespace Bro2Bro.Mobile.Models
{
    public enum MenuItemType
    {
        Browse,
        Logout
    }

    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}