using Cars.CarsDb.Context;
using Cars.CarsDb.Models;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.Services
{
    public class CarCategoryService : ICarCategoryService
    {
        CarsDbContext db;

        public CarCategoryService(CarsDbContext db)
        {
            this.db = db;
        }

        public List<CarCategoryDto> GetAll()
        {
            List<CarCategory> carCategories = db.CarCategories.ToList();
            if (carCategories == null)
                return new List<CarCategoryDto>();
            
            return carCategories.ToCarCategoryDtos();
        }

        public CarCategoryDto? GetById(int id) 
        {
            CarCategory? carCategory = db.CarCategories.Where(r => r.Id == id).FirstOrDefault();
            if (carCategory == null)
                return null;

            return carCategory.ToCarCategoryDto();
        }
    }
}
