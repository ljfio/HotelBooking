using HotelBooking.Infrastructure.Entities;

namespace HotelBooking.Core.Services;

public interface IBookingService
{
    ValueTask<BookingEntity> GetBookingAsync(Guid id);
    ValueTask<Guid> CreateBookingAsync(IEnumerable<Guid> roomIds, DateTime startDate, DateTime endDate);
}