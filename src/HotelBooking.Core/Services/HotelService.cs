using HotelBooking.Infrastructure;
using HotelBooking.Infrastructure.Entities;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Core.Services;

public class HotelService : ServiceBase, IHotelService
{
    public HotelService(ModelContext context) : base(context)
    {
    }
    
    public async ValueTask<IEnumerable<HotelEntity>> GetHotelsByNameAsync(string name)
    {
        var predicate = PredicateBuilder.New<HotelEntity>(e => true);

        if (!string.IsNullOrEmpty(name))
            predicate.And(hotel => hotel.Name.ToLower().Contains(name.ToLower()));

        return await Context.Hotels
            .Where(predicate)
            .ToListAsync();
    }

    public async ValueTask<HotelEntity> GetHotelAsync(Guid id)
    {
        return await Context.Hotels.SingleOrDefaultAsync(h => h.Id == id);
    }
}