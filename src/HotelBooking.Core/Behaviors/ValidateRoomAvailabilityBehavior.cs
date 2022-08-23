using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using HotelBooking.Core.Errors;
using HotelBooking.Core.Requests;
using HotelBooking.Core.Responses;

namespace HotelBooking.Core.Behaviors;

public class ValidateRoomAvailabilityBehavior : ValidatorBehaviorBase<RoomAvailabilityRequest, RoomAvailabilityResponse>
{
    protected override InlineValidator<RoomAvailabilityRequest> Validator { get; } = new()
    {
        v => v.RuleFor(r => r.StartDate)
            .LessThan(r => r.EndDate)
            .WithMessage("The start date must be before the end date"),
        v => v.RuleFor(r => r.StartDate)
            .GreaterThanOrEqualTo(r => DateTime.Now.Date)
            .WithMessage("The start date cannot be earlier than today"),
        v => v.RuleFor(r => r.NumberOfPeople)
            .GreaterThan(0)
            .WithMessage("Must provide a number of people greater than 0"),
    };

    protected override IError CreateError(ValidationResult result) => new InvalidRequestError(result);
}