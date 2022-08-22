using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Infrastructure.Entities;

[Table("Booking")]
public class BookingEntity
{
    [Key]
    public Guid Id { get; set; }
    
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public ICollection<RoomEntity> Rooms { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ICollection<BookingRoomEntity> BookingRooms { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
}