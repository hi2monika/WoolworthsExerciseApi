using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Threading.Tasks;
using WoolworthsExcercise.Api.Common;
using WoolworthsExcercise.Api.Model;
using WoolworthsExcercise.Core.Command;
using WoolworthsExcercise.Core.Common;
using WoolworthsExcercise.Core.Common.Exceptions;

namespace WoolworthsExcercise.Api.Controller.V1
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TrolleyController : ApiController
    {
        public TrolleyController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        [Route("trolleyCalculator")]
        [SwaggerResponse(200, ApiResponseMessages.SuccessfulOperation, typeof(double))]
        [SwaggerResponse(401, ApiResponseMessages.Unauthorized, typeof(ErrorResponseModel))]
        [SwaggerResponse(404, ApiResponseMessages.NotFound, typeof(ErrorResponseModel))]
        [SwaggerResponse(500, ApiResponseMessages.InternalServerError, typeof(ErrorResponseModel))]
        public async Task<double> CreateTrolley(CreateTrolleyCommand request)
        {
            if (request == null)
            {
                  throw new EmptyRequestException(Constants.ErrorCodes.TrolleyRequest.InvalidObjectInRequest);
            }
            return await Mediator.Send(request);

        }
    }
}
