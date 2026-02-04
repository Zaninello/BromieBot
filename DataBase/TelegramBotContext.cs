using Microsoft.EntityFrameworkCore;
using Models;

namespace DataBase;

public class TelegramBotContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("conn");
    }
}
