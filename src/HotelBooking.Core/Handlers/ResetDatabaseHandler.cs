using HotelBooking.Core.Commands;
using HotelBooking.Core.Services;
using Mediator;

namespace HotelBooking.Core.Handlers;

public class ResetDatabaseHandler : ICommandHandler<ResetDatabaseCommand>
{
    private readonly ISeedService _seedService;

    public ResetDatabaseHandler(ISeedService seedService)
    {
        _seedService = seedService;
    }

    public async ValueTask<Unit> Handle(ResetDatabaseCommand command, CancellationToken cancellationToken)
    {
        await _seedService.ResetAsync();
        
        return Unit.Value;
    }
}