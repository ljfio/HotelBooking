using FluentResults;
using FluentValidation.Results;

namespace HotelBooking.Core.Errors;

public class InvalidRequestError : Error, IBadRequestError
{
    public InvalidRequestError(ValidationResult result)
    {
        Message = result.ToString();
    }
}