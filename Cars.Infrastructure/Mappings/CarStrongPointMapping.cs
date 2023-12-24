using Cars.CarsDb.Models;
using Cars.Domain.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.Mappings
{
    public static class CarStrongPointMapping
    {
        public static CarStrongPointReadDto ToCarStrongPointDto(this CarStrongPoint carStrongPoint)
        {
            CarStrongPointReadDto carStrongPointDto = new CarStrongPointReadDto()
            {
                Id = carStrongPoint.Id,
                Car = carStrongPoint.Car != null ? carStrongPoint.Car.ToCarDto() : null,
                
                /// QUE: пришлось избавиться от null reference с помощью mappings, по другому не выходило
                //Car = new CarDto()
                //{
                //    Id = carStrongPoint.Car.Id,
                //    Name = carStrongPoint.Car.Name,
                //    CarCategory = carStrongPoint.Car.CarCategory != null ? carStrongPoint.Car.CarCategory.ToCarCategoryDto() : null,
                    
                //},
                StrongPoint = carStrongPoint.StrongPoint != null ? carStrongPoint.StrongPoint.ToStrongPointDto() : null,
            };
            return carStrongPointDto;
        }
    }
}
