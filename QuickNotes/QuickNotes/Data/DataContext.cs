using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuickNotes.Models;

namespace QuickNotes.Data
{
    public class DataContext : DbContext
        {
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {
            }

            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Nota> Notas { get; set; }
            public DbSet<Cuaderno> Cuadernos { get; set; }
            public DbSet<ActividadUsuario> ActiviadadUsuarios { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Usuario>().ToTable("Usuario");
                modelBuilder.Entity<Nota>().ToTable("Nota");
                modelBuilder.Entity<Cuaderno>().ToTable("Cuaderno");
                modelBuilder.Entity<Cuaderno>().ToTable("ActividadUsuario");
        }
    }
    
}
