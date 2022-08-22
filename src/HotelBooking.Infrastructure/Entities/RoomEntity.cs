using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Infrastructure.Entities;

[Table("Room")]
public class RoomEntity
{
    [Key] 
    public Guid Id { get; set; }

    public Guid HotelId { get; set; }

    public HotelEntity Hotel { get; set; }

    public int RoomType { get; set; }
    
    public ICollection<BookingEntity> Bookings { get; set; }
    
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ICollection<BookingRoomEntity> BookingRooms { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
}