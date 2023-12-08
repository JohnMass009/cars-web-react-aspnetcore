using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Domain.Models;

namespace Cars.Domain.Interfaces
{
    public interface ICarCategoryService
    {
        public List<CarCategoryDto> GetAll(); /// в интерфейсах лучше убирать ? с листов и возвращать пустой экземпляр листа (если с БД возвращается null)

        public CarCategoryDto? GetById(int id);
    }
}
