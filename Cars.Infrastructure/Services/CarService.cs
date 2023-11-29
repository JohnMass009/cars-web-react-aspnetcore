using Cars.CarsDb.Context;
using Cars.CarsDb.Models;
using Cars.Domain.Models;
using Cars.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.Services
{
    public class CarService : ICar
    {
        CarsDbContext db;

        public CarService(CarsDbContext db)
        {
            this.db = db;
        }
        public List<CarDto>? GetAll()
        {
            List<Car>? carsList = db.Cars.ToList();
            if (carsList == null)
                return null;

            List<CarDto> carsListDto = new List<CarDto>();
            foreach (Car car in carsList)
            {
                CarDto carDto = ConvertToUserDto(car);
                carsListDto.Add(carDto);
            }
            return carsListDto;
        }

        private CarDto ConvertToUserDto(Car car)
        {
            CarDto carDto = new CarDto()
            {
                Id = car.Id,
                Name = car.Name,
                CategoryCarId = car.CategoryCarId,
            };
            return carDto;
        }
    }
}
