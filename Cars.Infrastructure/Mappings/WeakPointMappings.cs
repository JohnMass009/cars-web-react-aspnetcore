using Cars.CarsDb.Models;
using Cars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.Mappings
{
    public static class WeakPointMappings
    {
        public static List<WeakPointDto> ToWeakPointDtos(this List<WeakPoint> weakPoints)
            => weakPoints.Select(w => w.ToWeakPointDto()).ToList();

        public static WeakPointDto ToWeakPointDto(this WeakPoint weakPoint)
        {
            WeakPointDto weakPointDto = new WeakPointDto()
            {
                Id = weakPoint.Id,
                Name = weakPoint.Name,
            };
            return weakPointDto;
        }
    }
}
