using BarberiaJK.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberiaJK.Infrastructure.Context
{
    public class BarberiaContext : DbContext
    {
        public BarberiaContext(DbContextOptions<BarberiaContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Comision> Comisiones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ====== ASIGNAR NOMBRES DE TABLAS 
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Empleado>().ToTable("Empleado");
            modelBuilder.Entity<Servicio>().ToTable("Servicio");
            modelBuilder.Entity<Cita>().ToTable("Cita");
            modelBuilder.Entity<Comision>().ToTable("Comision");

            // ====== CONFIGURACIÓN
            modelBuilder.Entity<Cliente>().HasKey(c => c.IdCliente);
            modelBuilder.Entity<Empleado>().HasKey(e => e.IdEmpleado);
            modelBuilder.Entity<Servicio>().HasKey(s => s.IdServicio);
            modelBuilder.Entity<Cita>().HasKey(c => c.IdCita);
            modelBuilder.Entity<Comision>().HasKey(c => c.IdComision);

            // ====== RELACIONES ============================================================
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Empleado)
                .WithMany()
                .HasForeignKey(c => c.IdEmpleado)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Servicio)
                .WithMany()
                .HasForeignKey(c => c.IdServicio)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comision>()
                .HasOne(c => c.Empleado)
                .WithMany()
                .HasForeignKey(c => c.IdEmpleado);

            modelBuilder.Entity<Comision>()
                .HasOne(c => c.Cita)
                .WithMany()
                .HasForeignKey(c => c.IdCita);
        }
    }
}
