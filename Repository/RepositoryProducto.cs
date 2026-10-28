using AbarrotesHogar.Data;
using AbarrotesHogar.Models;
using AbarrotesHogar.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AbarrotesHogar.Repository;
public class RepositoryProductos : IRepositoryProductos
{
    public readonly AppDbContext _context;
    public RepositoryProductos(AppDbContext context)
    {
        _context = context;
    }
    public void CrearProductos(Productos productos)
    {
        _context.Productos.Add(productos);
        _context.SaveChanges();
    }
    public Productos? BuscarProductoPorId(int id)
    {
        return _context.Productos.Find(id);
    }
    public List<Productos> ListarTodosProductos()
    {
        return _context.Productos.ToList();
    }
    public List<Productos> ListarTodosProductosEliminados()
    {
        return _context.Productos.IgnoreQueryFilters().Where(p => !p.Estado).ToList();
    }
    public async Task<Productos> ActualizarProductosAsync(Productos productos)
    {
        _context.Productos.Update(productos);
        await _context.SaveChangesAsync();
        return productos;
    }
    public bool EliminarProductosPorId(int id)
    {
        Productos? productos = BuscarProductoPorId(id);
        if(productos == null)
        {
            return false;
        }
        productos.Estado = false;
        _context.Productos.Update(productos);
        _context.SaveChanges();
        return true;
    }
}