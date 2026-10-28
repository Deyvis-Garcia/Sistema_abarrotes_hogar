using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;

namespace AbarrotesHogar.Services.Interfaces;
public interface IServicesCompras
{
    ComprasResponse CrearCompra(ComprasRequest request);
    ComprasResponse? BuscarCompraPorId(int id);
    List<ComprasResponse> ListarTodosCompras();
    Task<ComprasResponse> ActualizarComprasAsync(int id,ComprasRequest comprasRequest);
    bool EliminarCompraPorId(int id);
}