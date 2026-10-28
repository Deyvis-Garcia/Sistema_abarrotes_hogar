using AbarrotesHogar.Models;
namespace AbarrotesHogar.Repository.Interfaces;

public interface IRepositoryProductos
{
    void CrearProductos(Productos productos);
    Productos? BuscarProductoPorId(int id);
    List<Productos> ListarTodosProductos();
    List<Productos> ListarTodosProductosEliminados();
    Task<Productos> ActualizarProductosAsync(Productos productos);
    bool EliminarProductosPorId(int id);
}