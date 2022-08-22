using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelBooking.Core.Responses;

public class CreateBookingResponse
{
    public CreateBookingResponse(Guid id)
    {
        BookingId = id;
    }

    public Guid BookingId { get; }
}