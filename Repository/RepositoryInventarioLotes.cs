using AbarrotesHogar.Data;
using AbarrotesHogar.Models;
using AbarrotesHogar.Repository.Interfaces;

namespace AbarrotesHogar.Repository;
public class RepositoryInventarioLotes : IRepositoryInventarioLotes
{
    public readonly AppDbContext _context;
    public RepositoryInventarioLotes(AppDbContext context)
    {
        _context = context;
    }
    public void CrearInventarioLotes(InventarioLotes inventarioLotes)
    {
        _context.InventarioLotes.Add(inventarioLotes);
        _context.SaveChanges();
    }
    public InventarioLotes? BuscarInventarioLotesPorId(int id)
    {
        return _context.InventarioLotes.Find(id);
    }
    public List<InventarioLotes> ListarTodosInventarioLotes()
    {
        return _context.InventarioLotes.ToList();
    }
    public async Task<InventarioLotes> ActualizarInventarioLotesAsync(InventarioLotes inventarioLotes)
    {
        _context.InventarioLotes.Update(inventarioLotes);
        await _context.SaveChangesAsync();
        return inventarioLotes;
    }
    public bool EliminarInventarioLotesPorId(int id)
    {
        InventarioLotes? inventario = BuscarInventarioLotesPorId(id);
        if(inventario == null)
        {
            return false;
        }
        _context.InventarioLotes.Remove(inventario);
        _context.SaveChanges();
        return true;
    }
}