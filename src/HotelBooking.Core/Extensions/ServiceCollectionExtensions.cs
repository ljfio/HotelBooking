using System.Reflection;
using FluentResults;
using HotelBooking.Core.Behaviors;
using HotelBooking.Core.Commands;
using HotelBooking.Core.Requests;
using HotelBooking.Core.Responses;
using HotelBooking.Core.Services;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBooking.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services) => services
        .AddAutoMapper(Assembly.GetExecutingAssembly())
        .AddScoped<IHotelService, HotelService>()
        .AddScoped<IBookingService, BookingService>()
        .AddScoped<IRoomService, RoomService>()
        .AddScoped<ISeedService, SeedService>()
        .AddSingleton<IPipelineBehavior<CreateBookingCommand, Result<CreateBookingResponse>>, ValidateCreateBookingBehavior>()
        .AddSingleton<IPipelineBehavior<RoomAvailabilityRequest, Result<RoomAvailabilityResponse>>, ValidateRoomAvailabilityBehavior>();
}