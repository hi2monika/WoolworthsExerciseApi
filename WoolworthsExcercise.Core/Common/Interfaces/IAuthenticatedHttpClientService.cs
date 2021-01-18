using System.Net.Http;

namespace WoolworthsExcercise.Core.Common.Interfaces
{
    public interface IAuthenticatedHttpClientService
    {
        HttpClient AuthenticatedHttpClient { get; }
    }
}
