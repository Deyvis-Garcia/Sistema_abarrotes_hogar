using AbarrotesHogar.Data;
using AbarrotesHogar.Models;
using AbarrotesHogar.Repository.Interfaces;

namespace AbarrotesHogar.Repository;
public class RepositoryCompras : IRepositoryCompras
{
    public readonly AppDbContext _context;
    public RepositoryCompras(AppDbContext context)
    {
        _context = context;
    }
    public void CrearCompra(Compras compras)
    {
        _context.Compras.Add(compras);
        _context.SaveChanges();
    }
    public Compras? BuscarCompraPorId(int id)
    {
        return _context.Compras.Find(id);
    }
    public List<Compras> ListarTodos()
    {
        return _context.Compras.ToList();
    }
    public async Task<Compras> ActualizarComprasAsync(Compras compras)
    {
        _context.Compras.Update(compras);
        await _context.SaveChangesAsync();
        return compras;
    }
    public bool EliminarCompraPorId(int id)
    {
        Compras? compras = BuscarCompraPorId(id);
        if(compras == null)
        {
            return false;
        }
        _context.Compras.Remove(compras);
        _context.SaveChanges();
        return true;
    }
}

