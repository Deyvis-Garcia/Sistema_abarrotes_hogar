using Microsoft.AspNetCore.Mvc;
using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Services.Interfaces;

namespace AbarrotesHogar.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ComprasController : ControllerBase
{
    private readonly IServicesCompras _ServicesCompras;
    public ComprasController(IServicesCompras servicesCompras)
    {
        _ServicesCompras = servicesCompras;
    }
    [HttpGet]
    public ActionResult<List<ComprasResponse>> ListarTodosCompras()
    {
        var compra = _ServicesCompras.ListarTodosCompras();
        return Ok(compra);
    }
    [HttpGet("{id}")]
    public ActionResult<ComprasResponse> BuscarCompraPorId(int id)
    {
        var compra = _ServicesCompras.BuscarCompraPorId(id);
        return  Ok(compra);
    }
    [HttpPost]
    public ActionResult<ComprasResponse> CrearCompra([FromBody] ComprasRequest comprasRequest)
    {
        var nuevaCompra = _ServicesCompras.CrearCompra(comprasRequest);
        return CreatedAtAction(nameof(BuscarCompraPorId),new {id = nuevaCompra.Id_compra},nuevaCompra);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<ComprasResponse>> ActualizarComprasAsync(int id,[FromBody] ComprasRequest comprasRequest)
    {
        var compraActualizada = await _ServicesCompras.ActualizarComprasAsync(id,comprasRequest);
        return Ok(compraActualizada);
    }
    [HttpDelete("{id}")]
    public IActionResult EliminarCompraPorId(int id)
    {
        _ServicesCompras.EliminarCompraPorId(id);
        return NoContent();
    }
}