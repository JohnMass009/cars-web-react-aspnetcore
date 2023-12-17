using Cars.CarsDb.Context;
using Cars.CarsDb.Models;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.Services
{
    public class EngineVolumeService : IEngineVolumeService
    {
        CarsDbContext db;

        public EngineVolumeService(CarsDbContext db) 
        {
            this.db = db;
        }

        public List<EngineVolumeDto> GetAll()
        {
            List<EngineVolume> engineVolumes = db.EngineVolumes.ToList();
            if(engineVolumes == null)
                return new List<EngineVolumeDto>();

            return engineVolumes.ToEngineVolumeDtos();
        }

        public EngineVolumeDto? GetById(int id)
        {
            EngineVolume? engineVolume = db.EngineVolumes.Where(e => e.Id == id).FirstOrDefault();
            if (engineVolume == null)
                return null;

            return engineVolume.ToEngineVolumeDto();
        }
    }
}
