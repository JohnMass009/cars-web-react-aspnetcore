using System;
using System.Collections.Generic;

namespace Cars.CarsDb.Models;

public partial class Car
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int? CategoryCarId { get; set; }

    public virtual ICollection<CarEngine> CarEngines { get; set; } = new List<CarEngine>();

    public virtual ICollection<CarStrongPoint> CarStrongPoints { get; set; } = new List<CarStrongPoint>();

    public virtual ICollection<CarWeakPoint> CarWeakPoints { get; set; } = new List<CarWeakPoint>();

    public virtual CategoryCar? CategoryCar { get; set; }

    public virtual ICollection<MatchupCar> MatchupCarBads { get; set; } = new List<MatchupCar>();

    public virtual ICollection<MatchupCar> MatchupCarGoods { get; set; } = new List<MatchupCar>();
}
