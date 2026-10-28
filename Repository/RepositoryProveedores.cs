using AbarrotesHogar.Data;
using AbarrotesHogar.Models;
using AbarrotesHogar.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AbarrotesHogar.Repository;
public class RepositoryProveedores : IRepositoryProveedores
{
    public readonly AppDbContext _context;
    public RepositoryProveedores( AppDbContext context)
    {
        _context = context;
    }
    public void CrearProveedor(Proveedores proveedores)
    {
        _context.Proveedores.Add(proveedores);
        _context.SaveChanges();
    }
    public Proveedores?  BuscarProveedorPorId(int id)
    {
        return _context.Proveedores.Find(id);
    }
    public List<Proveedores> ListarTodosProvedores()
    {
        return _context.Proveedores.ToList();
    }
    public List<Proveedores> ListarTodosProvedoresEliminados()
    {
        return _context.Proveedores.IgnoreQueryFilters().Where(p => !p.Estado).ToList();
    }
    public async Task<Proveedores> ActualizarProveedoresAsync(Proveedores proveedores)
    {
        _context.Proveedores.Update(proveedores);
        await _context.SaveChangesAsync();
        return proveedores;
    }
    public bool EliminarProveedorePorId(int id)
    {
        Proveedores? proveedores = BuscarProveedorPorId(id);
        if(proveedores == null)
        {
            return false;
        }
        proveedores.Estado = false;
        _context.Proveedores.Update(proveedores);
        _context.SaveChanges();
        return true;
    }
}