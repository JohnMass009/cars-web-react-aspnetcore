using System;
using System.Collections.Generic;

namespace Cars.CarsDb.Models;

public partial class StrongPoint
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CarStrongPoint> CarStrongPoints { get; set; } = new List<CarStrongPoint>();
}
