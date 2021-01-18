using System;
using System.Net.Http;
using WoolworthsExcercise.Core.Common.Interfaces;

namespace WoolworthsExcercise.Infrastructure.Services
{
    public class AuthenticatedHttpClientService : IAuthenticatedHttpClientService
    {
        public AuthenticatedHttpClientService(IAuthenticatedHttpMessageHandler basicAuthHttpMessageHandler, string baseUrl)
        {
            AuthenticatedHttpClient = new HttpClient(basicAuthHttpMessageHandler as System.Net.Http.HttpMessageHandler)
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public HttpClient AuthenticatedHttpClient { get; }
    }
}
