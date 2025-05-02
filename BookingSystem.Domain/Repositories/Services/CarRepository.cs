using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Domain.Models;
using BookingSystem.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Domain.Repositories.Services;

public class CarRepository : ICarRepository
{
    private readonly DataContext _context;
    public CarRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<Car> AddAsync(Car car)
    {
        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();

        return car;
    }

    public async Task<IEnumerable<Car>> GetAsync()
    {
        return await _context.Cars
            .Where(c => !c.IsDeleted)
            .ToListAsync();
    }

    public async Task<Car> GetByIdAsync(int id)
    {
        return await _context.Cars.FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception("Car not found");
    }

    public async Task<Car> UpdateAsync(Car car)
    {
        _context.Cars.Update(car);
        await _context.SaveChangesAsync();
        return car;
    }
}
