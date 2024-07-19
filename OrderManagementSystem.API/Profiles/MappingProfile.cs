using AutoMapper;
using Order_Management_System.Repositories.Models;
using OrderManagementSystem.API.DTOs.customer;
using OrderManagementSystem.API.DTOs.Invoice;
using OrderManagementSystem.API.DTOs.Order;
using OrderManagementSystem.API.DTOs.Product;

namespace OrderManagementSystem.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDTO, Customer>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Customer, CustomerOrderToReturnDTO>()
                     .ForMember(C => C.CustomerId, S => S.MapFrom(S => S.Id))
                     .ForMember(C => C.Name, S => S.MapFrom(S => S.Name));
            CreateMap<OrderDTO, CustomerOrderToReturnDTO>();
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<InvoiceDTO, Invoice>().ReverseMap();
            // source    destination


                                // Somthing Wrong when Mapping Properties in it ? Check
            CreateMap<OrderDTO, Order>()
                     .ForMember(dest => dest.Address.FirstName, opt => opt.MapFrom(src => src.Address.FirstName))
                     .ForMember(dest => dest.Address.LastName, opt => opt.MapFrom(src => src.Address.LastName))
                     .ForMember(dest => dest.Address.Country, opt => opt.MapFrom(src => src.Address.Country))
                     .ForMember(dest => dest.Address.City, opt => opt.MapFrom(src => src.Address.City))
                     .ForMember(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Address.Street))
                     .ForMember(dest => dest.OrderItems.Select(O => O.Quantity), opt => opt.MapFrom(src => src.OrderItems.Select(O => O.Quantity)))
                     .ForMember(dest => dest.OrderItems.Select(O => O.UnitPrice), opt => opt.MapFrom(src => src.OrderItems.Select(O => O.Price)))
                     .ForMember(dest => dest.OrderItems.Select(O => O.ProductId), opt => opt.MapFrom(src => src.OrderItems.Select(O => O.productItem.Id)))
                     .ForMember(dest => dest.OrderItems.Select(O => O.Product.Name), opt => opt.MapFrom(src => src.OrderItems.Select(O => O.productItem.ProductName)))
                     .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.paymentMethod));

        }
    }
}
