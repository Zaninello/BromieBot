using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Todo
{
    [Key]
    public int Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public string? Header { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
}
