using System.Threading.Tasks;

using Bro2Bro.lib.HttpHandlers.Base;

namespace Bro2Bro.lib.HttpHandlers
{
    public class RegisterHandler : BaseHttpHandler
    {
        public async Task<bool> RegisterAsync(string broId, string displayName) => await PostAsync<bool>("/Register", broId, displayName);

        public RegisterHandler(string baseWebServiceUrlConnection) : base(baseWebServiceUrlConnection)
        {
        }
    }
}