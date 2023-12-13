using Cars.CarsDb.Models;
using Cars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.Mappings
{
    public static class StrongPointMappings
    {
        public static List<StrongPointDto> ToStrongPointDtos(this List<StrongPoint> strongPoints) 
            => strongPoints.Select(s => s.ToStrongPointDto()).ToList();

        public static StrongPointDto ToStrongPointDto(this StrongPoint strongPoint)
        {
            StrongPointDto strongPointDto = new StrongPointDto()
            {
                Id = strongPoint.Id,
                Name = strongPoint.Name,
            };
            return strongPointDto;
        }
    }
}
