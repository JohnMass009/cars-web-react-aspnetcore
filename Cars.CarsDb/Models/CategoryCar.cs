using System;
using System.Collections.Generic;

namespace Cars.CarsDb.Models;

public partial class CategoryCar
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
