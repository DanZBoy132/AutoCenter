using System;
using System.Collections.Generic;

namespace NewAutoCenter;

public partial class CarInUsing
{
    public int Id { get; set; }

    public string Mark { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int YearsUsing { get; set; }
}
