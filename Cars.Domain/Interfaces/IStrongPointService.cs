using Cars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Interfaces
{
    public interface IStrongPointService
    {
        public List<StrongPointDto> GetAll();
        public StrongPointDto? GetById(int id);
    }
}
