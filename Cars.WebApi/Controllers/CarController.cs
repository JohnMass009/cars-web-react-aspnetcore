using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cars.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        public CarController(ILogger<CarController> logger, ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet()]
        public ActionResult Get()
        {
            List<CarDto> carDtos = _carService.GetAll();
            if(!carDtos.Any())
                return BadRequest("Автомобили не найдены");

            return Ok(carDtos);
        }
    }
}
