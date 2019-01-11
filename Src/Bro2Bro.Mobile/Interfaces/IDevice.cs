using System.Threading.Tasks;

namespace Bro2Bro.Mobile.Interfaces
{
    public interface IDevice
    {
        Task<string> GetDeviceAsync();
    }
}