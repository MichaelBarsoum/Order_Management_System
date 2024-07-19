using AutoMapper;
using Order_Management_System.Repositories.Models;
using OrderManagementSystem.API.DTOs.Customer;
using OrderManagementSystem.API.DTOs.Invoice;
using OrderManagementSystem.API.DTOs.Order;
using OrderManagementSystem.API.DTOs.Product;

namespace OrderManagementSystem.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerOrderToReturnDTO>()
                     .ForMember(C => C.CustomerId, S => S.MapFrom(S => S.Id))
                     .ForMember(C => C.Name, S => S.MapFrom(S => S.Name));
            CreateMap<OrderDTO, CustomerOrderToReturnDTO>();
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<InvoiceDTO, Invoice>().ReverseMap();
            // source    destination
            CreateMap<OrderDTO,Order>()
                     .ForMember(dest => dest.Customer.Name ,opt => opt.MapFrom(src => src.CustomerName))
                     .ForMember(dest => dest.Customer.Email, opt => opt.MapFrom(src => src.CustomerEmail))
                     .ForMember(dest => dest.OrderItems.Select(O => O.Quantity),opt => opt.MapFrom(src => src.Quantity))
                     .ForMember(dest => dest.OrderItems.Select(O => O.UnitPrice),opt => opt.MapFrom(src => src.ItemPrice))
                     .ForMember(dest => dest.State,opt => opt.MapFrom(src => src.PaymentMethod))
                     .ForMember(dest => dest.TotalAmount,opt => opt.MapFrom(src => src.TotalItemsAmount)).ReverseMap();

        }
    }
}
