using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cars.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarCategoryController : Controller
    {
        private readonly ICarCategoryService _carCategoryService;

        public CarCategoryController(ILogger<CarCategoryController> logger, ICarCategoryService carCategoryService) 
        {
            _carCategoryService = carCategoryService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<CarCategoryDto> carCategories = _carCategoryService.GetAll();
            if (!carCategories.Any()) /// Any не работает с null
                return BadRequest("Категория авто не найдена");

            return Ok(carCategories);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var carCategory = _carCategoryService.GetById(id);
            if (carCategory == null)
                return BadRequest("Категория авто не найдена");

            return Ok(carCategory);
        }
    }
}
