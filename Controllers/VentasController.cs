using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Services.Interfaces;


namespace AbarrotesHogar.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class VentasController : ControllerBase
{
    private readonly IServicesVentas _servicesVentas;
    public VentasController(IServicesVentas servicesVentas)
    {
        _servicesVentas = servicesVentas;
    }
    [HttpGet]
    public async Task<ActionResult<ResultadoPaginado<VentasResponse>>> ListarTodosVentas([FromQuery] int pagina = 1,[FromQuery] int tamano = 10)
    {
        pagina = Math.Max(1, pagina);
        tamano = Math.Clamp(tamano, 1, 50);
        var ventas = await _servicesVentas.ListarTodosVentas(pagina, tamano);
        return Ok(ventas);
    }
    [HttpGet("{id}")]
    public ActionResult<VentasResponse> BuscarVentaPorId(int id)
    {
        var ventasId = _servicesVentas.BuscarVentaPorId(id);
        return Ok(ventasId);
    }
    [HttpPost]
    public ActionResult<VentasResponse> CrearVenta([FromBody] VentasRequest ventasRequest)
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
    [Authorize(Roles = "Administrador")]
    public IActionResult EliminarVentasPorId(int id)
    {
        _servicesVentas.EliminarVentasPorId(id);
        return NoContent();
    }
}