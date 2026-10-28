using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Repository.Interfaces;
using AbarrotesHogar.Services.Interfaces;
using AbarrotesHogar.Models;
using AbarrotesHogar.Excepciones;

namespace AbarrotesHogar.Services;
public class ServicesUsuarios : IServicesUsuarios
{
    public readonly IRepositoryUsuarios _repositoryUsuarios;
    public ServicesUsuarios(IRepositoryUsuarios repositoryUsuarios)
    {
        _repositoryUsuarios = repositoryUsuarios;
    }
    public UsuariosResponse CrearUsuario(UsuariosRequest usuariosRequest)
    {
        Usuarios nuevoUsuario = new Usuarios
        {
            Nombre = usuariosRequest.Nombre,
            Apellido = usuariosRequest.Apellido,
            Usuario = usuariosRequest.Usuario,
            Contraseña = usuariosRequest.Contraseña,
            rol = usuariosRequest.rol
        };
        _repositoryUsuarios.CrearUsuario(nuevoUsuario);
        UsuariosResponse usuariosResponse = new UsuariosResponse
        {
            Id_usuario = nuevoUsuario.Id_usuario,
            Nombre = nuevoUsuario.Nombre,
            Apellido = nuevoUsuario.Apellido,
            Usuario = nuevoUsuario.Usuario,
            Contraseña = nuevoUsuario.Contraseña,
            rol = nuevoUsuario.rol,
            Estado = nuevoUsuario.Estado
        };
        return usuariosResponse;
    }
    public UsuariosResponse? BuscarUsuarioPorId(int id)
    {
        Usuarios? usuarioExistente = _repositoryUsuarios.BuscarUsuarioPorId(id);
        if( usuarioExistente == null){throw new RecursoNoEncontradoException($"No se encontro el usuario con el ID: {id}");}
        return new UsuariosResponse
        {
            Id_usuario = usuarioExistente.Id_usuario,
            Nombre = usuarioExistente.Nombre,
            Apellido = usuarioExistente.Apellido,
            Usuario = usuarioExistente.Usuario,
            Contraseña = usuarioExistente.Contraseña,
            rol = usuarioExistente.rol,
            Estado = usuarioExistente.Estado
        };
    }
    public List<UsuariosResponse> ListarTodosUsuarios()
    {
        List<Usuarios> usuarios = _repositoryUsuarios.ListarTodosUsuarios();
        return usuarios.Select(u => new UsuariosResponse
        {
            Id_usuario = u.Id_usuario,
            Nombre = u.Nombre,
            Apellido = u.Apellido,
            Usuario = u.Usuario,
            Contraseña = u.Contraseña,
            rol = u.rol,
            Estado = u.Estado
        }).ToList();
    }
    public List<UsuariosResponse> ListarTodosUsuariosEliminados()
    {
        List<Usuarios> usuariosEliminados = _repositoryUsuarios.ListarTodosUsuariosEliminados();
        return usuariosEliminados.Select(u => new UsuariosResponse
        {
            Id_usuario = u.Id_usuario,
            Nombre = u.Nombre,
            Apellido = u.Apellido,
            Usuario = u.Usuario,
            Contraseña = u.Contraseña,
            rol = u.rol,
            Estado = u.Estado
        }).ToList();
    }
    public async Task<UsuariosResponse> ActualizarUsuariosAsync(int id,UsuariosRequest usuariosRequest)
    {
        Usuarios? usuarioExistente = _repositoryUsuarios.BuscarUsuarioPorId(id);
        if( usuarioExistente == null){throw new RecursoNoEncontradoException($"No se encontro el usuario con el ID: {id}");}
        usuarioExistente.Nombre = usuariosRequest.Nombre;
        usuarioExistente.Apellido = usuariosRequest.Apellido;
        usuarioExistente.Usuario = usuariosRequest.Usuario;
        usuarioExistente.Contraseña = usuariosRequest.Contraseña;
        usuarioExistente.rol = usuariosRequest.rol;
        usuarioExistente.Estado = usuariosRequest.Estado;
        await _repositoryUsuarios.ActualizarUsuariosAsync(usuarioExistente);
        return new UsuariosResponse
        {
            Id_usuario = usuarioExistente.Id_usuario,
            Nombre = usuarioExistente.Nombre,
            Apellido = usuarioExistente.Apellido,
            Usuario = usuarioExistente.Usuario,
            Contraseña = usuarioExistente.Contraseña,
            rol = usuarioExistente.rol,
            Estado = usuarioExistente.Estado
        };
    }
    public bool EliminarUsuarioPorId(int id)
    {
        Usuarios? usuarioExistente = _repositoryUsuarios.BuscarUsuarioPorId(id);
        if( usuarioExistente == null){throw new RecursoNoEncontradoException($"No se encontro el usuario con el ID: {id}");}
        return _repositoryUsuarios.EliminarUsuarioPorId(id);
    }
}