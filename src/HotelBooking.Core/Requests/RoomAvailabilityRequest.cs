using FluentResults;
using HotelBooking.Core.Responses;
using Mediator;

namespace HotelBooking.Core.Requests;

public class RoomAvailabilityRequest : IRequest<Result<RoomAvailabilityResponse>>
{
    public RoomAvailabilityRequest(Guid hotelId, DateTime startDate, DateTime endDate, int numberOfPeople)
    {
        HotelId = hotelId;
        StartDate = startDate;
        EndDate = endDate;
        NumberOfPeople = numberOfPeople;
    }

    public Guid HotelId { get; }
    
    public DateTime StartDate { get; }

    public DateTime EndDate { get; }

    public int NumberOfPeople { get; }
}