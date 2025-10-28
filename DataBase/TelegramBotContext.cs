using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Models;

namespace DataBase;

public partial class TelegramBotContext : DbContext
{
    
    public DbSet<Todo> Todos { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=taylors42.com.br,1433;Initial Catalog=Bromie;Persist Security Info=False;User ID=sa;Password=SuaSenhaForte123!;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Command Timeout=30");
    }
}
