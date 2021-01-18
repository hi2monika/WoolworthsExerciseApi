using FluentValidation;
using static WoolworthsExcercise.Core.Common.Constants;

namespace WoolworthsExcercise.Core.Command
{
    public class CreateTrolleyCommandValidator : AbstractValidator<CreateTrolleyCommand>
    {
        public CreateTrolleyCommandValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;


            RuleFor(CreateTrolley => CreateTrolley.Products)
            .NotEmpty()
            .WithErrorCode(ErrorCodes.TrolleyRequest.InvalidObjectInRequest)
            .WithMessage(ValidatorMessages.InvalidObjectInRequest)
            .NotNull()
            .WithErrorCode(ErrorCodes.TrolleyRequest.InvalidObjectInRequest)
            .WithMessage(ValidatorMessages.InvalidObjectInRequest);

            RuleFor(CreateTrolley => CreateTrolley.Quantities)
            .NotEmpty()
            .WithErrorCode(ErrorCodes.TrolleyRequest.InvalidObjectInRequest)
            .WithMessage(ValidatorMessages.InvalidObjectInRequest)
            .NotNull()
            .WithErrorCode(ErrorCodes.TrolleyRequest.InvalidObjectInRequest)
            .WithMessage(ValidatorMessages.InvalidObjectInRequest);

        }
    }
}
