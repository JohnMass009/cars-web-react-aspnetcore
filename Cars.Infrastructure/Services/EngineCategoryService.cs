using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.CarsDb.Context;
using Cars.CarsDb.Models;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infrastructure.Mappings;

namespace Cars.Infrastructure.Services
{
    public class EngineCategoryService : IEngineCategoryService
    {
        CarsDbContext db;

        public EngineCategoryService(CarsDbContext db)
        {
            this.db = db;
        }

        public List<EngineCategoryDto> GetAll()
        {
            List<EngineCategory> engineCategories = db.EngineCategories.ToList();
            if (engineCategories == null)
                return new List<EngineCategoryDto>();

            return engineCategories.ToEngineCaegoryDtos();
        }

        public EngineCategoryDto? GetById(int id)
        {
            EngineCategory? engineCategory = db.EngineCategories.Where(e => e.Id == id).FirstOrDefault();
            if (engineCategory == null)
                return null;
            return engineCategory.ToEngineCategory();
        }
    }
}
