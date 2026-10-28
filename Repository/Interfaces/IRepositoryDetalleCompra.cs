using AbarrotesHogar.Models;
namespace AbarrotesHogar.Repository.Interfaces;
public interface IRepositoryDetalleCompra
{
    void CrearDetalleCompra(DetalleCompras detalleCompras);
    DetalleCompras? BusacarDetalleCompraPorId(int id);
    List<DetalleCompras> ListarTodosDetalleCompra();
    Task<DetalleCompras> ActualizarDetalleComprasAsync(DetalleCompras detalleCompras);
    bool EliminarDetalleComprasPorId(int id);
}