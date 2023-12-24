using Cars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Interfaces
{
    public interface ICarStrongPointService
    {
        public List<StrongPointDto> GetAllStrongPointsByCarId(Guid carId);

        public int CreateCarStrongPointById(CarStrongPointWriteDto carStrongPointDto); // пробовал сделать void - ругается метод контроллера
        // связи нет по проектам с инфраструктурой, т.к. domain независим от них по принципу DDD.
        public CarStrongPointReadDto? GetCarStrongPointDtoById(int id);

        public int? DeleteCarStrongPointById(int id);
    }
}
