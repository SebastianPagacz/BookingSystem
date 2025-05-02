using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.BookingExceptions;

public class InvalidDateException : Exception
{
    public InvalidDateException() : base() { }
    public InvalidDateException(string message) : base(message) { }
    public InvalidDateException(string message, Exception innerExcpetion) : base(message, innerExcpetion) { }

}
