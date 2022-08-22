using System;
using System.Collections.Generic;

namespace HotelBooking.Models;

public class CreateBookingModel
{
    public DateTime StartDate { get; init; }

    public DateTime EndDate { get; init; }

    public IEnumerable<Guid> Rooms { get; init; }
}