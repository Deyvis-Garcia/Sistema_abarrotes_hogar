using AbarrotesHogar.Models;
namespace AbarrotesHogar.Repository.Interfaces;
public interface IRepsoirtoryDetalleCompra
{
    void CrearDetalleCompra(DetalleCompras detalleCompras);
    DetalleCompras? BusacarDetalleCompraPorId(int id);
    List<DetalleCompras> ListarTodosDetalleCompra();
}