using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Models;

public class Car : BaseModel
{
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
    public string LicensePlate { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
    public bool IsAvailable { get; set; } = false;
    public decimal PricePerDay { get; set; }
}
