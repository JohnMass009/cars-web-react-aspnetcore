using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Models
{
    public class CarStrongPointWriteDto
    {
        public Guid CarId { get; set; }

        public int StrongPointId { get; set; }
    }
}
