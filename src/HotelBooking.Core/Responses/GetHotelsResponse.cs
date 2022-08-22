using HotelBooking.Core.Models;

namespace HotelBooking.Core.Responses;

public class GetHotelsResponse
{
    public GetHotelsResponse(IEnumerable<HotelModel> hotels)
    {
        Hotels = hotels;
    }

    public IEnumerable<HotelModel> Hotels { get; }
}