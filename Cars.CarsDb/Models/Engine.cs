using System;
using System.Collections.Generic;

namespace Cars.CarsDb.Models;

public partial class Engine
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int? CategoryEngineId { get; set; }

    public int? VolumeEngineId { get; set; }

    public virtual ICollection<CarEngine> CarEngines { get; set; } = new List<CarEngine>();

    public virtual CategoryEngine? CategoryEngine { get; set; }

    public virtual VolumeEngine? VolumeEngine { get; set; }
}
