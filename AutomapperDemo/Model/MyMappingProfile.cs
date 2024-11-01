using AutoMapper;
using AutomapperDemo.Model;

namespace AutomapperDemo.Models
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            //Configure the Mappings Between Order and OrderDTO
            CreateMap<Order, OrderDTO>()
            .AfterMap((src, dest) => CustomizeOrderDTO.CalculateTotalPrice(src, dest))
            //.AfterMap(CustomizeOrderDTO.CalculateTotalPrice)
            .AfterMap((src, dest) =>
            {
                dest.OrderDate = CustomizeOrderDTO.CustomizeOrderDate(src.OrderDate);
            });

            //Configure the Mappings Between OrderItem and OrderItemDTO
            CreateMap<OrderItem, OrderItemDTO>();
        }
    }
}
