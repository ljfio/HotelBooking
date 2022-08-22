using HotelBooking.Infrastructure;
using HotelBooking.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Core.Services;

public class BookingService: ServiceBase, IBookingService
{
    public BookingService(ModelContext context) : base(context)
    {
    }

    public async ValueTask<BookingEntity> GetBookingAsync(Guid id)
    {
        return await Context.Bookings
            .Include(b => b.Rooms)
            .SingleOrDefaultAsync(b => b.Id == id);
    }

    public async ValueTask<Guid> CreateBookingAsync(IEnumerable<Guid> roomIds, DateTime startDate, DateTime endDate)
    {
        await using (var transaction = await Context.Database.BeginTransactionAsync())
        {
            var rooms = await Context.Rooms
                .Where(r => roomIds.Contains(r.Id))
                .ToListAsync();

            var booking = new BookingEntity
            {
                Rooms = rooms,
                StartDate = startDate,
                EndDate = endDate,
            };
            
            await Context.Bookings.AddAsync(booking);

            await Context.SaveChangesAsync();

            await transaction.CommitAsync();

            return booking.Id;
        }
    }
}