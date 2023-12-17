using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EngineVolumeController : Controller
    {
        private readonly IEngineVolumeService _engineVolumeService;

        public EngineVolumeController(ILogger<EngineVolumeController> logger, IEngineVolumeService engineVolumeService)
        {
            _engineVolumeService = engineVolumeService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<EngineVolumeDto> engineVolumeDtos = _engineVolumeService.GetAll();
            if (!engineVolumeDtos.Any())
                return BadRequest("Список объема двигателей не найден");

            return Ok(engineVolumeDtos);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            EngineVolumeDto? engineVolumeDto = _engineVolumeService.GetById(id);
            if (engineVolumeDto == null)
                return BadRequest("объем двигателя не найден");

            return Ok(engineVolumeDto);
        }
    }
}
