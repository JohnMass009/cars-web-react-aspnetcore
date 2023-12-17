using Cars.CarsDb.Models;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarStrongPointController : Controller
    {
        private readonly ICarStrongPointService _carStrongPointService;

        public CarStrongPointController(ILogger<CarController> logger, ICarStrongPointService carStrongPointService)
        {
            _carStrongPointService = carStrongPointService;
        }

        [HttpGet("{iddd}")]
        public ActionResult Get(Guid id)
        {
            List<StrongPointDto> strongPointDtos = _carStrongPointService.GetAllByCarId(id);
            if (!strongPointDtos.Any())
                return BadRequest($"Сильные стороны авто не найдены");

            return Ok(strongPointDtos);
        }

        //[HttpPost]
        //public ActionResult Create([FromBody] CarStrongPointDto carStrongPointDto)
        //{
            
        //}
    }
}
