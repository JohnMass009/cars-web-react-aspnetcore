using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeakPointController : Controller
    {
        private readonly IWeakPointService _weakPointService;

        public WeakPointController(ILogger<WeakPointController> logger, IWeakPointService weakPointService)
        {
            _weakPointService = weakPointService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<WeakPointDto> weakpoints = _weakPointService.GetAll();
            if(!weakpoints.Any()) /// Any не работает с null. Здесь ставим Any т.к. у нас возвращается не null, а в теории пустой список
                return BadRequest("Список слабых сторон не найден");

            return Ok(weakpoints);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            WeakPointDto? weakPointDto = _weakPointService.GetById(id);
            if (weakPointDto == null)
                return BadRequest("Слабая сторона не найдена");

            return Ok(weakPointDto);
        }
    }
}
