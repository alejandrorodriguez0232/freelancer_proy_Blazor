using Microsoft.EntityFrameworkCore;
using BlazorRegistroUsuarios.Data.Models;

namespace BlazorRegistroUsuarios.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UsuarioRegistrador> UsuariosRegistradores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones del modelo
            base.OnModelCreating(modelBuilder);
            
            // Agrega configuraciones específicas aquí
            modelBuilder.Entity<UsuarioRegistrador>()
                .HasIndex(u => u.NumeroDocumento)
                .IsUnique();
                
            modelBuilder.Entity<UsuarioRegistrador>()
                .HasIndex(u => u.Correo)
                .IsUnique();
                
            modelBuilder.Entity<UsuarioRegistrador>()
                .Property(u => u.FechaRegistro)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}