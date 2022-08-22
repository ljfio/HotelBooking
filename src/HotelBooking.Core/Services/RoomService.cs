using HotelBooking.Infrastructure;
using HotelBooking.Infrastructure.Entities;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Core.Services;

public class RoomService: ServiceBase, IRoomService
{
    public RoomService(ModelContext context) : base(context)
    {
    }

    public async ValueTask<RoomEntity> GetRoomAsync(Guid id)
    {
        return await Context.Rooms.SingleOrDefaultAsync(r => r.Id == id);
    }

    public async ValueTask<IEnumerable<RoomEntity>> GetRoomsAsync(IEnumerable<Guid> ids)
    {
        return await Context.Rooms
            .Where(r => ids.Contains(r.Id))
            .ToListAsync();
    }

    public async ValueTask<IEnumerable<RoomEntity>> GetAvailableRoomsForHotelAsync(
        Guid hotelId, DateTime startDate, DateTime endDate)
    {
        var predicate = PredicateBuilder.New<RoomEntity>(r => r.HotelId == hotelId);

        predicate.And(r => !r.Bookings.Any(b => b.EndDate > startDate && b.StartDate < endDate));
        
        return await Context.Rooms
            .Where(predicate)
            .ToListAsync();
    }

    public async ValueTask<bool> IsRoomAvailableAsync(Guid id, DateTime startDate, DateTime endDate)
    {
        var predicate = PredicateBuilder.New<RoomEntity>(r => r.Id == id);

        predicate.And(r => !r.Bookings.Any(b => b.EndDate > startDate && b.StartDate < endDate));

        return await Context.Rooms.AnyAsync(predicate);
    }
    
    public async ValueTask<bool> AreRoomsAvailableAsync(IEnumerable<Guid> ids, DateTime startDate, DateTime endDate)
    {
        var predicate = PredicateBuilder.New<RoomEntity>(r => ids.Contains(r.Id));

        predicate.And(r => !r.Bookings.Any(b => b.EndDate > startDate && b.StartDate < endDate));

        return await Context.Rooms.AnyAsync(predicate);
    }
}