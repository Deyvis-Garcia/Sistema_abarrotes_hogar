using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;

namespace AbarrotesHogar.Services.Interfaces;
public interface IServicesProducto
{
    ProductoResponse CrearProducto(ProductoRequest request);
    ProductoResponse? BuscarProductoPorId(int id);
    List<ProductoResponse> ListarTodosProducto();
    List<ProductoResponse> ListarTodosProductoEliminados();
    Task<ProductoResponse> ActualizarProducto(int id,ProductoRequest productoRequest);
    bool EliminarProductoPorId(int id);
}