using System.Reflection;
using HotelBooking.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBooking.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services) => services
        .AddAutoMapper(Assembly.GetExecutingAssembly())
        .AddScoped<IHotelService, HotelService>()
        .AddScoped<IBookingService, BookingService>()
        .AddScoped<IRoomService, RoomService>()
        .AddScoped<ISeedService, SeedService>();
}