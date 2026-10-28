using Microsoft.AspNetCore.Mvc;
using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Services.Interfaces;

namespace AbarrotesHogar.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DetalleCompraController : ControllerBase
{
    public readonly IServicesDetalleCompra _servicesDetalleCompra;
    public DetalleCompraController(IServicesDetalleCompra servicesDetalleCompra)
    {
        _servicesDetalleCompra = servicesDetalleCompra;
    }
    [HttpGet]
    public ActionResult<List<DetalleCompraResponse>> ListarDetalleCompra()
    {
        var detalleCompra = _servicesDetalleCompra.ListarDetalleCompra();
        return Ok(detalleCompra);
    }
    [HttpGet("{id}")]
    public ActionResult<DetalleCompraResponse> BuscarDetalleCompraPorId(int id)
    {
        var detalleCompra = _servicesDetalleCompra.BuscarDetalleCompraPorId(id);
        return Ok(detalleCompra);
    }
    [HttpPost]
    public ActionResult<ComprasResponse> CrearDetalleCompra([FromBody] DetalleCompraRequest detalleCompraRequest)
    {
        var nuevoDetalleCompra = _servicesDetalleCompra.CrearDetalleCompra(detalleCompraRequest);
        return CreatedAtAction(nameof(BuscarDetalleCompraPorId),new{id = nuevoDetalleCompra.Id_detalle_compra},nuevoDetalleCompra);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<DetalleCompraResponse>> ActualizarDetalleCompraAsync(int id,[FromBody] DetalleCompraRequest detalleCompraRequest)
    {
        var actualizarDetalleCompra = await _servicesDetalleCompra.ActualizarDetalleCompraAsync(id,detalleCompraRequest);
        return Ok(actualizarDetalleCompra);
    }
    [HttpDelete("{Id}")]
    public IActionResult EliminarDetalleCompraPorId(int id)
    {
        _servicesDetalleCompra.EliminarDetalleComopraPorId(id);
        return NoContent();
    }
}