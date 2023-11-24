using System;
using System.Collections.Generic;

namespace Cars.CarsDb.Models;

public partial class MatchupCar
{
    public int Id { get; set; }

    public Guid? GoodId { get; set; }

    public Guid? BadId { get; set; }

    public virtual Car? Bad { get; set; }

    public virtual Car? Good { get; set; }
}
