using System;
using System.Collections.Generic;

namespace DBFirstNeat.Models;

public partial class Dept
{
    public int DeptNo { get; set; }

    public string Dname { get; set; } = null!;

    public string Loc { get; set; } = null!;
}
