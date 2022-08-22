using FluentResults;

namespace HotelBooking.Core.Errors;

public class NotEnoughCapacityError : Error
{
    public NotEnoughCapacityError()
    {
        Message = "Not enough capacity at this hotel";
    }
}