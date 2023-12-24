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

        private CarStrongPoint? GetCarStrongPointEntryById(int id)
        {
            CarStrongPoint? carStrongPoint = db.CarStrongPoints.
                Where(c => c.Id == id).
                Include(c => c.Car).
                Include(c => c.StrongPoint).
                FirstOrDefault();

            if (carStrongPoint == null)
                return null;

            return carStrongPoint;
        }

        public List<StrongPointDto> GetAllStrongPointsByCarId(Guid carId)
        {
            List<StrongPoint>? strongPoints = db.CarStrongPoints.
                Where(s => s.CarId == carId && s.StrongPointId != null). // этим выражением успокаиваем логику
                Include(s => s.Car!). /// QUE: снова watning был ниже, решил исправить знаком !
                ThenInclude(c => c.CarCategory).
                Include(s => s.StrongPoint).
                Select(s => s.StrongPoint!). // знаком ! успокаиваем Visual Studio
                ToList(); /// QUE: warning! null reference

            if(strongPoints == null)
                return new List<StrongPointDto>();

            return strongPoints.ToStrongPointDtos();
        }
        
        /// написать метод GetCarStrongPointByCarId по новой созданной записи CarStrongPoint
        public CarStrongPointReadDto? GetCarStrongPointDtoById(int id)
        {
            var carStrongPoint = GetCarStrongPointEntryById(id);
            if (carStrongPoint == null)
                return null;

            return carStrongPoint.ToCarStrongPointDto();
        }

        public int CreateCarStrongPointById(CarStrongPointWriteDto carStrongPointDto) /// вернуть id новой записи вместо CarStrongPointDto
        {
            CarStrongPoint carStrongPoint = new CarStrongPoint()
            { 
                CarId = carStrongPointDto.CarId,
                StrongPointId = carStrongPointDto.StrongPointId,
            };
            db.CarStrongPoints.Add(carStrongPoint);
            db.SaveChanges();
            return carStrongPoint.Id;
        }

        public int? DeleteCarStrongPointById(int id)
        {
            CarStrongPoint? deletedEntry = GetCarStrongPointEntryById(id);
            if (deletedEntry == null)
                return null;

            db.CarStrongPoints.Remove(deletedEntry);
            db.SaveChanges();
            return deletedEntry.Id;
        }
    }
}
