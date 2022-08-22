using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Infrastructure.Entities;

[Table("Hotel")]
public class HotelEntity
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ICollection<RoomEntity> Rooms { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
}