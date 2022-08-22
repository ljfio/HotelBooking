using HotelBooking.Infrastructure.Entities;

namespace HotelBooking.Core.Services;

public interface IRoomService
{
    ValueTask<RoomEntity> GetRoomAsync(Guid id);
    ValueTask<IEnumerable<RoomEntity>> GetRoomsAsync(IEnumerable<Guid> ids);
    ValueTask<IEnumerable<RoomEntity>> GetAvailableRoomsForHotelAsync(Guid hotelId, DateTime startDate,
        DateTime endDate);
    ValueTask<bool> AreRoomsAvailableAsync(IEnumerable<Guid> ids, DateTime startDate, DateTime endDate);
}