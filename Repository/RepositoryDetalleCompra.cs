using AbarrotesHogar.Data;
using AbarrotesHogar.Models;
using AbarrotesHogar.Repository.Interfaces;

namespace AbarrotesHogar.Repository;
public class RepositoryDetalleCompra : IRepositoryDetalleCompra
{
    public readonly AppDbContext _context;
    public RepositoryDetalleCompra(AppDbContext context)
    {
        _context = context;
    }
    public void CrearDetalleCompra(DetalleCompras detalleCompras)
    {
        _context.DetalleCompras.Add(detalleCompras);
        _context.SaveChanges();
    }
    public DetalleCompras? BusacarDetalleCompraPorId(int id)
    {
        return _context.DetalleCompras.Find(id);
    }
    public List<DetalleCompras> ListarTodosDetalleCompra()
    {
        return _context.DetalleCompras.ToList();
    }
    public async Task<DetalleCompras> ActualizarDetalleComprasAsync(DetalleCompras detalleCompras)
    {
        _context.DetalleCompras.Update(detalleCompras);
        await _context.SaveChangesAsync();
        return detalleCompras;
    }
    public bool EliminarDetalleComprasPorId(int id)
    {
        DetalleCompras? detalleCompras = BusacarDetalleCompraPorId(id);
        if(detalleCompras == null)
        {
            return false;
        }
        _context.DetalleCompras.Remove(detalleCompras);
        _context.SaveChanges();
        return true;
    }
}