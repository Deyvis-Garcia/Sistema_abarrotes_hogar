using AbarrotesHogar.Models;
namespace AbarrotesHogar.Repository.Interfaces;
public interface IRepositoryCompras
{
    void CrearCompra(Compras compras);
    Compras? BuscarCompraPorId(int id);
    List<Compras> ListarTodos();
    Task<Compras> ActualizarComprasAsync(Compras compras);
    bool EliminarCompraPorId(int id);

}