using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using WoolworthsExcercise.Core.Common.Interfaces.Services;
using WoolworthsExcercise.Core.ViewModel;

namespace WoolworthsExcercise.Core.Query.User
{
    public class GetUserQuery : IRequest<UserViewModel>
    { }
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUserQueryHandler> _logger;
        public GetUserQueryHandler(IUserService userService , ILogger<GetUserQueryHandler> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
           var userInfo =  _userService.GetUserInfo();
            return await Task.FromResult(userInfo);
        }
    }
}
