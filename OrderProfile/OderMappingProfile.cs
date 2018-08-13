using AutoMapper;
using DutchTreat.Data.Entities;
using DutchTreat.Models;

namespace DutchTreat.OrderProfile
{
    public class OderMappingProfile: Profile
    {
     public OderMappingProfile()
     {
         CreateMap<Order, OrderModel>()
         .ForMember(o => o.OrderId, ex=> ex.MapFrom(o => o.Id))
         .ReverseMap();
     }
    }
}