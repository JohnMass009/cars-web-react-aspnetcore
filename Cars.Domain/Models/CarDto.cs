using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Models
{
    public class CarDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public int? CategoryCarId { get; set; }
    }
}
