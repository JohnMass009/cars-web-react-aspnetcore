using System;
using System.Collections.Generic;

namespace Cars.CarsDb.Models;

public partial class CarBadMatchup
{
    public Guid Id { get; set; }

    public Guid? CarId { get; set; }

    public Guid? BadId { get; set; }

    public virtual Car? Bad { get; set; }

    public virtual Car? Car { get; set; }
}
