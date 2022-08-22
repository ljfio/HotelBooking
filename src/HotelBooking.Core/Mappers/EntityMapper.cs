using AutoMapper;
using HotelBooking.Core.Models;
using HotelBooking.Infrastructure.Entities;

namespace HotelBooking.Core.Mappers;

public class EntityMapper : Profile
{
    public EntityMapper()
    {
        CreateMap<HotelEntity, HotelModel>();
        
        CreateMap<RoomEntity, RoomModel>()
            .ForMember(r => r.Type, opt => opt.MapFrom(src => (RoomType)src.RoomType));

        CreateMap<BookingEntity, BookingModel>();
    }
}