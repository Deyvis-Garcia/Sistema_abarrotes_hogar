using Microsoft.AspNetCore.Mvc;
using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Services.Interfaces;

namespace AbarrotesHogar.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{
    public readonly IServicesProducto _servicesProducto;
    public ProductosController(IServicesProducto servicesProducto)
    {
        _servicesProducto = servicesProducto;
    }
    [HttpGet]
    public ActionResult<List<ProductoResponse>> ListarTodosProducto()
    {
        var productos = _servicesProducto.ListarTodosProducto();
        return Ok(productos);
    }
    [HttpGet("{id}")]
    public ActionResult<ProductoResponse> BuscarProductoPorId(int id)
    {
        var productoId = _servicesProducto.BuscarProductoPorId(id);
        return Ok(productoId);
    }
    [HttpGet("eliminados")]
    public ActionResult<List<ProductoResponse>> ListarTodosProductoEliminados()
    {
        var productosEliminados = _servicesProducto.ListarTodosProductoEliminados();
        return Ok(productosEliminados);
    }
    [HttpPost]
    public ActionResult<ProductoResponse> CrearProducto([FromBody]ProductoRequest productoRequest)
    {
        var nuevoProducto = _servicesProducto.CrearProducto(productoRequest);
        return CreatedAtAction(nameof(BuscarProductoPorId),new { id = nuevoProducto.Id_producto},nuevoProducto);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<ProductoResponse>> ActualizarProducto(int id,[FromBody] ProductoRequest productoRequest)
    {
        var productoActualizado = await _servicesProducto.ActualizarProducto(id,productoRequest);
        return Ok(productoRequest);
    }
    [HttpDelete("{id}")]
    public IActionResult EliminarProductoPorId(int id)
    {
        _servicesProducto.EliminarProductoPorId(id);
        return NoContent();
    }
}