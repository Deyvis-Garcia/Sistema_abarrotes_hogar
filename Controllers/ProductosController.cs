using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Services.Interfaces;

namespace AbarrotesHogar.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductosController : ControllerBase
{
    private readonly IServicesProducto _servicesProducto;
    public ProductosController(IServicesProducto servicesProducto)
    {
        _servicesProducto = servicesProducto;
    }
    [HttpGet]
    public async Task<ActionResult<ResultadoPaginado<ProductoResponse>>> ListarTodosProducto([FromQuery] int pagina = 1,[FromQuery] int tamano = 10)
    {
        pagina = Math.Max(1, pagina);
        tamano = Math.Clamp(tamano, 1, 50);
        var productos = await _servicesProducto.ListarTodosProducto(pagina, tamano);
        return Ok(productos);
    }
    [HttpGet("{id}")]
    public ActionResult<ProductoResponse> BuscarProductoPorId(int id)
    {
        var productoId = _servicesProducto.BuscarProductoPorId(id);
        return Ok(productoId);
    }
    [HttpGet("eliminados")]
    [Authorize(Roles = "Administrador")]
    public ActionResult<List<ProductoResponse>> ListarTodosProductoEliminados()
    {
        var productosEliminados = _servicesProducto.ListarTodosProductoEliminados();
        return Ok(productosEliminados);
    }
    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public ActionResult<ProductoResponse> CrearProducto([FromBody]ProductoRequest productoRequest)
    {
        var nuevoProducto = _servicesProducto.CrearProducto(productoRequest);
        return CreatedAtAction(nameof(BuscarProductoPorId),new { id = nuevoProducto.Id_producto},nuevoProducto);
    }
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<ProductoResponse>> ActualizarProducto(int id,[FromBody] ProductoRequest productoRequest)
    {
        var productoActualizado = await _servicesProducto.ActualizarProducto(id,productoRequest);
        return Ok(productoActualizado);
    }
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public IActionResult EliminarProductoPorId(int id)
    {
        _servicesProducto.EliminarProductoPorId(id);
        return NoContent();
    }
    [HttpPatch("{id}/recuperar")]
    [Authorize(Roles = "Administrador")]
    public ActionResult<ProductoResponse> RecuperarProducto(int id)
    {
        ProductoResponse producto = _servicesProducto.RecuperarProductoPorId(id);
        return Ok(producto);
    }
}