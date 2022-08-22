using HotelBooking.Infrastructure.Entities;

namespace HotelBooking.Core.Services;

public interface IHotelService
{
    ValueTask<IEnumerable<HotelEntity>> GetHotelsByNameAsync(string name);
}