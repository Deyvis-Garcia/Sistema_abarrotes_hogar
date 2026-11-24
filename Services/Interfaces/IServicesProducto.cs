using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;

namespace AbarrotesHogar.Services.Interfaces;
public interface IServicesProducto
{
    ProductoResponse CrearProducto(ProductoRequest request);
    ProductoResponse? BuscarProductoPorId(int id);
    Task<ResultadoPaginado<ProductoResponse>> ListarTodosProducto(int pagina, int tamano);
    List<ProductoResponse> ListarTodosProductoEliminados();
    Task<ProductoResponse> ActualizarProducto(int id,ProductoRequest productoRequest);
    bool EliminarProductoPorId(int id);
    ProductoResponse RecuperarProductoPorId(int id);
}