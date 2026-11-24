using AbarrotesHogar.Data;
using AbarrotesHogar.Models;
using AbarrotesHogar.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AbarrotesHogar.Repository;
public class RepositoryVentas : IRepositoryVentas
{
    private readonly AppDbContext _context;
    public RepositoryVentas(AppDbContext context)
    {
        _context = context;
    }
    public void CrearVentas(Ventas ventas)
    {
        _context.Ventas.Add(ventas);
        _context.SaveChanges();
    }
    public Ventas? BuscarVentasPorId(int id)
    {
       return _context.Ventas.Find(id);
    }
    public async Task<(List<Ventas> Datos, int Total)> ListarTodosVentasAsync(int pagina, int tamano)
    {
        IQueryable<Ventas> query = _context.Ventas.AsNoTracking();
        int total = await query.CountAsync();
        List<Ventas> datos = await query.OrderBy(v => v.Id_venta).Skip((pagina - 1) * tamano).Take(tamano).ToListAsync();
        return (datos, total);
    }
    public async Task<Ventas> ActualizarVentasAsync(Ventas ventas)
    {
        _context.Ventas.Update(ventas);
        await _context.SaveChangesAsync();
        return ventas;
    }
    public bool EliminarVentasPorId(int id)
    {
        Ventas? ventas = BuscarVentasPorId(id);
        if(ventas == null)
        {
            return false;
        }
        _context.Ventas.Remove(ventas);
        _context.SaveChanges();
        return true;
    }
}