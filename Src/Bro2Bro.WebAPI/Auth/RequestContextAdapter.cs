using Microsoft.AspNetCore.Http;

namespace Bro2Bro.WebAPI.Auth
{
    public interface IHttpRequestContext
    {
        string BroId { get; }
    }

    public sealed class HttpHttpRequestContext : IHttpRequestContext
    {
        private readonly IHttpContextAccessor _accessor;

        public HttpHttpRequestContext(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string BroId => _accessor.HttpContext.Request.Headers["BroId"];
    }
}