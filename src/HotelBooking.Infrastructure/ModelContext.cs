using HotelBooking.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure;

public class ModelContext : DbContext
{
    public ModelContext(DbContextOptions options) : base(options)
    {
    }

    #region Collections

    public DbSet<HotelEntity> Hotels { get; set; }

    public DbSet<RoomEntity> Rooms { get; set; }

    public DbSet<BookingEntity> Bookings { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookingEntity>()
            .HasMany(m => m.Rooms)
            .WithMany(m => m.Bookings)
            .UsingEntity<BookingRoomEntity>(
                j => j.HasOne(t => t.Room)
                    .WithMany(t => t.BookingRooms)
                    .HasForeignKey(t => t.RoomId),
                j => j.HasOne(t => t.Booking)
                    .WithMany(t => t.BookingRooms)
                    .HasForeignKey(t => t.BookingId),
                j => j.HasKey(t => new { t.RoomId, t.BookingId }));

        modelBuilder.Entity<RoomEntity>()
            .HasOne(m => m.Hotel)
            .WithMany(m => m.Rooms)
            .HasForeignKey(m => m.HotelId);

        base.OnModelCreating(modelBuilder);
    }
}