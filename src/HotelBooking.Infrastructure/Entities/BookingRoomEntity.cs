using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Infrastructure.Entities;

[Table("BookingRoom")]
public class BookingRoomEntity
{
    public Guid BookingId { get; set; }
    
    public Guid RoomId { get; set; }

    public BookingEntity Booking { get; set; }
    
    public RoomEntity Room { get; set; }
}