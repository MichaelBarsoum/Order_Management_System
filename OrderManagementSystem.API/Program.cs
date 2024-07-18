using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Order_Management_System.CORE.Contexts;
using Order_Management_System.CORE.Contracts;
using Order_Management_System.CORE.Contracts.Services;
using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repositories.Models;
using Order_Management_System.Repositories.Repositories;
using Order_Management_System.Repository.Contexts.Identity;
using Order_Management_System.Repository.DataSeed;
using Order_Management_System.Repository.DataSeed.IdentitySeed;
using Order_Management_System.Services.Helpers;
using Order_Management_System.Services.Services;
using OrderManagementSystem.API.Custom;
using OrderManagementSystem.API.Errors;
using OrderManagementSystem.API.MiddleWare;
using OrderManagementSystem.API.Profiles;
using System.Text.Json;

namespace OrderManagementSystem.API
{
    // Lesa Hrage3 fe el A5er 5ales 3la 
    // awel 7aga el serialization problem 
    // 3. Check End Points => ay 7aga leha 3laka b el order
    // 4. update product Endpoint

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<OrderManagementDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconnection"));
            });
            builder.Services.AddDbContext<IdentityOrderManagementDbContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });

            builder.Services.ApplyServices();






         

            var app = builder.Build();

            #region Update DataBase Automatically

            using var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var dbContext = services.GetRequiredService<OrderManagementDbContext>();
                var identity = services.GetRequiredService<IdentityOrderManagementDbContext>();
                var userManager = services.GetRequiredService<UserManager<User>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await dbContext.Database.MigrateAsync();
                await identity.Database.MigrateAsync();
                await DefaultRoles.SeedRolesAsync(roleManager);
                await DefaultUsers.SeedAdminRoleAsync(userManager);
                await DefaultUsers.SeedCustomerRoleAsync(userManager);
                await SeedingDataToEntities.DataSeed(dbContext);
                await IdentifyUserRole.EnsureRolesAsync(roleManager);
            }
            catch (Exception ex)
            {
                var logError = loggerFactory.CreateLogger<Program>();
                logError.LogError(ex, "An Error Occure During Applying DataBase");
            }
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleWare>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
