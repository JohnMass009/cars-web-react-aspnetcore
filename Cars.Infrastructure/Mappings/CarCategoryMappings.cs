using Cars.CarsDb.Models;
using Cars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.Mappings
{
    public static class CarCategoryMappings
    {
        public static List<CarCategoryDto> ToCarCategoryDtos(this List<CarCategory> listCars)
            => listCars.Select(c => c.ToCarCategoryDto()).ToList();

        public static CarCategoryDto ToCarCategoryDto(this CarCategory carCategory) 
        {
            CarCategoryDto carCategoryDto = new CarCategoryDto
            {
                Id = carCategory.Id,
                Name = carCategory.Name,
            };
            return carCategoryDto;
        }
    }
}
