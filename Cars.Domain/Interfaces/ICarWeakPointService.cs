using Cars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Interfaces
{
    public interface ICarWeakPointService
    {
        public List<WeakPointDto> GetAllWeakPointsByCarId(Guid carId);

        public CarWeakPointReadDto? GetCarWeakPointDtoById(int id);

        public int CreateCarWeakPointById(CarWeakPointWriteDto carWeakPointDto);

        public int? DeleteCarWeakPointById(int id);
    }
}
