using System;
using System.Collections.Generic;

namespace NewAutoCenter;

public partial class User
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? Cash { get; set; }
}
