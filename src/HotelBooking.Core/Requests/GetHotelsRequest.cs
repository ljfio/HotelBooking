using FluentResults;
using HotelBooking.Core.Responses;
using Mediator;

namespace HotelBooking.Core.Requests;

public class GetHotelsRequest: IRequest<Result<GetHotelsResponse>>
{
    public GetHotelsRequest(string name)
    {
        Name = name;
    }

    public string Name { get; }
}