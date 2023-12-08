using System;
using System.Collections.Generic;

namespace Cars.CarsDb.Models;

public partial class Car
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int? CarCategoryId { get; set; }

    public virtual ICollection<CarBadMatchup> CarBadMatchupBads { get; set; } = new List<CarBadMatchup>();

    public virtual ICollection<CarBadMatchup> CarBadMatchupCars { get; set; } = new List<CarBadMatchup>();

    public virtual CarCategory? CarCategory { get; set; }

    public virtual ICollection<CarEngine> CarEngines { get; set; } = new List<CarEngine>();

    public virtual ICollection<CarGoodMatchup> CarGoodMatchupCars { get; set; } = new List<CarGoodMatchup>();

    public virtual ICollection<CarGoodMatchup> CarGoodMatchupGoods { get; set; } = new List<CarGoodMatchup>();

    public virtual ICollection<CarStrongPoint> CarStrongPoints { get; set; } = new List<CarStrongPoint>();

    public virtual ICollection<CarWeakPoint> CarWeakPoints { get; set; } = new List<CarWeakPoint>();
}
