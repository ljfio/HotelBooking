using HotelBooking.Infrastructure;

namespace HotelBooking.Core.Services;

public abstract class ServiceBase
{
    protected ModelContext Context { get; }

    protected ServiceBase(ModelContext context)
    {
        Context = context;
    }
}