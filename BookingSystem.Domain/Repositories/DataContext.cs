using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Domain.Repositories;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }

    // Not needed for now
    //public DbSet<Customer> Customers { get; set; }
    //public DbSet<Booking> Bookings { get; set; }
}
