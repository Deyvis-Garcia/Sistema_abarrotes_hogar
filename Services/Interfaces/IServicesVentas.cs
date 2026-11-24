using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;

namespace AbarrotesHogar.Services.Interfaces;
public interface IServicesVentas
{
    VentasResponse CrearVenta(VentasRequest request);
    VentasResponse? BuscarVentaPorId(int id);
    Task<ResultadoPaginado<VentasResponse>> ListarTodosVentas(int pagina, int tamano);
    Task<VentasResponse> ActualizarVentas(int id,VentasRequest ventasRequest);
    bool EliminarVentasPorId(int id);
}