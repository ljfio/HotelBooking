using System.Data;
using System.Data.Common;
using System.Text;
using Bogus;
using HotelBooking.Core.Models;
using HotelBooking.Infrastructure;
using HotelBooking.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;

namespace HotelBooking.Core.Services;

public class SeedService : ServiceBase, ISeedService
{
    public SeedService(ModelContext context) : base(context) { }

    public async ValueTask SeedAsync()
    {
        await using var transaction = await Context.Database.BeginTransactionAsync();
        
        var roomFaker = new Faker<RoomEntity>()
            .RuleFor(o => o.RoomType , f => (int)f.Random.Enum<RoomType>());

        var hotelFaker = new Faker<HotelEntity>()
            .RuleFor(o => o.Name, f => f.Address.StreetName())
            .RuleFor(o => o.Rooms, _ => roomFaker.Generate(6));

        var hotels = hotelFaker.GenerateBetween(5, 10);

        await Context.Hotels.AddRangeAsync(hotels);

        await Context.SaveChangesAsync();

        await transaction.CommitAsync();
    }

    public async ValueTask ResetAsync()
    {
        await using (var connection = Context.Database.GetDbConnection())
        {
            await connection.OpenAsync();

            await using (var transaction = await Context.Database.BeginTransactionAsync())
            {
                await ExecuteDeleteAllAsync(connection, transaction, "BookingRoom");
                await ExecuteDeleteAllAsync(connection, transaction, "Booking");
                await ExecuteDeleteAllAsync(connection, transaction, "Room");
                await ExecuteDeleteAllAsync(connection, transaction, "Hotel");

                await transaction.CommitAsync();
            }
        }
    }

    private Task<int> ExecuteDeleteAllAsync(DbConnection connection, IDbContextTransaction transaction, string tableName)
    {
        var command = connection.CreateCommand();

        command.Transaction = transaction.GetDbTransaction();
        command.CommandText = $"DELETE FROM [{tableName}];";
        command.CommandType = CommandType.Text;
        
        return command.ExecuteNonQueryAsync();
    }
}