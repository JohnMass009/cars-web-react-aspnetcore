using System;
using System.Collections.Generic;

namespace Cars.CarsDb.Models;

public partial class WeakPoint
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CarWeakPoint> CarWeakPoints { get; set; } = new List<CarWeakPoint>();
}
