using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.CarExceptions;

public class CarMissingException : Exception
{
    public CarMissingException() : base() { }
    public CarMissingException(string message) : base(message) { }
    public CarMissingException(string message, Exception innerException) : base(message, innerException) { }
   
}
