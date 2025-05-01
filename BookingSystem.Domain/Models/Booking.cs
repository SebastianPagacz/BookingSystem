using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Domain.Enums;

namespace BookingSystem.Domain.Models;

public class Booking : BaseModel
{
    public int CarId { get; set; }    
    public int CustomerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int RentalDays { get; set; }
    public decimal FullPrice { get; set; }
    public BookingStatus Status { get; set; } = 0;
}
