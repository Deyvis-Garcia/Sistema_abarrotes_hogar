using AbarrotesHogar.Models;
namespace AbarrotesHogar.Repository.Interfaces;
public interface IRepositoryVentas
{
    void CrearVentas(Ventas ventas);
    Ventas? BuscarVentasPorId(int id);
    List<Ventas> ListarTodosVentas();
    Task<Ventas> ActualizarVentasAsync(Ventas ventas);
    bool EliminarVentasPorId(int id);
}