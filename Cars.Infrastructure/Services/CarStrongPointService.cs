using Cars.CarsDb.Context;
using Cars.CarsDb.Models;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.Services
{
    public class CarStrongPointService : ICarStrongPointService
    {
        CarsDbContext db;

        public CarStrongPointService(CarsDbContext db) 
        {
            this.db = db;
        }

        public List<StrongPointDto> GetAllByCarId(Guid carId)
        {
            List<StrongPoint> strongPoints = db.CarStrongPoints.Where(s => s.CarId == carId).Include(s => s.Car).Include(c => c.StrongPoint).Select(s => s.StrongPoint).ToList()!; /// QUE: warning! null reference
            if(!strongPoints.Any())
                return new List<StrongPointDto>();

            return strongPoints.ToStrongPointDtos();
        }
        
        //public static void EditCarStrongPoint(IStrongPointService _strongPointService, StrongPointDto strongPointDto)
        //{
        //    List<StrongPointDto> strongPointDtos = _strongPointService.GetAll();
        //    if(!strongPointDtos.Any())
        //        return;

            
        //}
    }
}
