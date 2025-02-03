using System;
using System.Collections.Generic;

namespace NewAutoCenter.Entities;

public partial class CarInMagazine
{
    public int Id { get; set; }

    public string Mark { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int YearsBorn { get; set; }

    public string Price { get; set; } = null!;

    public string Quentity { get; set; } = null!;
}
