using AutoMapper;
using HotelBooking.Core.Models;
using HotelBooking.Core.Requests;
using HotelBooking.Core.Responses;
using HotelBooking.Core.Services;
using Mediator;

namespace HotelBooking.Core.Handlers;

public class GetHotelsHandler : IRequestHandler<GetHotelsRequest, GetHotelsResponse>
{
    private readonly IHotelService _hotelService;
    private readonly IMapper _mapper;

    public GetHotelsHandler(IHotelService hotelService, IMapper mapper)
    {
        _hotelService = hotelService;
        _mapper = mapper;
    }

    public async ValueTask<GetHotelsResponse> Handle(GetHotelsRequest request, CancellationToken cancellationToken)
    {
        var entites = await _hotelService.GetHotelsByNameAsync(request.Name);

        var hotels = _mapper.Map<IEnumerable<HotelModel>>(entites);
        
        return new GetHotelsResponse(hotels);
    }
}