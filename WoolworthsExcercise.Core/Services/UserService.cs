using WoolworthsExcercise.Core.Common;
using WoolworthsExcercise.Core.Common.Interfaces.Services;
using WoolworthsExcercise.Core.ViewModel;

namespace WoolworthsExcercise.Core.Services
{
    public class UserService : IUserService
    {
        public UserViewModel GetUserInfo()
        {
            return new UserViewModel
            {
                Name = Constants.UserName,
                Token = Constants.Environment.ConfigurationNames.WoolworthsApiKey
            };

        }
    }
}
