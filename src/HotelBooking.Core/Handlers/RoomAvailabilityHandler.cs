using System.Reflection;
using AutoMapper;
using FluentResults;
using HotelBooking.Core.Errors;
using HotelBooking.Core.Models;
using HotelBooking.Core.Requests;
using HotelBooking.Core.Responses;
using HotelBooking.Core.Services;
using HotelBooking.Infrastructure.Entities;
using Mediator;

namespace HotelBooking.Core.Handlers;

public class RoomAvailabilityHandler : IRequestHandler<RoomAvailabilityRequest, Result<RoomAvailabilityResponse>>
{
    private readonly IRoomService _roomService;
    private readonly IMapper _mapper;

    public RoomAvailabilityHandler(IRoomService roomService, IMapper mapper)
    {
        _roomService = roomService;
        _mapper = mapper;
    }

    public async ValueTask<Result<RoomAvailabilityResponse>> Handle(RoomAvailabilityRequest request, CancellationToken cancellationToken)
    {
        var entities =
            await _roomService.GetAvailableRoomsForHotelAsync(request.HotelId, request.StartDate, request.EndDate);

        var rooms = _mapper.Map<IEnumerable<RoomModel>>(entities).ToList();

        int totalAvailableCapacity = rooms.Sum(r => r.Capacity);
        
        var suggested = Enumerable.Empty<Guid>();

        var result = Result.Ok(new RoomAvailabilityResponse(rooms, suggested));

        if (totalAvailableCapacity < request.NumberOfPeople)
            return result.WithError(new NotEnoughCapacityError());

        return result;
    }

    // private IEnumerable<Guid> GetSuggested(IEnumerable<RoomModel> rooms, int numberOfPeople)
    // {
    //     var singles = new Queue<Guid>(rooms.Where(r => r.Capacity == 1).Select(r => r.Id));
    //     var doubles = new Queue<Guid>(rooms.Where(r => r.Capacity == 2).Select(r => r.Id));
    //
    //     
    // }
}