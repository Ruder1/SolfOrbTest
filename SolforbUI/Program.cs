using AutoMapper;
using BuisnessLogicLayer.Interfaces;
using BuisnessLogicLayer.Services;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SolforbUI.Services;
using System.Reflection;

namespace SolforbUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SolfOrb API",
                    Description = "An ASP.NET Core Web API for managing SolfOrb items"
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            // Add services to the container.

            builder.Services.AddControllersWithViews();

            builder.Services.AddCors();
            builder.Services.AddLogging();

            //Регистрация созданных сервисов
            //Сервисы в DAL
            builder.Services.AddTransient<IRepository<Order>, OrderRepository>();
            builder.Services.AddTransient<IRepository<OrderItem>, OrderItemRepository>();
            builder.Services.AddTransient<IRepository<Provider>, ProviderRepository>();
            builder.Services.AddTransient<IUnitOfWork, EFUnitOfWork>();

            //Сервисы в BuisnessLogicLayer
            builder.Services.AddTransient<IOrderItemsService, OrderItemsService>();
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddTransient<IProviderService, ProviderService>();

            //Регистрация сервисов внених библиотек
            var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            var connection = builder.Configuration.GetConnectionString("SolfOrbTest");
            builder.Services.AddDbContext<SolfOrbContext>
            (options =>
            {
                options.UseNpgsql(connection, b => b.MigrationsAssembly("DAL"));

            });

            var app = builder.Build();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}");

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}