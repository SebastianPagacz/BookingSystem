using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Enums;

public enum BookingStatus
{
    None = 0,
    Confirmed = 1,
    Cancelled = 2,
    Completed = 3
}
