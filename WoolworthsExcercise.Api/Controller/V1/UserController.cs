using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoolworthsExcercise.Api.Common;
using WoolworthsExcercise.Api.Model;
using WoolworthsExcercise.Core.Query.Products;
using WoolworthsExcercise.Core.Query.User;
using WoolworthsExcercise.Core.ViewModel;

namespace WoolworthsExcercise.Api.Controller.V1
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        public UserController(IMediator mediator)
            : base(mediator)
        {
        }


        [HttpGet]
        [SwaggerResponse(200, ApiResponseMessages.SuccessfulOperation, typeof(UserViewModel))]
        [SwaggerResponse(401, ApiResponseMessages.Unauthorized, typeof(ErrorResponseModel))]
        [SwaggerResponse(404, ApiResponseMessages.NotFound, typeof(ErrorResponseModel))]
        [SwaggerResponse(500, ApiResponseMessages.InternalServerError, typeof(ErrorResponseModel))]
        public async Task<UserViewModel> GetUser()
        {
            return await Mediator.Send(new GetUserQuery());

        }
    }
}
