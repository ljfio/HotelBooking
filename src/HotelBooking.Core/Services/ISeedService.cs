namespace HotelBooking.Core.Services;

public interface ISeedService
{
    ValueTask SeedAsync();
    ValueTask ResetAsync();
}