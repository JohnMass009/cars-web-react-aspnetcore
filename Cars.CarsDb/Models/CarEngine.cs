using System;
using System.Collections.Generic;

namespace Cars.CarsDb.Models;

public partial class CarEngine
{
    public int Id { get; set; }

    public Guid? CarId { get; set; }

    public Guid? EngineId { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Engine? Engine { get; set; }
}
