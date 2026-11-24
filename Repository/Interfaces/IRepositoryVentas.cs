using AbarrotesHogar.Models;
namespace AbarrotesHogar.Repository.Interfaces;
public interface IRepositoryVentas
{
    void CrearVentas(Ventas ventas);
    Ventas? BuscarVentasPorId(int id);
    Task<(List<Ventas> Datos, int Total)> ListarTodosVentasAsync(int pagina, int tamano);
    Task<Ventas> ActualizarVentasAsync(Ventas ventas);
    bool EliminarVentasPorId(int id);
}