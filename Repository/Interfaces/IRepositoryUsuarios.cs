using AbarrotesHogar.Models;
namespace AbarrotesHogar.Repository.Interfaces;
public interface IRepositoryUsuarios
{
    void CrearUsuario(Usuarios usuarios);
    Usuarios? BuscarUsuarioPorId(int id);
    List<Usuarios> ListarTodosUsuarios();
    List<Usuarios> ListarTodosUsuariosEliminados();
    Task<Usuarios> ActualizarUsuariosAsync(Usuarios usuarios);
    bool EliminarUsuarioPorId(int id);
    //void AutenticarUsuario(string usuario,string contraseña);
}