using Cars.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cars.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        readonly ICarService _carService;
        public CarController(ILogger<CarController> logger, ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet()]
        public ActionResult Get()
        {
            return Ok(_carService.GetAll());
        }
    }
}
