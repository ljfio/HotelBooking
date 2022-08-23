using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using HotelBooking.Core.Commands;
using HotelBooking.Core.Errors;
using HotelBooking.Core.Responses;

namespace HotelBooking.Core.Behaviors;

public class ValidateCreateBookingBehavior : ValidatorBehaviorBase<CreateBookingCommand, CreateBookingResponse>
{
    protected override InlineValidator<CreateBookingCommand> Validator { get; } = new()
    {
        v => v.RuleFor(c => c.StartDate)
            .LessThan(c => c.EndDate)
            .WithMessage("The start date must be before the end date"),
        v => v.RuleFor(r => r.StartDate)
            .GreaterThanOrEqualTo(r => DateTime.Now.Date)
            .WithMessage("The start date cannot be earlier than today"),
    };

    protected override IError CreateError(ValidationResult result) => new InvalidRequestError(result);
}