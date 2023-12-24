using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Models
{
    public class CarStrongPointReadDto
    {
        public int Id { get; set; }

        public CarDto? Car { get; set; } = null!; // выражение чтобы указать что мы знаем про наличие null, но мы берем ответственность на себя и убираем warnings

        public StrongPointDto? StrongPoint { get; set; } = null!;
    }
}
