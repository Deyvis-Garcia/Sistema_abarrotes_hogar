using Microsoft.AspNetCore.Mvc;
using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Services.Interfaces;
using AbarrotesHogar.Services;

namespace AbarrotesHogar.Controllers;
[Route("api/[controller]")]
[ApiController]
public class InventarioLotesController : ControllerBase
{
    public IServicesInventarioLotes _servicesInventarioLotes;
    public InventarioLotesController(IServicesInventarioLotes servicesInventarioLotes)
    {
        _servicesInventarioLotes = servicesInventarioLotes;
    }
    [HttpGet]
    public ActionResult<List<InventarioLotesResponse>> ListarTodosInventarioLotes()
    {
        var inventarioLotes = _servicesInventarioLotes.ListarTodosInventarioLotes();
        return Ok(inventarioLotes);
    }
    [HttpGet("{id}")]
    public ActionResult<InventarioLotesResponse> BuscarInventarioLotesPorId(int id)
    {
        var inventarioLotesId = _servicesInventarioLotes.BuscarInventarioLotesPorId(id);
        return Ok(inventarioLotesId);
    }
    [HttpPost]
    public ActionResult<InventarioLotesResponse> CrearInventarioLotes([FromBody]InventarioLotesRequest inventarioLotesRequest)
    {
        var nuevoInventarioLotes = _servicesInventarioLotes.CrearInventarioLotes(inventarioLotesRequest);
        return CreatedAtAction(nameof(BuscarInventarioLotesPorId),new{id = nuevoInventarioLotes.Id_lote},nuevoInventarioLotes);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<InventarioLotesResponse>> ActualizarInventarioLotesAsync(int id,[FromBody] InventarioLotesRequest inventarioLotesRequest)
    {
        var inventarioLotesActualizada = await _servicesInventarioLotes.ActualizarInventarioLotesAsync(id,inventarioLotesRequest);
        return Ok(inventarioLotesActualizada);
    }
    [HttpDelete("{id}")]
    public IActionResult EliminarInventarioLotes(int id)
    {
        _servicesInventarioLotes.EliminarInventarioLotes(id);
        return NoContent();
    }
}