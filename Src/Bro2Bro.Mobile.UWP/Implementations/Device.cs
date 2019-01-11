using System;
using System.Linq;
using System.Threading.Tasks;

using Windows.Devices.Enumeration;

using Bro2Bro.Mobile.Interfaces;

namespace Bro2Bro.Mobile.UWP.Implementations
{
    public class Device : IDevice
    {
        public async Task<string> GetDeviceAsync()
        {
            var devices = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync();

            return devices.FirstOrDefault(a => a.Kind == DeviceInformationKind.Device && a.IsEnabled)?.Id;
        }
    }
}