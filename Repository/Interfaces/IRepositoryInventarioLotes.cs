using AbarrotesHogar.Models;
namespace AbarrotesHogar.Repository.Interfaces;

public interface IRepositoryInventarioLotes{
    void CrearInventarioLotes(InventarioLotes inventarioLotes);
    InventarioLotes? BuscarInventarioLotesPorId(int id);
    List<InventarioLotes> ListarTodosInventarioLotes();
    Task<InventarioLotes> ActualizarInventarioLotesAsync(InventarioLotes inventarioLotes);
    bool EliminarInventarioLotesPorId(int id);
}