using Cars.CarsDb.Models;
using Cars.Domain.Models;

namespace Cars.Infrastructure.Mappings
{
    public static class CarMappings
    {
        public static List<CarDto> ToCarDtos(this List<Car> listCars)
            => listCars.Select(c => c.ToCarDto()).ToList(); /// замена foreach, чтобы его не писать по несколько раз в коде при конвертации DTO

        public static CarDto ToCarDto(this Car car)
        {
            CarDto carDto = new CarDto()
            {
                Id = car.Id,
                Name = car.Name,
                CarCategory = car.CarCategory != null ? car.CarCategory.ToCarCategoryDto() : null, /// условие, в котором идет проверка CarCategory на null 
                /// и если !null - конвертируем в CarCategoryDto
            };
            return carDto;
        }
    }
}
