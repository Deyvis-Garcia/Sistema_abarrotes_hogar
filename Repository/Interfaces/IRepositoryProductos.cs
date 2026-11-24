using AbarrotesHogar.Models;
namespace AbarrotesHogar.Repository.Interfaces;

public interface IRepositoryProductos
{
    void CrearProductos(Productos productos);
    Productos? BuscarProductoPorId(int id);
    Task<(List<Productos> Datos, int Total)> ListarTodosProductosAsync(int pagina, int tamano);
    List<Productos> ListarTodosProductosEliminados();
    Task<Productos> ActualizarProductosAsync(Productos productos);
    bool EliminarProductosPorId(int id);
    bool RecuperarProductoPorId(int id);
}