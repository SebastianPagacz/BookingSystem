using System.Net;
using BookingSystem.Application.Services;
using BookingSystem.Domain.Exceptions.BookingExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingDatesController : ControllerBase
{
    private readonly IBookingValidator _validator;

    public BookingDatesController(IBookingValidator validator)
    {
        _validator = validator;
    }

    [HttpGet]
    public IActionResult Get(DateTime startDate, DateTime endDate)
    {
        try
        {
            var result = _validator.ValidateDates(startDate, endDate);
            return StatusCode(200, "Dates for the booking are valid");
        }
        catch (InvalidDateException)
        {
            return StatusCode(406);
        }
        catch (Exception)
        {
            return StatusCode(406);
        }
    }
}
