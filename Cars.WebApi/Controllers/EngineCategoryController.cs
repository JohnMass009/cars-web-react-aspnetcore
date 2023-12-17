using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EngineCategoryController : Controller
    {
        private readonly IEngineCategoryService _engineCategoryService;

        public EngineCategoryController(ILogger<EngineCategoryController> logger ,IEngineCategoryService engineCategoryService) 
        {
            _engineCategoryService = engineCategoryService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<EngineCategoryDto> engineCategoryDtos = _engineCategoryService.GetAll();
            if (!engineCategoryDtos.Any())
                return BadRequest("Список категорий двигателя не найден");

            return Ok(engineCategoryDtos);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            EngineCategoryDto? engineCategoryDto = _engineCategoryService.GetById(id);
            if (engineCategoryDto == null)
                return BadRequest("Категория двигателя не найдена");

            return Ok(engineCategoryDto);
        }
    }
}
