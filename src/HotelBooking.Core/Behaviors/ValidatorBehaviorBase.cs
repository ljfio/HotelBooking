using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using HotelBooking.Core.Errors;
using Mediator;

namespace HotelBooking.Core.Behaviors;

public abstract class
    ValidatorBehaviorBase<TRequest, TResponse> : IPipelineBehavior<TRequest, Result<TResponse>>
    where TRequest : notnull, IMessage
{
    protected abstract IValidator<TRequest> Validator { get; }
    
    public async ValueTask<Result<TResponse>> Handle(TRequest message, CancellationToken cancellationToken,
        MessageHandlerDelegate<TRequest, Result<TResponse>> next)
    {
        var result = await Validator.ValidateAsync(message, cancellationToken);

        if (!result.IsValid)
            return Result.Fail(CreateError(result));

        return await next(message, cancellationToken);
    }

    protected abstract IError CreateError(ValidationResult result);
}