using Microsoft.AspNetCore.Mvc;
using Order_Management_System.CORE.Contracts;
using Order_Management_System.Repositories.Repositories;
using OrderManagementSystem.API.Profiles;
using OrderManagementSystem.API.Errors;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Order_Management_System.Repositories.Models;
using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repository.Contexts.Identity;
using Order_Management_System.CORE.Contracts.Services.Orders;
using Order_Management_System.Services.Services.ORDER;
using Order_Management_System.CORE.Contracts.Services.Auth;
using Microsoft.Extensions.DependencyInjection;
using Order_Management_System.Services.Services.AUTH;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Order_Management_System.CORE.Contracts.Services.Invoices;
using Order_Management_System.Services.Services.INVOICE;
using Order_Management_System.Repository.OrderState;
using Order_Management_System.CORE.OrderState;
using Order_Management_System.Services.Services.Payment.PayPal;

namespace OrderManagementSystem.API.Custom
{
    public static class ApplyConfigurations
    {
        public static IServiceCollection ApplyServices(this IServiceCollection Services)
        {
            
            Services.AddScoped<IOrderState, OrderState>();
            Services.AddScoped<IOrderServices, OrderServices>();
            Services.AddScoped<IInvoiceService, InvoiceService>();
            Services.AddScoped<IAuthService,AuthService>();
            Services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<IdentityOrderManagementDbContext>();
            Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            Services.AddScoped<UserManager<User>>();
            Services.AddAutoMapper(typeof(MappingProfile));
            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            Services.AddScoped(typeof(IOrderServices), typeof(OrderServices));
            Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(P => P.Value.Errors.Count() > 0)
                                                         .SelectMany(P => P.Value.Errors)
                                                         .Select(E => E.ErrorMessage).ToArray();

                    var validationErrorResponse = new ApiValidationResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(validationErrorResponse);
                };
            });

            return Services;
        } 
    }
}
