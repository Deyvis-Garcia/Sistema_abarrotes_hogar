using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;

namespace AbarrotesHogar.Services.Interfaces;
public interface IServicesUsuarios
{
    UsuariosResponse CrearUsuario(UsuariosRequest request);
    UsuariosResponse? BuscarUsuarioPorId(int id);
    List<UsuariosResponse> ListarTodosUsuarios();
    List<UsuariosResponse> ListarTodosUsuariosEliminados();
    Task<UsuariosResponse> ActualizarUsuariosAsync(int id,UsuariosRequest usuariosRequest);
    bool EliminarUsuarioPorId(int id);    
}
