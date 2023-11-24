using System;
using System.Collections.Generic;

namespace Cars.CarsDb.Models;

public partial class CarStrongPoint
{
    public int Id { get; set; }

    public Guid? CarId { get; set; }

    public int? StrongPointId { get; set; }

    public virtual Car? Car { get; set; }

    public virtual StrongPoint? StrongPoint { get; set; }
}
