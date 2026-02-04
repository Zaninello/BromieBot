using System.ComponentModel.DataAnnotations;

namespace Models;

public class Todo
{
    [Key]
    public int Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public string? Header { get; set; }
    public string? Description { get; set; }
    public string Status { get; set; } = "pending";

    public Todo(long userId, string header, string description)
        => (UserId, Header, Description) = (userId, header, description);
    public Todo() {}
}
