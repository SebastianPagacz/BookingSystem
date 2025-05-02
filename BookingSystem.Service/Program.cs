
using BookingSystem.Application.Services;
using BookingSystem.Domain.Repositories;
using BookingSystem.Domain.Repositories.Interfaces;
using BookingSystem.Domain.Repositories.Services;
using BookingSystem.Domain.Seeders;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseInMemoryDatabase("TestDb"));

            builder.Services.AddScoped<IBookingValidator, BookingValidator>();
            builder.Services.AddScoped<ICarRepository, CarRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICarSeeder, CarSeeder>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<ICarSeeder>();
            seeder.SeedAsync();

            app.Run();
        }
    }
}
