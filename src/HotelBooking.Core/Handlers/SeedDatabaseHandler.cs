using HotelBooking.Core.Commands;
using HotelBooking.Core.Services;
using Mediator;

namespace HotelBooking.Core.Handlers;

public class SeedDatabaseHandler : ICommandHandler<SeedDatabaseCommand>
{
    private readonly ISeedService _seedService;

    public SeedDatabaseHandler(ISeedService seedService)
    {
        _seedService = seedService;
    }

    public async ValueTask<Unit> Handle(SeedDatabaseCommand command, CancellationToken cancellationToken)
    {
        await _seedService.SeedAsync();
        
        return Unit.Value;
    }
}