using System.Text.Json.Serialization;

namespace HotelBooking.Core.Models;

public class RoomModel
{
    public Guid Id { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public RoomType Type { get; set; }

    [JsonIgnore]
    public int Capacity => Type == RoomType.Single ? 1 : 2;
}