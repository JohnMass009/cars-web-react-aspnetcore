using System;
using System.Collections.Generic;

namespace Cars.CarsDb.Models;

public partial class CarGoodMatchup
{
    public Guid Id { get; set; }

    public Guid? CarId { get; set; }

    public Guid? GoodId { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Car? Good { get; set; }
}
