using HotelBooking.Core.Responses;
using Mediator;

namespace HotelBooking.Core.Requests;

public class GetBookingRequest : IRequest<GetBookingResponse>
{
    public GetBookingRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}