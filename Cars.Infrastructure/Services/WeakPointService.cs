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
    public class WeakPointService : IWeakPointService
    {
        CarsDbContext db;

        public WeakPointService(CarsDbContext db)
        {
            this.db = db;
        }

        public List<WeakPointDto> GetAll()
        {
            List<WeakPoint> weakPoints = db.WeakPoints.ToList();
            if (!weakPoints.Any())
                return new List<WeakPointDto>();

            return weakPoints.ToWeakPointDtos();
        }

        public WeakPointDto? GetById(int id)
        {
            WeakPoint? weakPoint = db.WeakPoints.Where(w => w.Id == id).FirstOrDefault();
            if (weakPoint == null)
                return null;

            return weakPoint.ToWeakPointDto();
        }
    }
}
