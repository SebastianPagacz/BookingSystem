using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BookingSystem.Domain.Repositories.Interfaces;

public interface ICarRepository
{
    Task<Car> AddAsync(Car car);
    Task<IEnumerable<Car>> GetAsync();
    Task<Car> GetByIdAsync(int id);
    Task<Car> UpdateAsync(Car car);
}
