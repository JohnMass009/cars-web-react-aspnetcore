using System;
using System.Collections.Generic;

namespace Cars.CarsDb.Models;

public partial class Engine
{
    public Guid Id { get; set; }

    public int? EngineCategoryId { get; set; }

    public int? EngineVolumeId { get; set; }

    public virtual ICollection<CarEngine> CarEngines { get; set; } = new List<CarEngine>();

    public virtual EngineCategory? EngineCategory { get; set; }

    public virtual EngineVolume? EngineVolume { get; set; }
}
