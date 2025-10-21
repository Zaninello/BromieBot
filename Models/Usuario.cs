using System;
using System.Collections.Generic;

namespace BromieBot;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
