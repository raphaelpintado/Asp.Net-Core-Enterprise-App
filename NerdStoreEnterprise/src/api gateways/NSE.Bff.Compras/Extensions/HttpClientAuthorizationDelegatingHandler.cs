using NSE.WebAPI.Core.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Bff.Compras.Extensions
{
    public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
    {
        private readonly IAspNetUser _user;

        public HttpClientAuthorizationDelegatingHandler(IAspNetUser user)
        {
            _user = user;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authorizationHeader = _user.ObterHttpContext().Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(authorizationHeader))
                request.Headers.Add("Authorization", new List<string> { authorizationHeader });

            var token = _user.ObterUserToken();

            if (!string.IsNullOrEmpty(token))
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
