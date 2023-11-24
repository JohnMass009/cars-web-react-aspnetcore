using System;
using System.Collections.Generic;

namespace Cars.CarsDb.Models;

public partial class Guide
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }
}
