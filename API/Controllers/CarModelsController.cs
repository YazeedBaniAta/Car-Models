using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarModelsController : ControllerBase
{
    private readonly ICarMakeService _carMakeService;
    public CarModelsController(ICarMakeService carMakeService)
    {
        _carMakeService = carMakeService;
    }

    [HttpGet]
    [Route("GetCarModels")]
    public async Task<IActionResult> GetCarModels([FromQuery] string make, int modelYear)
    {
        return Ok(await _carMakeService.GetCarModelsAsync(make, modelYear));
    }
}
