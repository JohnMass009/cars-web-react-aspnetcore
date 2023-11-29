using Cars.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cars.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        ICar iCar;
        public CarController(ILogger<CarController> logger, ICar iCar) 
        {
            this.iCar = iCar;
        }

        [HttpGet()]
        public ActionResult Get()
        {
            return Ok(iCar.GetAll());
        }
    }
}
