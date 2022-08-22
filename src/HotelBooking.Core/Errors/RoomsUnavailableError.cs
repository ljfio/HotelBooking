using FluentResults;

namespace HotelBooking.Core.Errors;

public class RoomsUnavailableError: Error
{
    public RoomsUnavailableError()
    {
        Message = "The rooms you have selected are not available for booking";
    }
}