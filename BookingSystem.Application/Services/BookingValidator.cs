using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Services;

public class BookingValidator : IBookingValidator
{
    public bool ValidateDates(DateTime startDate, DateTime endDate)
    {
        int result = DateTime.Compare(startDate, endDate);

        if (result > 0)
            return false;
        else
            return true;
    }
}
