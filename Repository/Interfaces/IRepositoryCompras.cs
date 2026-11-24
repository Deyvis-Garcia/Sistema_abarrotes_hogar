using AbarrotesHogar.Models;
namespace AbarrotesHogar.Repository.Interfaces;
public interface IRepositoryCompras
{
    void CrearCompra(Compras compras);
    Compras? BuscarCompraPorId(int id);
    Task<(List<Compras> Datos, int Total)> ListarTodosAsync(int pagina, int tamano);
    Task<Compras> ActualizarComprasAsync(Compras compras);
    bool EliminarCompraPorId(int id);

}