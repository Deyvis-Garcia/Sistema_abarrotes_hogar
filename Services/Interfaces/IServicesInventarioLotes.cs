using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;

namespace AbarrotesHogar.Services.Interfaces;
public interface IServicesInventarioLotes
{
    InventarioLotesResponse CrearInventarioLotes(InventarioLotesRequest request);
    InventarioLotesResponse? BuscarInventarioLotesPorId(int id);
    List<InventarioLotesResponse> ListarTodosInventarioLotes();
    Task<InventarioLotesResponse> ActualizarInventarioLotesAsync(int id, InventarioLotesRequest inventarioLotesRequest);
    bool EliminarInventarioLotes(int id);
}