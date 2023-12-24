using Cars.CarsDb.Models;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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

        [HttpGet("CarAllStrongPoints/{carId}")] /// название в атрибуте и во входной переменной get должны быть одинаковы, чтобы не писать дважды и чтобы значение с атрибута перешло в параметр метода
        public ActionResult Get(Guid carId)
        {
            List<StrongPointDto> strongPointDtos = _carStrongPointService.GetAllStrongPointsByCarId(carId);
            if (!strongPointDtos.Any())
                return BadRequest($"Сильные стороны авто не найдены");

            return Ok(strongPointDtos);
        }

        [HttpGet("CarStrongPoint/{id}")]
        public ActionResult Get(int id)
        {
            CarStrongPointReadDto? carStrongPointReadDto = _carStrongPointService.GetCarStrongPointDtoById(id);
            if (carStrongPointReadDto == null)
                return BadRequest("Запись не найдена");

            return Ok(carStrongPointReadDto);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CarStrongPointWriteDto carStrongPointDto)
        {
            if (carStrongPointDto == null)
                return BadRequest("У машины не найдены сильные стороны");

            return Ok(_carStrongPointService.CreateCarStrongPointById(carStrongPointDto));
            //return Ok("Запись успешно добавлена");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //if (_carStrongPointService.EntryExist(id)) // По хорошему сделать проверку на существующий id записи в БД
            //    return BadRequest("Введен неверный Id записи");

            _carStrongPointService?.DeleteCarStrongPointById(id);
            return Ok("Запись успешно удалена");
        }
    }
}
