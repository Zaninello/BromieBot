using System;
using System.Collections.Generic;

namespace BromieBot;

public partial class Task
{
    public int Id { get; set; }

    public string? Header { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
