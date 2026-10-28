using AbarrotesHogar.Models;
namespace AbarrotesHogar.Repository.Interfaces;
public interface IRepositoryDetalleVenta{
    void CrearDetalleVenta(DetalleVenta detalleVenta);
    DetalleVenta? BuscarDetalleVentaPorId(int id);
    List<DetalleVenta> ListarTodosDetalleVenta();
    Task<DetalleVenta> ActualizarDetalleVentaAsync(DetalleVenta detalleVenta);
    bool  EliminarDetalleVentaPorId(int id);
}