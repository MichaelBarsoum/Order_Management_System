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
            // source    destination
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<InvoiceDTO, Invoice>().ReverseMap();
            //CreateMap<OrderDTO, Order>()
            //        // Destination => Source 
            //        .ForMember(dest => DateTime.Parse(dest.OrderDate.ToString()), opt => opt.MapFrom(src => src.OrderDate.ToString()))
            //        .ForMember(dest => dest.PayMethod, opt => opt.MapFrom(src => src.PaymentMethod));
                    //.ForMember(dest => dest.)
            
                    //.ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => new List<OrderItem>
                    //{
                    //    new OrderItem
                    //    {
                    //        Quantity = src.orderItems.Select(Q => Q.Quantity).FirstOrDefault(),


                    //    }
                    //}))
                    //.ForMember(dest => dest.Customer, opt => opt.MapFrom(src => new Customer
                    //{
                    //    Name = src.CustomerName,
                    //    Email = src.CustomerEmail
                    //})).ReverseMap();



        }
    }
}
