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
    public class CarWeakPointService : ICarWeakPointService
    {
        CarsDbContext db;

        public CarWeakPointService(CarsDbContext db)
        {
            this.db = db;
        }

        private CarWeakPoint? GetCarWeakPointEntryById(int id)
        {
            CarWeakPoint? carWeakPoint = db.CarWeakPoints.
                Where(c => c.Id == id).
                Include(c => c.Car).
                Include(c => c.WeakPoint).
                FirstOrDefault();

            if (carWeakPoint == null)
                return null;

            return carWeakPoint;
        }

        public List<WeakPointDto> GetAllWeakPointsByCarId(Guid carId)
        {
            List<WeakPoint>? weakPoints = db.CarWeakPoints.
                Where(s => s.CarId == carId && s.WeakPointId != null). // этим выражением успокаиваем логику
                Include(s => s.Car!).
                ThenInclude(c => c.CarCategory).
                Include(s => s.WeakPoint).
                Select(s => s.WeakPoint!). // знаком ! успокаиваем Visual Studio
                ToList();

            if (weakPoints == null)
                return new List<WeakPointDto>();

            return weakPoints.ToWeakPointDtos();
        }

        public CarWeakPointReadDto? GetCarWeakPointDtoById(int id)
        {
            var carWeakPoint = GetCarWeakPointEntryById(id);
            if (carWeakPoint == null)
                return null;

            return carWeakPoint.ToCarWeakPointDto();
        }

        public int CreateCarWeakPointById(CarWeakPointWriteDto carWeakPointDto) /// вернуть id новой записи вместо CarStrongPointDto
        {
            CarWeakPoint carWeakPoint = new CarWeakPoint()
            {
                CarId = carWeakPointDto.CarId,
                WeakPointId = carWeakPointDto.WeakPointId,
            };
            db.CarWeakPoints.Add(carWeakPoint);
            db.SaveChanges();
            return carWeakPoint.Id;
        }

        public int? DeleteCarWeakPointById(int id)
        {
            CarWeakPoint? deletedEntry = GetCarWeakPointEntryById(id);
            if (deletedEntry == null)
                return null;

            db.CarWeakPoints.Remove(deletedEntry);
            db.SaveChanges();
            return deletedEntry.Id;
        }
    }
}
