using System;
using System.Collections.Generic;

namespace Cars.CarsDb.Models;

public partial class EngineCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Engine> Engines { get; set; } = new List<Engine>();
}
