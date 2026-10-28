using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Repository.Interfaces;
using AbarrotesHogar.Services.Interfaces;
using AbarrotesHogar.Models;
using AbarrotesHogar.Excepciones;
using AbarrotesHogar.Repository;

namespace AbarrotesHogar.Services;
public class ServicesDetalleVenta : IServicesDetalleVenta
{
    public readonly IRepositoryDetalleVenta _repositoryDetalleVenta;
    public ServicesDetalleVenta(IRepositoryDetalleVenta repositoryDetalleVenta)
    {
        _repositoryDetalleVenta = repositoryDetalleVenta;
    }
    public DetalleVentaResponse CrearDetalleVenta(DetalleVentaRequest request)
    {
        decimal calcularSubtotal = request.Cantidad * request.Precio_unitario;
        DetalleVenta nuevoDetalleVenta = new DetalleVenta
        {
            Id_venta = request.Id_venta,
            Id_producto = request.Id_producto,
            Cantidad = request.Cantidad,
            Precio_unitario = request.Precio_unitario,
            Subtotal = calcularSubtotal
        };
        _repositoryDetalleVenta.CrearDetalleVenta(nuevoDetalleVenta);
        DetalleVentaResponse detalleVentaResponse = new DetalleVentaResponse
        {
            Id_detalle_venta = nuevoDetalleVenta.Id_detalle_venta,
            Id_venta = nuevoDetalleVenta.Id_venta,
            Id_producto = nuevoDetalleVenta.Id_producto,
            Cantidad = nuevoDetalleVenta.Cantidad,
            Precio_unitario = nuevoDetalleVenta.Precio_unitario,
            Subtotal = nuevoDetalleVenta.Subtotal
        };
        return detalleVentaResponse;
    }
    public DetalleVentaResponse? BuscarDetalleVentaPorId(int id)
    {
        DetalleVenta? detalleVenta = _repositoryDetalleVenta.BuscarDetalleVentaPorId(id);
        if (detalleVenta == null){throw new RecursoNoEncontradoException($"No se encontro el detalle de la venta con el ID: {id}");};
        return new DetalleVentaResponse
        {
            Id_detalle_venta = detalleVenta.Id_detalle_venta,
            Id_venta = detalleVenta.Id_venta,
            Id_producto = detalleVenta.Id_producto,
            Cantidad = detalleVenta.Cantidad,
            Precio_unitario = detalleVenta.Precio_unitario,
            Subtotal = detalleVenta.Subtotal  
        };
    }
    public List<DetalleVentaResponse> ListarTodosDetalleVenta()
    {
        List<DetalleVenta> detalleVentas = _repositoryDetalleVenta.ListarTodosDetalleVenta();
        return detalleVentas.Select(d => new DetalleVentaResponse
        {
            Id_detalle_venta = d.Id_detalle_venta,
            Id_venta = d.Id_venta,
            Id_producto = d.Id_producto,
            Cantidad = d.Cantidad,
            Precio_unitario = d.Precio_unitario,
            Subtotal = d.Subtotal  
        }).ToList();
    }
    public async Task<DetalleVentaResponse> ActualizarDetalleVentaAsync(int id,DetalleVentaRequest request)
    {
        decimal ActualizarSubtotal = request.Cantidad * request.Precio_unitario;
        DetalleVenta? detalleVentaExistente = _repositoryDetalleVenta.BuscarDetalleVentaPorId(id);
        if (detalleVentaExistente == null){throw new RecursoNoEncontradoException($"No se encontro el detalle de la venta con el ID: {id}");};
        
        detalleVentaExistente.Id_venta = request.Id_venta;
        detalleVentaExistente.Id_producto = request.Id_producto;
        detalleVentaExistente.Cantidad = request.Cantidad;
        detalleVentaExistente.Precio_unitario = request.Precio_unitario;
        detalleVentaExistente.Subtotal = ActualizarSubtotal;

        await _repositoryDetalleVenta.ActualizarDetalleVentaAsync(detalleVentaExistente);
        return new DetalleVentaResponse
        {
            Id_detalle_venta = detalleVentaExistente.Id_detalle_venta,
            Id_venta = detalleVentaExistente.Id_venta,
            Id_producto = detalleVentaExistente.Id_producto,
            Cantidad = detalleVentaExistente.Cantidad,
            Precio_unitario = detalleVentaExistente.Precio_unitario,
            Subtotal = detalleVentaExistente.Subtotal
        };
    }
    public bool EliminarDetalleVentaPorId(int id)
    {
        DetalleVenta? detalleVentaExistente = _repositoryDetalleVenta.BuscarDetalleVentaPorId(id);
        if (detalleVentaExistente == null){throw new RecursoNoEncontradoException($"No se encontro el detalle de la venta con el ID: {id}");};
        return _repositoryDetalleVenta.EliminarDetalleVentaPorId(id);
    }
}