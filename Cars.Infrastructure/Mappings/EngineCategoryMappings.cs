using Cars.CarsDb.Models;
using Cars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.Mappings
{
    public static class EngineCategoryMappings
    {
        public static List<EngineCategoryDto> ToEngineCaegoryDtos(this List<EngineCategory> engineCategories)
            => engineCategories.Select(e => e.ToEngineCategory()).ToList();

        public static EngineCategoryDto ToEngineCategory(this EngineCategory engineCategory)
        {
            EngineCategoryDto engineCategoryDto = new EngineCategoryDto()
            {
                Id = engineCategory.Id,
                Name = engineCategory.Name,
            };
            return engineCategoryDto;
        }
    }
}
