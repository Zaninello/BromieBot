using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BromieBot;

public partial class TelegramBotContex : DbContext
{
    public TelegramBotContex()
    {
    }

    public TelegramBotContex(DbContextOptions<TelegramBotContex> options)
        : base(options)
    {
    }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Bromie;Integrated Security=SSPI;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__log__3214EC07CAF852D2");

            entity.ToTable("log");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdTaskNavigation).WithMany(p => p.Logs)
                .HasForeignKey(d => d.IdTask)
                .HasConstraintName("FK__log__IdTask__3C69FB99");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Logs)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__log__IdUser__3B75D760");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__task__3214EC07B492654D");

            entity.ToTable("task");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Header)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("header");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuário__3214EC071932397A");

            entity.ToTable("usuario");

            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
