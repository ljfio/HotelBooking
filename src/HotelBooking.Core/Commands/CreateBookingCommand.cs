using FluentResults;
using HotelBooking.Core.Responses;
using Mediator;

namespace HotelBooking.Core.Commands;

public class CreateBookingCommand : ICommand<Result<CreateBookingResponse>>
{
    public CreateBookingCommand(DateTime startDate, DateTime endDate, IEnumerable<Guid> rooms)
    {
        StartDate = startDate;
        EndDate = endDate;
        Rooms = rooms;
    }

    public DateTime StartDate { get; }

    public DateTime EndDate { get; }

    public IEnumerable<Guid> Rooms { get; }
}