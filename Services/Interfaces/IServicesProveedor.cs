using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;

namespace AbarrotesHogar.Services.Interfaces;
public interface IServicesProveedor
{
    ProveedorResponse CrearProveedor(ProveedorRequest request);
    ProveedorResponse? BuscarProveedorPorId(int id);
    List<ProveedorResponse> ListarTodosProveedor();
    List<ProveedorResponse> ListarTodosProveedorEliminados();
    Task<ProveedorResponse> ActualizarProveedor(int id,ProveedorRequest proveedorRequest);
    bool EliminarProvedorPorId(int id);
}