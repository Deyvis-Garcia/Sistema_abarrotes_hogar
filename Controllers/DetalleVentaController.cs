using Microsoft.AspNetCore.Mvc;
using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Services.Interfaces;
using AbarrotesHogar.Services;

namespace AbarrotesHogar.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DetalleVentaController : ControllerBase
{
    public readonly IServicesDetalleVenta _servicesDetalleVenta;
    public DetalleVentaController(IServicesDetalleVenta servicesDetalleVenta)
    {
        _servicesDetalleVenta = servicesDetalleVenta;
    }
    [HttpGet]
    public ActionResult<List<DetalleVentaResponse>> ListarTodosDetalleVenta()
    {
        var detalleVenta = _servicesDetalleVenta.ListarTodosDetalleVenta();
        return Ok(detalleVenta);
    }
    [HttpGet("{id}")]
    public ActionResult<DetalleVentaResponse> BuscarDetalleVentaPorId(int id)
    {
        var detalleVenta = _servicesDetalleVenta.BuscarDetalleVentaPorId(id);
        return Ok(detalleVenta);
    }
    [HttpPost]
    public ActionResult<DetalleVentaResponse> CrearDetalleVenta([FromBody] DetalleVentaRequest detalleVentaRequest)
    {
        var nuevaDetalleVenta = _servicesDetalleVenta.CrearDetalleVenta(detalleVentaRequest);
        return CreatedAtAction(nameof(BuscarDetalleVentaPorId),new{id = nuevaDetalleVenta.Id_detalle_venta},nuevaDetalleVenta);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<DetalleVentaResponse>> ActualizarDetalleVentaAsync(int id, [FromBody] DetalleVentaRequest detalleVentaRequest)
    {
        var detalleVentaActualizada = await _servicesDetalleVenta.ActualizarDetalleVentaAsync(id,detalleVentaRequest);
        return Ok(detalleVentaActualizada);
    }
    [HttpDelete("{id}")]
    public IActionResult EliminarDetalleCompraPorId(int id)
    {
        _servicesDetalleVenta.EliminarDetalleVentaPorId(id);
        return NoContent();
    }
}