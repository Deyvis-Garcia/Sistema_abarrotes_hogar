using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;

namespace AbarrotesHogar.Services.Interfaces;
public interface IServicesVentas
{
    VentasResponse CrearVenta(VentasRequest request);
    VentasResponse? BuscarVentaPorId(int id);
    List<VentasResponse> ListarTodosVentas();
    Task<VentasResponse> ActualizarVentas(int id,VentasRequest ventasRequest);
    bool EliminarVentasPorId(int id);
}