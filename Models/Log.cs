using System;
using System.Collections.Generic;

namespace BromieBot;

public partial class Log
{
    public int Id { get; set; }

    public int? IdUser { get; set; }

    public int? IdTask { get; set; }

    public virtual Task? IdTaskNavigation { get; set; }

    public virtual Usuario? IdUserNavigation { get; set; }
}
