using AbarrotesHogar.Data;
using AbarrotesHogar.Models;
using AbarrotesHogar.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AbarrotesHogar.Repository;
public class RepositoryUsuarios : IRepositoryUsuarios
{
    public readonly AppDbContext _context;
    public RepositoryUsuarios(AppDbContext context)
    {
        _context = context;
    }
    public void CrearUsuario(Usuarios usuarios)
    {
        _context.Usuarios.Add(usuarios);
        _context.SaveChanges();
    }
    public Usuarios? BuscarUsuarioPorId(int id)
    {
        return _context.Usuarios.Find(id);
    }
    public List<Usuarios> ListarTodosUsuarios()
    {
        return _context.Usuarios.ToList();
    }
    public List<Usuarios> ListarTodosUsuariosEliminados()
    {
        return _context.Usuarios.IgnoreQueryFilters().Where(u => !u.Estado).ToList();
    }
    public async Task<Usuarios> ActualizarUsuariosAsync(Usuarios usuarios)
    {
        _context.Usuarios.Update(usuarios);
        await _context.SaveChangesAsync();
        return usuarios;
    }
    public bool EliminarUsuarioPorId(int id)
    {
        Usuarios? usuarios = BuscarUsuarioPorId(id);
        if( usuarios == null)
        {
            return false;
        }
        usuarios.Estado = false;
        _context.Usuarios.Update(usuarios);
        _context.SaveChanges();
        return true;
    }
}