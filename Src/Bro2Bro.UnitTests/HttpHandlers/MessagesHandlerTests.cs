using System.Threading.Tasks;

using Bro2Bro.lib.HttpHandlers;
using Bro2Bro.UnitTests.HttpHandlers.Base;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bro2Bro.UnitTests.HttpHandlers
{
    [TestClass]
    public class MessagesHandlerTests : BaseHttpTests
    {
        [TestMethod]
        public async Task NullArguments()
        {
            var messageHandler = new MessagesHandler(SERVER_BASE_URL);

            var result = await messageHandler.SendMessageAsync(null, null);

            Assert.IsFalse(result);
        }
    }
}