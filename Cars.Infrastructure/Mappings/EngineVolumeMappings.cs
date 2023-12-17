using Cars.CarsDb.Models;
using Cars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.Mappings
{
    public static class EngineVolumeMappings
    {
        public static List<EngineVolumeDto> ToEngineVolumeDtos(this List<EngineVolume> engineVolumes)
            => engineVolumes.Select(e => e.ToEngineVolumeDto()).ToList();

        public static EngineVolumeDto ToEngineVolumeDto(this EngineVolume engineVolume)
        {
            EngineVolumeDto engineVolumeDto = new EngineVolumeDto()
            {
                Id = engineVolume.Id,
                Value = engineVolume.Value,
            };
            return engineVolumeDto;
        }
    }
}
