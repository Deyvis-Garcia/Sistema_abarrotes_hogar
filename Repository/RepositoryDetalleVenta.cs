using AbarrotesHogar.Data;
using AbarrotesHogar.Models;
using AbarrotesHogar.Repository.Interfaces;

namespace AbarrotesHogar.Repository;
public class RepositoryDetalleVenta : IRepositoryDetalleVenta
{
    public readonly AppDbContext _context;
    public RepositoryDetalleVenta(AppDbContext context)
    {
        _context = context;
    }
    public void CrearDetalleVenta(DetalleVenta detalleVenta)
    {
        _context.DetalleVentas.Add(detalleVenta);
        _context.SaveChanges();
    }
    public DetalleVenta? BuscarDetalleVentaPorId(int id)
    {
        return _context.DetalleVentas.Find(id);
    }
    public List<DetalleVenta> ListarTodosDetalleVenta()
    {
        return _context.DetalleVentas.ToList();
    }
    public async Task<DetalleVenta> ActualizarDetalleVentaAsync(DetalleVenta detalleVenta)
    {
        _context.DetalleVentas.Update(detalleVenta);
        await _context.SaveChangesAsync();
        return detalleVenta;
    }
    public bool EliminarDetalleVentaPorId(int id)
    {
        DetalleVenta? detalleVenta = BuscarDetalleVentaPorId(id);
        if(detalleVenta == null)
        {
            return false;
        }
        _context.DetalleVentas.Remove(detalleVenta);
        _context.SaveChanges();
        return true;
    }
}