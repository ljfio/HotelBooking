using HotelBooking.Core.Models;

namespace HotelBooking.Core.Responses;

public class RoomAvailabilityResponse
{
    public RoomAvailabilityResponse(IEnumerable<RoomModel> available, IEnumerable<Guid> suggested)
    {
        Available = available;
        Suggested = suggested;
    }

    public IEnumerable<RoomModel> Available { get; }

    public IEnumerable<Guid> Suggested { get; }
}