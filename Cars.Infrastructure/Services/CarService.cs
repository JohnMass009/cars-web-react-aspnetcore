using Cars.CarsDb.Context;
using Cars.CarsDb.Models;
using Cars.Domain.Models;
using Cars.Domain.Interfaces;
using Cars.Infrastructure.Mappings;


namespace Cars.Infrastructure.Services
{
    public class CarService : ICarService
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
                CarDto carDto = car.ToCarDto();
                carsListDto.Add(carDto);
            }
            return carsListDto;
        }
    }
}
