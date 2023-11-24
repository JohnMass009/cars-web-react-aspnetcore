using System;
using System.Collections.Generic;

namespace Cars.CarsDb.Models;

public partial class CarWeakPoint
{
    public int Id { get; set; }

    public Guid? CarId { get; set; }

    public int? WeakPointId { get; set; }

    public virtual Car? Car { get; set; }

    public virtual WeakPoint? WeakPoint { get; set; }
}
