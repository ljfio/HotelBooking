using FluentResults;
using HotelBooking.Core.Commands;
using HotelBooking.Core.Errors;
using HotelBooking.Core.Models;
using HotelBooking.Core.Responses;
using HotelBooking.Core.Services;
using Mediator;

namespace HotelBooking.Core.Handlers;

public class CreateBookingHandler : ICommandHandler<CreateBookingCommand, Result<CreateBookingResponse>>
{
    private readonly IBookingService _bookingService;
    private readonly IRoomService _roomService;
    
    public CreateBookingHandler(IBookingService bookingService, IRoomService roomService)
    {
        _bookingService = bookingService;
        _roomService = roomService;
    }

    public async ValueTask<Result<CreateBookingResponse>> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
    {
        if (!await _roomService.AreRoomsAvailableAsync(command.Rooms, command.StartDate, command.EndDate))
        {
            return Result.Fail(new RoomsUnavailableError());
        }
        
        var id = await _bookingService.CreateBookingAsync(command.Rooms, command.StartDate, command.EndDate);
            
        return Result.Ok<CreateBookingResponse>(new(id));
    }
}