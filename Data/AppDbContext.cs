using Microsoft.EntityFrameworkCore;
using AbarrotesHogar.Models;
namespace AbarrotesHogar.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    public DbSet<Compras> Compras{get;set;}
    public DbSet<DetalleCompras> DetalleCompras{get;set;}
    public DbSet<DetalleVenta> DetalleVentas{get;set;}
    public DbSet<InventarioLotes> InventarioLotes{get;set;}
    public DbSet<Productos> Productos{get;set;}
    public DbSet<Proveedores> Proveedores{get;set;}
    public DbSet<Usuarios> Usuarios{get;set;}
    public DbSet<Ventas> Ventas{get;set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.Entity<Productos>().HasQueryFilter(p => p.Estado == true);
        modelBuilder.Entity<Usuarios>().HasQueryFilter(u => u.Estado == true);
        modelBuilder.Entity<InventarioLotes>().HasQueryFilter(l => l.Estado == true);
    }
}