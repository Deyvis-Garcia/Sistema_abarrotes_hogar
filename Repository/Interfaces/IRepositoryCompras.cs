using AbarrotesHogar.Models;
namespace AbarrotesHogar.Repository.Interfaces;
public interface IRepositoryCompras
{
    void CrearCompra(Compras compras);
    Compras? BuscarCompraPorId(int id);
    List<Compras> ListarTodos();
    bool EliminarCompraPorId(int id);
    void ActualizarCompra(Compras compras);

}