using System;

namespace HotelBooking.Models;

public class RoomAvailabilityModel
{
    public DateTime StartDate { get; init; }
    
    public DateTime EndDate { get; init; }
    
    public int NumberOfPeople { get; init; }
}