using AutoMapper;
using HotelBooking.Core.Models;
using HotelBooking.Core.Requests;
using HotelBooking.Core.Responses;
using HotelBooking.Core.Services;
using Mediator;

namespace HotelBooking.Core.Handlers;

public class GetBookingHandler : IRequestHandler<GetBookingRequest, GetBookingResponse>
{
    private readonly IBookingService _bookingService;
    private readonly IMapper _mapper;
    
    public GetBookingHandler(IBookingService bookingService, IMapper mapper)
    {
        _bookingService = bookingService;
        _mapper = mapper;
    }

    public async ValueTask<GetBookingResponse> Handle(GetBookingRequest request, CancellationToken cancellationToken)
    {
        var entity =  await _bookingService.GetBookingAsync(request.Id);

        var booking = _mapper.Map<BookingModel>(entity);

        return new GetBookingResponse()
        {
            Booking = booking,
        };
    }
}