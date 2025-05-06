using BookingSystem.Domain.Exceptions.CarExceptions;
using BookingSystem.Domain.Models;
using BookingSystem.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BookingSystem.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ICarRepository _repository;
    public CarController(ICarRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var cars = await _repository.GetAsync();
        return StatusCode(200, cars); 
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var car = await _repository.GetByIdAsync(id);
            return StatusCode(200, car);
        }
        catch (CarMissingException)
        {
            return StatusCode(404);
        }
        catch(Exception)
        {
            return StatusCode(404);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Car car)
    {
        await _repository.AddAsync(car);
        return StatusCode(200, car);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Car car)
    {
        try
        {
            await _repository.UpdateAsync(car);
            return StatusCode(200, car);
        }
        catch (CarMissingException) 
        {
            return StatusCode(404);
        }
        catch (Exception)
        {
            return StatusCode(404);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var car = await _repository.GetByIdAsync(id);
            car.IsDeleted = true;
            await _repository.UpdateAsync(car);
            return StatusCode(200, car);
        }
        catch (CarMissingException)
        {
            return StatusCode(404);
        }
        catch (Exception)
        {
            return StatusCode(404);
        }
    }
}
