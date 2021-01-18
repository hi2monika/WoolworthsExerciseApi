using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WoolworthsExcercise.Core.Common.Interfaces;

namespace WoolworthsExcercise.Infrastructure.Services
{
    public class HttpMessageHandler : DelegatingHandler, IHttpMessageHandler
    {
               
        private readonly ILogger<HttpMessageHandler> _logger;
  
        public HttpMessageHandler(ILogger<HttpMessageHandler> logger)
        { 
            _logger = logger;
            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
          

            _logger.LogDebug($"[{nameof(HttpMessageHandler)}] Making a call to: {request.RequestUri}...");

            if (!(request.Content is null))
            {
                var requestContent = await request.Content.ReadAsStringAsync();
                _logger.LogDebug($"[{nameof(HttpMessageHandler)}] Request content: {requestContent}");
            }

            var response = await base.SendAsync(request, cancellationToken);

            _logger.LogDebug($"[{nameof(HttpMessageHandler)}] Request finished with the status: {response.StatusCode}");
            if (!(response.Content is null))
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogDebug($"[{nameof(HttpMessageHandler)}] Request content: {responseContent}");
            }

            return response;
        }
    }
}
