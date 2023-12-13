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
    public class StrongPointService : IStrongPointService
    {
        CarsDbContext db;
        public StrongPointService(CarsDbContext db)
        {
            this.db = db;
        }

        public List<StrongPointDto> GetAll()
        {
            List<StrongPoint> strongPoints = db.StrongPoints.ToList();
            if(strongPoints == null)
                return new List<StrongPointDto>();

            return strongPoints.ToStrongPointDtos();
        }
        public StrongPointDto? GetById(int id)
        {
            StrongPoint? strongPoint = db.StrongPoints.Where(x => x.Id == id).FirstOrDefault();
            if (strongPoint == null)
                return null;

            return strongPoint.ToStrongPointDto();
        }
    }
}
