using AbarrotesHogar.Data;
using AbarrotesHogar.Models;
using AbarrotesHogar.Repository.Interfaces;

namespace AbarrotesHogar.Repository;
public class RepositoryVentas : IRepositoryVentas
{
    public readonly AppDbContext _context;
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
    public List<Ventas> ListarTodosVentas()
    {
        return _context.Ventas.ToList();
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