using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Domain.Models;

namespace Cars.Infrastructure.Interfaces
{
    public interface ICar
    {
        public List<CarDto>? GetAll();
    }
}
