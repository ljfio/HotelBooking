using HotelBooking.Core.Models;

namespace HotelBooking.Core.Responses;

public class GetBookingResponse
{
    public BookingModel Booking { get; init; }
}