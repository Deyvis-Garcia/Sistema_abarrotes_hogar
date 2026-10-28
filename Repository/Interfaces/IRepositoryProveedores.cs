using AbarrotesHogar.Data.Configurations;
using AbarrotesHogar.Models;
namespace AbarrotesHogar.Repository.Interfaces;
public interface IRepositoryProveedores
{
    void CrearProveedor(Proveedores proveedores);
    Proveedores? BuscarProveedorPorId(int id);
    List<Proveedores> ListarTodosProvedores();
    List<Proveedores> ListarTodosProvedoresEliminados();
    Task<Proveedores> ActualizarProveedoresAsync(Proveedores proveedores);
    bool EliminarProveedorePorId(int id);
}