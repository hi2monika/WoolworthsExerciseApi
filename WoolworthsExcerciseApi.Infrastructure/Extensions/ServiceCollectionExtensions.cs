using Microsoft.Extensions.DependencyInjection;
using WoolworthsExcercise.Core.Common;
using WoolworthsExcercise.Core.Common.Interfaces;
using WoolworthsExcercise.Infrastructure.Managers;
using WoolworthsExcercise.Infrastructure.Services;

namespace WoolworthsExcercise.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<IAuthenticatedHttpMessageHandler, HttpMessageHandler>();
            serviceCollection.AddScoped<IAuthenticatedHttpClientService>(provider =>
            {
                var authenticatedHttpMessageHandler = provider.GetService<IAuthenticatedHttpMessageHandler>();

                return new AuthenticatedHttpClientService(authenticatedHttpMessageHandler, Constants.Environment.ConfigurationNames.WoolworthsApiKeyBaseUrl);
            });
            
            serviceCollection.AddScoped<IDataManager, WoolworthsApiManager>();
            var systemSetting = new SystemSetting(Constants.Environment.ConfigurationNames.WoolworthsApiKey);
            serviceCollection.AddSingleton<ISystemSetting>(systemSetting);

            return serviceCollection;
        }
    }
}
