using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Repository.Interfaces;
using AbarrotesHogar.Services.Interfaces;
using AbarrotesHogar.Models;
using AbarrotesHogar.Excepciones;
using AbarrotesHogar.Repository;

namespace AbarrotesHogar.Services;
public class ServicesVentas : IServicesVentas
{
    public readonly IRepositoryVentas _repositoryVentas;
    public ServicesVentas(IRepositoryVentas repositoryVentas)
    {
        _repositoryVentas = repositoryVentas;
    }
    public VentasResponse CrearVenta(VentasRequest ventasRequest)
    {
        Ventas nuevaVentas = new Ventas
        {
            Id_usuario = ventasRequest.Id_usuario,
            Fecha_venta = DateTime.Now,
            Total = ventasRequest.Total,
            Observaciones = ventasRequest.Observaciones,
        };
        _repositoryVentas.CrearVentas(nuevaVentas);
        VentasResponse ventasResponse = new VentasResponse
        {
            Id_venta = nuevaVentas.Id_venta,
            Id_usuario = nuevaVentas.Id_usuario,
            Fecha_venta = nuevaVentas.Fecha_venta,
            Total = nuevaVentas.Total,
            Observaciones = nuevaVentas.Observaciones
        };
        return ventasResponse;
    }
    public VentasResponse? BuscarVentaPorId(int id)
    {
        Ventas? ventasExistente = _repositoryVentas.BuscarVentasPorId(id);
        if(ventasExistente == null){throw new RecursoNoEncontradoException($"No se encontro la venta con el ID: {id}");};
        return new VentasResponse {
            Id_venta = ventasExistente.Id_venta,
            Id_usuario = ventasExistente.Id_usuario,
            Fecha_venta = ventasExistente.Fecha_venta,
            Total = ventasExistente.Total,
            Observaciones = ventasExistente.Observaciones
        };
    }
    public List<VentasResponse> ListarTodosVentas()
    {
        List<Ventas> ventas = _repositoryVentas.ListarTodosVentas();
        return ventas.Select(v => new VentasResponse
        {
            Id_venta = v.Id_venta,
            Id_usuario = v.Id_usuario,
            Fecha_venta = v.Fecha_venta,
            Total = v.Total,
            Observaciones = v.Observaciones
        }).ToList();
    }
    public async Task<VentasResponse> ActualizarVentas(int id,VentasRequest ventasRequest)
    {
        Ventas? ventasExistente = _repositoryVentas.BuscarVentasPorId(id);
        if(ventasExistente == null){throw new RecursoNoEncontradoException($"No se encontro la venta con el ID: {id}");};
        ventasExistente.Id_usuario = ventasRequest.Id_usuario;
        ventasExistente.Fecha_venta = ventasRequest.Fecha_venta;
        ventasExistente.Total = ventasRequest.Total;
        ventasExistente.Observaciones = ventasRequest.Observaciones;
        await _repositoryVentas.ActualizarVentasAsync(ventasExistente);
        return new VentasResponse
        {
            Id_venta = ventasExistente.Id_venta,
            Id_usuario = ventasExistente.Id_usuario,
            Fecha_venta = ventasExistente.Fecha_venta,
            Total = ventasExistente.Total,
            Observaciones = ventasExistente.Observaciones
        };
    }
    public bool EliminarVentasPorId(int id)
    {
        Ventas? ventasExistente = _repositoryVentas.BuscarVentasPorId(id);
        if(ventasExistente == null){throw new RecursoNoEncontradoException($"No se encontro la venta con el ID: {id}");};
        return _repositoryVentas.EliminarVentasPorId(id);
    }
}