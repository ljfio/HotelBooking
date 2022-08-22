namespace HotelBooking.Core.Models;

public class BookingModel
{
    public Guid Id { get; init; }
    
    public DateTime StartDate { get; init; }

    public DateTime EndDate { get; init; }
    
    public IEnumerable<RoomModel> Rooms { get; init; }
}