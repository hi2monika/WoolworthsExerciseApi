using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoolworthsExcercise.Core.Common.Interfaces;
using WoolworthsExcercise.Core.Models.Entities.WoolworthsApi;

namespace WoolworthsExcercise.Infrastructure.Managers
{
    public class WoolworthsApiManager : IDataManager
    {
        
        private readonly Lazy<IWoolworthsApiService> _woolworthsApiService;
        private readonly ISystemSetting _systemSetting;

        public WoolworthsApiManager(IAuthenticatedHttpClientService authenticatedHttpClientService, ISystemSetting systemSetting)
        {
            _systemSetting = systemSetting;
            _woolworthsApiService = new Lazy<IWoolworthsApiService>(() => RestService.For<IWoolworthsApiService>(authenticatedHttpClientService.AuthenticatedHttpClient));
        }

        public async Task<IReadOnlyCollection<Products>> GetProductsAsync()
        {
            return await _woolworthsApiService.Value.GetProductsAsync(_systemSetting.Token);
        }

        public async Task<IReadOnlyCollection<Customer>> GetShopperHistoryAsync()
        {
            return await _woolworthsApiService.Value.GetShopperHistoryAsync(_systemSetting.Token);
        }
    }
}
