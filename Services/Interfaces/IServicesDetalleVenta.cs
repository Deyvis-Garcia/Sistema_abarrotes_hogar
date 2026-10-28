using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
namespace AbarrotesHogar.Services.Interfaces;
public interface IServicesDetalleVenta
{
    DetalleVentaResponse CrearDetalleVenta(DetalleVentaRequest request);
    DetalleVentaResponse? BuscarDetalleVentaPorId(int id);
    List<DetalleVentaResponse> ListarTodosDetalleVenta();
    Task<DetalleVentaResponse> ActualizarDetalleVentaAsync(int id,DetalleVentaRequest detalleVentaRequest);
    bool EliminarDetalleVentaPorId(int id);
}