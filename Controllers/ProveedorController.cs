using Microsoft.AspNetCore.Mvc;
using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Services.Interfaces;
using AbarrotesHogar.Services;


namespace AbarrotesHogar.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProveedorController : ControllerBase
{
    public readonly IServicesProveedor _servicesProveedor;
    public ProveedorController(IServicesProveedor servicesProveedor)
    {
        _servicesProveedor = servicesProveedor;
    }
    [HttpGet]
    public ActionResult<List<ProveedorResponse>> ListarTodosProveedor()
    {
        var proveedor = _servicesProveedor.ListarTodosProveedor();
        return Ok(proveedor);
    }
    [HttpGet("{id}")]
    public ActionResult<ProveedorResponse> BuscarProveedorPorId(int id)
    {
        var proveedorId = _servicesProveedor.BuscarProveedorPorId(id);
        return Ok(proveedorId);
    }
    [HttpGet("eliminados")]
    public ActionResult<List<ProveedorResponse>> ListarTodosProveedorEliminados()
    {
        var provedoresEliminados = _servicesProveedor.ListarTodosProveedorEliminados();
        return Ok(provedoresEliminados);
    }
    [HttpPost]
    public ActionResult<ProveedorResponse> CrearProveedor([FromBody]ProveedorRequest proveedorRequest)
    {
        var nuevoProveedor = _servicesProveedor.CrearProveedor(proveedorRequest);
        return CreatedAtAction(nameof(BuscarProveedorPorId), new {id = nuevoProveedor.Id_proveedor},nuevoProveedor);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<ProveedorResponse>> ActualizarProveedor(int id,[FromBody] ProveedorRequest proveedorRequest)
    {
        var proveedorActualizado = await _servicesProveedor.ActualizarProveedor(id,proveedorRequest);
        return Ok(proveedorActualizado);
    }
    [HttpDelete("{id}")]
    public IActionResult EliminarProvedorPorId(int id)
    {
        _servicesProveedor.EliminarProvedorPorId(id);
        return NoContent();
    }
}