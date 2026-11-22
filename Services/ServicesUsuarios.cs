using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Excepciones;
using AbarrotesHogar.Models;
using AbarrotesHogar.Repository.Interfaces;
using AbarrotesHogar.Services.Interfaces;

namespace AbarrotesHogar.Services;

public class ServicesUsuarios : IServicesUsuarios
{
    private readonly IRepositoryUsuarios _repositoryUsuarios;

    public ServicesUsuarios(IRepositoryUsuarios repositoryUsuarios)
    {
        _repositoryUsuarios = repositoryUsuarios;
    }

    public UsuariosResponse CrearUsuario(UsuariosRequest usuariosRequest)
    {
        if (string.IsNullOrWhiteSpace(usuariosRequest.Usuario) || string.IsNullOrWhiteSpace(usuariosRequest.Contraseña))
        {
            throw new ArgumentException("El usuario y la contraseña son obligatorios.");
        }

        Usuarios? existente = _repositoryUsuarios.BuscarPorNombreUsuario(usuariosRequest.Usuario);
        if (existente != null)
        {
            throw new ConflictoException($"Ya existe un usuario registrado con el nombre '{usuariosRequest.Usuario}'.");
        }

        Usuarios nuevoUsuario = new Usuarios
        {
            Nombre = usuariosRequest.Nombre,
            Apellido = usuariosRequest.Apellido,
            Usuario = usuariosRequest.Usuario,
            Contraseña = BCrypt.Net.BCrypt.HashPassword(usuariosRequest.Contraseña),
            rol = usuariosRequest.rol,
            Estado = true
        };

        _repositoryUsuarios.CrearUsuario(nuevoUsuario);
        return MapearAResponse(nuevoUsuario);
    }

    public UsuariosResponse? BuscarUsuarioPorId(int id)
    {
        Usuarios? usuarioExistente = _repositoryUsuarios.BuscarUsuarioPorId(id);
        if (usuarioExistente == null)
        {
            throw new RecursoNoEncontradoException($"No se encontro el usuario con el ID: {id}");
        }

        return MapearAResponse(usuarioExistente);
    }

    public List<UsuariosResponse> ListarTodosUsuarios()
    {
        return _repositoryUsuarios.ListarTodosUsuarios().Select(MapearAResponse).ToList();
    }

    public List<UsuariosResponse> ListarTodosUsuariosEliminados()
    {
        return _repositoryUsuarios.ListarTodosUsuariosEliminados()
            .Select(MapearAResponse)
            .ToList();
    }

    public async Task<UsuariosResponse> ActualizarUsuariosAsync(int id, UsuariosRequest usuariosRequest)
    {
        Usuarios? usuarioExistente = _repositoryUsuarios.BuscarUsuarioPorId(id);
        if (usuarioExistente == null)
        {
            throw new RecursoNoEncontradoException($"No se encontro el usuario con el ID: {id}");
        }

        if (!string.IsNullOrWhiteSpace(usuariosRequest.Usuario) && usuariosRequest.Usuario != usuarioExistente.Usuario)
        {
            Usuarios? duplicado = _repositoryUsuarios.BuscarPorNombreUsuario(usuariosRequest.Usuario);
            if (duplicado != null && duplicado.Id_usuario != id)
            {
                throw new ConflictoException($"Ya existe un usuario registrado con el nombre '{usuariosRequest.Usuario}'.");
            }

            usuarioExistente.Usuario = usuariosRequest.Usuario;
        }

        usuarioExistente.Nombre = usuariosRequest.Nombre;
        usuarioExistente.Apellido = usuariosRequest.Apellido;
        usuarioExistente.rol = usuariosRequest.rol;
        usuarioExistente.Estado = usuariosRequest.Estado;

        if (!string.IsNullOrWhiteSpace(usuariosRequest.Contraseña))
        {
            usuarioExistente.Contraseña = BCrypt.Net.BCrypt.HashPassword(usuariosRequest.Contraseña);
        }

        await _repositoryUsuarios.ActualizarUsuariosAsync(usuarioExistente);
        return MapearAResponse(usuarioExistente);
    }

    public bool EliminarUsuarioPorId(int id)
    {
        Usuarios? usuarioExistente = _repositoryUsuarios.BuscarUsuarioPorId(id);
        if (usuarioExistente == null)
        {
            throw new RecursoNoEncontradoException($"No se encontro el usuario con el ID: {id}");
        }

        return _repositoryUsuarios.EliminarUsuarioPorId(id);
    }

    public UsuariosResponse RecuperarUsuarioPorId(int id)
    {
        bool recuperado = _repositoryUsuarios.RecuperarUsuarioPorId(id);
        if (!recuperado)
        {
            throw new RecursoNoEncontradoException($"No se encontro el usuario con el ID: {id}");
        }

        Usuarios? usuarioRecuperado = _repositoryUsuarios.BuscarPorNombreUsuario(
            _repositoryUsuarios.ListarTodosUsuarios().First(u => u.Id_usuario == id).Usuario!
        );

    
        return new UsuariosResponse
        {
            Id_usuario = usuarioRecuperado!.Id_usuario,
            Nombre = usuarioRecuperado.Nombre,
            Apellido = usuarioRecuperado.Apellido,
            Usuario = usuarioRecuperado.Usuario,
            rol = usuarioRecuperado.rol,
            Estado = usuarioRecuperado.Estado
        };
    }

    private static UsuariosResponse MapearAResponse(Usuarios u)
    {
        return new UsuariosResponse
        {
            Id_usuario = u.Id_usuario,
            Nombre = u.Nombre,
            Apellido = u.Apellido,
            Usuario = u.Usuario,
            rol = u.rol,
            Estado = u.Estado
        };
    }
}