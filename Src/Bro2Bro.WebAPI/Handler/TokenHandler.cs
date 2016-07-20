using Bro2Bro.WebAPI.BusinessLayer.Managers;

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bro2Bro.WebAPI.Handler {
    public class TokenHandler : DelegatingHandler {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            if (request.RequestUri.PathAndQuery.Contains("Auth")) {
                return await base.SendAsync(request, cancellationToken);
            }

            var userGUID = Guid.Parse(request.Headers.GetValues("UserGUID").First());

            var result = new AuthManager().CheckUserGUID(userGUID);

            if (!result) {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return await tsc.Task;
            }
            
            request.Properties.Add("UserGUID", userGUID);
            
            return await base.SendAsync(request, cancellationToken);
        }
    }
}