using FluentResults;

namespace HotelBooking.Core.Errors;

public class NotEnoughCapacityError : Error, INotFoundError
{
    public NotEnoughCapacityError()
    {
        Message = "Not enough capacity at this hotel";
    }
}