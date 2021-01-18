using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoolworthsExcercise.Api.Model;
using WoolworthsExcercise.Core.Common.Exceptions;

namespace WoolworthsExcercise.Api.Extensions
{
    public static class BaseExceptionExtensions
    {
        public static ErrorResponseModel ToErrorResponseModel<TException>(this TException exception, string errorDescription = null)
          where TException : BaseException
        {
            var code = exception?.ErrorCode;
            var description = errorDescription ?? exception?.Message ?? string.Empty;

            return new ErrorResponseModel(code, description);
        }
    }
}
