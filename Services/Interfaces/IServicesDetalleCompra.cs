using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
namespace AbarrotesHogar.Services.Interfaces;
public interface IServicesDetalleCompra
{
    DetalleCompraResponse CrearDetalleCompra(DetalleCompraRequest request);
    DetalleCompraResponse? BuscarDetalleCompraPorId(int id);
    List<DetalleCompraResponse> ListarDetalleCompra();
    Task<DetalleCompraResponse> ActualizarDetalleCompraAsync(int id,DetalleCompraRequest detalleCompraRequest);
    bool EliminarDetalleComopraPorId(int id);
}