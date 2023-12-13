using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cars.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StrongPointController : Controller
    {
        private readonly IStrongPointService _strongPointService;

        public StrongPointController(ILogger<CarController> logger, IStrongPointService strongPointService)
        {
            _strongPointService = strongPointService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<StrongPointDto> strongPoints = _strongPointService.GetAll();
            if (!strongPoints.Any()) /// Any не работает с null
                return BadRequest("Сильные стороны авто не найдены");

            return Ok(strongPoints);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            StrongPointDto? strongPoint = _strongPointService.GetById(id);
            if (strongPoint == null)
                return BadRequest("Сильная сторона авто не найдена");

            return Ok(strongPoint);
        }
    }
}
