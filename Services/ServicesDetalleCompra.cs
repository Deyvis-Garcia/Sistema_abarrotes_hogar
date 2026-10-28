using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Repository.Interfaces;
using AbarrotesHogar.Services.Interfaces;
using AbarrotesHogar.Models;
using AbarrotesHogar.Excepciones;
using AbarrotesHogar.Repository;

namespace AbarrotesHogar.Services;

public class ServicesDetalleCompra : IServicesDetalleCompra
{
    public readonly IRepositoryDetalleCompra _repositoryDetalleCompra;
    public ServicesDetalleCompra(IRepositoryDetalleCompra repositoryDetalleCompra)
    {
        _repositoryDetalleCompra = repositoryDetalleCompra;
    }
    public DetalleCompraResponse CrearDetalleCompra(DetalleCompraRequest request)
    {
        decimal calcularSubtotal = request.Cantidad * request.Precio_unitario;
        DetalleCompras nuevoDetalleCompra = new DetalleCompras
        {
            Id_compra = request.Id_compra,
            Id_producto = request.Id_producto,
            Cantidad = request.Cantidad,
            Precio_unitario = request.Precio_unitario,
            Subtotal = calcularSubtotal
        };
        _repositoryDetalleCompra.CrearDetalleCompra(nuevoDetalleCompra);
        DetalleCompraResponse detalleCompraResponse = new DetalleCompraResponse
        {
            Id_compra = nuevoDetalleCompra.Id_compra,
            Id_producto = nuevoDetalleCompra.Id_producto,
            Cantidad = nuevoDetalleCompra.Cantidad,
            Precio_unitario = nuevoDetalleCompra.Precio_unitario,
            Subtotal = nuevoDetalleCompra.Subtotal
        };
        return detalleCompraResponse;

    }
    public DetalleCompraResponse? BuscarDetalleCompraPorId(int id)
    {
        DetalleCompras? detalleCompras = _repositoryDetalleCompra.BusacarDetalleCompraPorId(id);
        if(detalleCompras == null){throw new RecursoNoEncontradoException($"No se encontro el detalle de la compra con el ID: {id}");};
        return new DetalleCompraResponse
        {
            Id_detalle_compra = detalleCompras.Id_detalle_compra,
            Id_compra = detalleCompras.Id_compra,
            Id_producto = detalleCompras.Id_producto,
            Cantidad = detalleCompras.Cantidad,
            Precio_unitario = detalleCompras.Precio_unitario,
            Subtotal = detalleCompras.Subtotal
        };
    }
    public List<DetalleCompraResponse> ListarDetalleCompra()
    {
        List<DetalleCompras> detalleCompras = _repositoryDetalleCompra.ListarTodosDetalleCompra();
        return detalleCompras.Select( d => new DetalleCompraResponse
        {
            Id_detalle_compra = d.Id_detalle_compra,
            Id_compra = d.Id_compra,
            Id_producto = d.Id_producto,
            Cantidad = d.Cantidad,
            Precio_unitario = d.Precio_unitario,
            Subtotal = d.Subtotal
        }).ToList();
    }
    public async Task<DetalleCompraResponse> ActualizarDetalleCompraAsync(int id,DetalleCompraRequest detalleRequest)
    {
        decimal nuevoSubtotal = detalleRequest.Cantidad * detalleRequest.Precio_unitario;

        DetalleCompras? detalleComprasExistente = _repositoryDetalleCompra.BusacarDetalleCompraPorId(id);
        if (detalleComprasExistente == null){throw new RecursoNoEncontradoException($"No se encontro el detalle de la compra con el ID: {id}");};

        detalleComprasExistente.Id_compra = detalleRequest.Id_compra;
        detalleComprasExistente.Id_producto = detalleRequest.Id_producto;
        detalleComprasExistente.Cantidad = detalleRequest.Cantidad;
        detalleComprasExistente.Precio_unitario = detalleRequest.Precio_unitario;
        detalleComprasExistente.Subtotal = nuevoSubtotal;

        await _repositoryDetalleCompra.ActualizarDetalleComprasAsync(detalleComprasExistente);
        return new DetalleCompraResponse
        {
            Id_detalle_compra = detalleComprasExistente.Id_detalle_compra,
            Id_compra = detalleComprasExistente.Id_compra,
            Id_producto = detalleComprasExistente.Id_producto,
            Cantidad = detalleComprasExistente.Cantidad,
            Precio_unitario = detalleComprasExistente.Precio_unitario,
            Subtotal = detalleComprasExistente.Subtotal 
        };
    }
    public bool EliminarDetalleComopraPorId(int id)
    {
        DetalleCompras? detalleComprasExistente = _repositoryDetalleCompra.BusacarDetalleCompraPorId(id);
        if (detalleComprasExistente == null){throw new RecursoNoEncontradoException($"No se encontro el detalle de la compra con el ID: {id}");};
        return _repositoryDetalleCompra.EliminarDetalleComprasPorId(id);
    }
}