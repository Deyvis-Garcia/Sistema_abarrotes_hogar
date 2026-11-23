using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Services.Interfaces;


namespace AbarrotesHogar.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class InventarioLotesController : ControllerBase
{
    private IServicesInventarioLotes _servicesInventarioLotes;
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
    [Authorize(Roles = "Administrador")]
    public ActionResult<InventarioLotesResponse> CrearInventarioLotes([FromBody]InventarioLotesRequest inventarioLotesRequest)
    {
        var nuevoInventarioLotes = _servicesInventarioLotes.CrearInventarioLotes(inventarioLotesRequest);
        return CreatedAtAction(nameof(BuscarInventarioLotesPorId),new{id = nuevoInventarioLotes.Id_lote},nuevoInventarioLotes);
    }
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<InventarioLotesResponse>> ActualizarInventarioLotesAsync(int id,[FromBody] InventarioLotesRequest inventarioLotesRequest)
    {
        var inventarioLotesActualizada = await _servicesInventarioLotes.ActualizarInventarioLotesAsync(id,inventarioLotesRequest);
        return Ok(inventarioLotesActualizada);
    }
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public IActionResult EliminarInventarioLotes(int id)
    {
        _servicesInventarioLotes.EliminarInventarioLotes(id);
        return NoContent();
    }
}