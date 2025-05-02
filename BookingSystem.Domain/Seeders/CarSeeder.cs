using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Domain.Models;
using BookingSystem.Domain.Repositories;

namespace BookingSystem.Domain.Seeders;

public class CarSeeder(DataContext context) : ICarSeeder
{
    public async Task SeedAsync()
    {
        if (!context.Cars.Any())
        {
            var cars = new List<Car>
            {
                new Car { Brand = "BMW", Model = "m2", Year = "2021", IsDeleted = false, PricePerDay = 200},
                new Car { Brand = "Mercedes", Model = "c63", Year = "2023", IsDeleted = false, PricePerDay = 600},
                new Car { Brand = "Audi", Model = "rs3", Year = "2019", IsDeleted = false, PricePerDay = 400},
            };
            context.Cars.AddRange(cars);
            await context.SaveChangesAsync();
        }
    }
}
