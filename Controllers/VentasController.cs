using Microsoft.AspNetCore.Mvc;
using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Services.Interfaces;


namespace AbarrotesHogar.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VentasController : ControllerBase
{
    public readonly IServicesVentas _servicesVentas;
    public VentasController(IServicesVentas servicesVentas)
    {
        _servicesVentas = servicesVentas;
    }
    [HttpGet]
    public ActionResult<List<VentasResponse>> ListarTodosVentas()
    {
        var ventas = _servicesVentas.ListarTodosVentas();
        return Ok(ventas);
    }
    [HttpGet("{id}")]
    public ActionResult<VentasResponse> BuscarVentaPorId(int id)
    {
        var ventasId = _servicesVentas.BuscarVentaPorId(id);
        return Ok(ventasId);
    }
    [HttpPost]
    public ActionResult<VentasResponse> CrearVenta(VentasRequest ventasRequest)
    {
        var nuevaVenta = _servicesVentas.CrearVenta(ventasRequest);
        return CreatedAtAction(nameof(BuscarVentaPorId),new {id = nuevaVenta.Id_venta},nuevaVenta);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<VentasResponse>> ActualizarVentas(int id,[FromBody]VentasRequest ventasRequest)
    {
        var ventaActualizada = await _servicesVentas.ActualizarVentas(id,ventasRequest);
        return Ok(ventaActualizada);
    }
    [HttpDelete("{id}")]
    public IActionResult EliminarVentasPorId(int id)
    {
        _servicesVentas.EliminarVentasPorId(id);
        return NoContent();
    }
}