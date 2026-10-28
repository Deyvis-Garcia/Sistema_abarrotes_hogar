using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Repository.Interfaces;
using AbarrotesHogar.Services.Interfaces;
using AbarrotesHogar.Models;
using AbarrotesHogar.Excepciones;

namespace AbarrotesHogar.Services;
public class ServicesProducto : IServicesProducto
{
    private readonly IRepositoryProductos _repositoryProductos;
    public ServicesProducto(IRepositoryProductos repositoryProductos)
    {
        _repositoryProductos = repositoryProductos;
    }
    public ProductoResponse CrearProducto(ProductoRequest productoRequest)
    {
        Productos nuevoProducto = new Productos
        {
            Nombre = productoRequest.Nombre,
            Descripcion = productoRequest.Descripcion,
            precio_venta = productoRequest.precio_venta,
            stock_actual = productoRequest.stock_actual,
            stock_minimo = productoRequest.stock_minimo,
            Estado = true
        };
        _repositoryProductos.CrearProductos(nuevoProducto);
        ProductoResponse productoResponse = new ProductoResponse
        {
            Id_producto = nuevoProducto.Id_producto,
            Nombre = nuevoProducto.Nombre,
            Descripcion = nuevoProducto.Descripcion,
            precio_venta = nuevoProducto.precio_venta,
            stock_actual = nuevoProducto.stock_actual,
            stock_minimo = nuevoProducto.stock_minimo,
            Estado = nuevoProducto.Estado
        };
        return productoResponse;
    }
    public ProductoResponse? BuscarProductoPorId(int id)
    {
        Productos? productosExistente = _repositoryProductos.BuscarProductoPorId(id);
        if (productosExistente == null){throw new RecursoNoEncontradoException($"No se encontro el producto con el ID: {id}");};
        return new ProductoResponse
        {
            Id_producto = productosExistente.Id_producto,
            Nombre = productosExistente.Nombre,
            Descripcion = productosExistente.Descripcion,
            precio_venta = productosExistente.precio_venta,
            stock_actual = productosExistente.stock_actual,
            stock_minimo = productosExistente.stock_minimo,
            Estado = productosExistente.Estado
        };
    }
    public List<ProductoResponse> ListarTodosProducto()
    {
        List<Productos> productos = _repositoryProductos.ListarTodosProductos();
        return productos.Select(p => new ProductoResponse
        {
            Id_producto = p.Id_producto,
            Nombre = p.Nombre,
            Descripcion = p.Descripcion,
            precio_venta = p.precio_venta,
            stock_actual = p.stock_actual,
            stock_minimo = p.stock_minimo,
            Estado = p.Estado
        }).ToList();
    }
    public List<ProductoResponse> ListarTodosProductoEliminados()
    {
        List<Productos> productosEliminados = _repositoryProductos.ListarTodosProductosEliminados();
        return productosEliminados.Select(p => new ProductoResponse
        {
            Id_producto = p.Id_producto,
            Nombre = p.Nombre,
            Descripcion = p.Descripcion,
            precio_venta = p.precio_venta,
            stock_actual = p.stock_actual,
            stock_minimo = p.stock_minimo,
            Estado = p.Estado
        }).ToList();
    }
    public async Task<ProductoResponse> ActualizarProducto(int id,ProductoRequest productoRequest)
    {
        Productos? productosExistente = _repositoryProductos.BuscarProductoPorId(id);
        if (productosExistente == null){throw new RecursoNoEncontradoException($"No se encontro el producto con el ID: {id}");};
        productosExistente.Nombre = productoRequest.Nombre;
        productosExistente.Descripcion = productoRequest.Descripcion;
        productosExistente.precio_venta = productoRequest.precio_venta;
        productosExistente.stock_actual = productoRequest.stock_actual;
        productosExistente.stock_minimo = productoRequest.stock_minimo;
        productosExistente.Estado = productoRequest.Estado;
        await _repositoryProductos.ActualizarProductosAsync(productosExistente);
        return new ProductoResponse
        {
            Id_producto = productosExistente.Id_producto,
            Nombre = productosExistente.Nombre,
            Descripcion = productosExistente.Descripcion,
            precio_venta = productosExistente.precio_venta,
            stock_actual = productosExistente.stock_actual,
            stock_minimo = productosExistente.stock_minimo,
            Estado = productosExistente.Estado
        };
    }
    public bool EliminarProductoPorId(int id)
    {
        Productos? productosExistente = _repositoryProductos.BuscarProductoPorId(id);
        if (productosExistente == null){throw new RecursoNoEncontradoException($"No se encontro el producto con el ID: {id}");};
        return _repositoryProductos.EliminarProductosPorId(id);
    }
}