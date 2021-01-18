using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoolworthsExcercise.Api.Common;
using WoolworthsExcercise.Api.Model;
using CoreCommon = WoolworthsExcercise.Core.Common;
using WoolworthsExcercise.Core.Query.Products;
using WoolworthsExcercise.Core.ViewModel;

namespace WoolworthsExcercise.Api.Controller.V1
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiController
    {
        public ProductController(IMediator mediator)
            : base(mediator)
        {
        }


        [HttpGet]
        [Route("sort")]
        [SwaggerResponse(200, ApiResponseMessages.SuccessfulOperation, typeof(IEnumerable<ProductsViewModel>))]
        [SwaggerResponse(401, ApiResponseMessages.Unauthorized, typeof(ErrorResponseModel))]
        [SwaggerResponse(404, ApiResponseMessages.NotFound, typeof(ErrorResponseModel))]
        [SwaggerResponse(500, ApiResponseMessages.InternalServerError, typeof(ErrorResponseModel))]
        public async Task<IEnumerable<ProductsViewModel>> GetProductsAsync(CoreCommon.SortOptionsEnum sortOption)
        {
            return await Mediator.Send(new GetProductsQuery(sortOption));

        }
    }
}
