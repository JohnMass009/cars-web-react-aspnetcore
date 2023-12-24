using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Models
{
    public class CarWeakPointReadDto
    {
        public int Id { get; set; }

        public CarDto? Car { get; set; } = null!; 

        public WeakPointDto? WeakPoint { get; set; } = null!;
    }
}


