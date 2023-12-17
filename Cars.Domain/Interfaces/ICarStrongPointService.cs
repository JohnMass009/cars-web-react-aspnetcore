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
        public List<StrongPointDto> GetAllByCarId(Guid carId);
    }
}
