using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Domain.Models;

namespace Cars.Domain.Interfaces
{
    public interface ICarService
    {
        public List<CarDto>? GetAll(); /// поправить
    }
}
