using Microsoft.AspNetCore.Mvc;
using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Services.Interfaces;

namespace AbarrotesHogar.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    public readonly IServicesUsuarios _servicesUsuarios;
    public UsuariosController(IServicesUsuarios servicesUsuarios)
    {
        _servicesUsuarios = servicesUsuarios;
    }
    [HttpGet]
    public ActionResult<List<UsuariosResponse>> ListarTodosUsuarios()
    {
        var usuarios = _servicesUsuarios.ListarTodosUsuarios();
        return Ok(usuarios);
    }
    [HttpGet("{id}")]
    public ActionResult<UsuariosResponse> BuscarUsuarioPorId(int id)
    {
        var usuariosId = _servicesUsuarios.BuscarUsuarioPorId(id);
        return Ok(usuariosId);
    }
    [HttpGet("eliminados")]
    public ActionResult<List<UsuariosResponse>> ListarTodosUsuariosEliminados()
    {
        var usuariosEliminados = _servicesUsuarios.ListarTodosUsuariosEliminados();
        return Ok(usuariosEliminados);
    }
    [HttpPost]
    public ActionResult<UsuariosResponse> CrearUsuario([FromBody]UsuariosRequest usuariosRequest)
    {
        var nuevoUsuario = _servicesUsuarios.CrearUsuario(usuariosRequest);
        return CreatedAtAction(nameof(BuscarUsuarioPorId),new {id = nuevoUsuario.Id_usuario},nuevoUsuario);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<UsuariosResponse>> ActualizarUsuariosAsync(int id,[FromBody]UsuariosRequest usuariosRequest)
    {
        var usuarioActualizado = await _servicesUsuarios.ActualizarUsuariosAsync(id,usuariosRequest);
        return Ok(usuarioActualizado);
    }
    [HttpDelete("{id}")]
    public IActionResult EliminarUsuarioPorId(int id)
    {
        _servicesUsuarios.EliminarUsuarioPorId(id);
        return NoContent();
    }
}
