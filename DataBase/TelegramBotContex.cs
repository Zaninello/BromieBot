using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Models;

namespace DataBase;

public partial class TelegramBotContex : DbContext
{
    
    public DbSet<Todo> Todos { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Bromie;Integrated Security=SSPI;TrustServerCertificate=True");
    }
}
