using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using WoolworthsExcercise.Core.Common.Interfaces.Services;

namespace WoolworthsExcercise.Core.Command
{
    public class CreateTrolleyCommandHandler : IRequestHandler<CreateTrolleyCommand, double>
    {
        private readonly ITrolleyService _trolleyService;
        private readonly ILogger<CreateTrolleyCommandHandler> _logger;
        public CreateTrolleyCommandHandler(ITrolleyService trolleyService, ILogger<CreateTrolleyCommandHandler> logger)
        {
            _trolleyService = trolleyService;
            _logger = logger;
        }
        public async Task<double>  Handle(CreateTrolleyCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_trolleyService.GetLowestTrollyPrice(request));
        }
    }
}
