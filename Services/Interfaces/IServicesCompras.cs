using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;

namespace AbarrotesHogar.Services.Interfaces;
public interface IServicesCompras
{
    ComprasResponse CrearCompra(ComprasRequest request);
    ComprasResponse? BuscarCompraPorId(int id);
    Task<ResultadoPaginado<ComprasResponse>> ListarTodosCompras(int pagina, int tamano);
    Task<ComprasResponse> ActualizarComprasAsync(int id,ComprasRequest comprasRequest);
    bool EliminarCompraPorId(int id);
}