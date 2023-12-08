using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Models
{
    public class EngineDto
    {
        public Guid Id { get; set; }

        public int? EngineCategoryId { get; set; }

        public int? EngineVolumeId { get; set; }

    }
}
