using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Repository.Interfaces;
using AbarrotesHogar.Services.Interfaces;
using AbarrotesHogar.Models;
using AbarrotesHogar.Excepciones;
using AbarrotesHogar.Repository;

namespace AbarrotesHogar.Services;
public class ServicesInventarioLotes : IServicesInventarioLotes
{
    public readonly IRepositoryInventarioLotes _repositoryInventarioLotes;
    public ServicesInventarioLotes(IRepositoryInventarioLotes repositoryInventarioLotes)
    {
        _repositoryInventarioLotes = repositoryInventarioLotes;
    }
    public InventarioLotesResponse CrearInventarioLotes(InventarioLotesRequest inventarioLotesRequest)
    {
        InventarioLotes nuevoInventarioLotes = new InventarioLotes
        {
            Id_producto = inventarioLotesRequest.Id_producto,
            Fecha_ingreso = inventarioLotesRequest.Fecha_ingreso,
            Fecha_vencimiento = inventarioLotesRequest.Fecha_vencimiento,
            Cantidad_lote = inventarioLotesRequest.Cantidad_lote,
            Costo_unitario = inventarioLotesRequest.Costo_unitario
        };
        _repositoryInventarioLotes.CrearInventarioLotes(nuevoInventarioLotes);
        InventarioLotesResponse inventarioLotesResponse = new InventarioLotesResponse
        {
            Id_lote = nuevoInventarioLotes.Id_lote,
            Id_producto = nuevoInventarioLotes.Id_producto,
            Fecha_ingreso = nuevoInventarioLotes.Fecha_ingreso,
            Fecha_vencimiento = nuevoInventarioLotes.Fecha_vencimiento,
            Cantidad_lote = nuevoInventarioLotes.Cantidad_lote,
            Costo_unitario = nuevoInventarioLotes.Costo_unitario
        };
        return inventarioLotesResponse;
    }
    public InventarioLotesResponse? BuscarInventarioLotesPorId(int id)
    {
        InventarioLotes? inventarioLotes = _repositoryInventarioLotes.BuscarInventarioLotesPorId(id);
        if ( inventarioLotes == null){throw new RecursoNoEncontradoException($"No se encontro el inventario lotes con el ID: {id}");};
        return new InventarioLotesResponse
        {
            Id_lote = inventarioLotes.Id_lote,
            Id_producto = inventarioLotes.Id_producto,
            Fecha_ingreso = inventarioLotes.Fecha_ingreso,
            Fecha_vencimiento = inventarioLotes.Fecha_vencimiento,
            Cantidad_lote = inventarioLotes.Cantidad_lote,
            Costo_unitario = inventarioLotes.Costo_unitario
        };
    }
    public List<InventarioLotesResponse> ListarTodosInventarioLotes()
    {
        List<InventarioLotes> inventarioLotes = _repositoryInventarioLotes.ListarTodosInventarioLotes();
        return inventarioLotes.Select(l => new InventarioLotesResponse
        {
            Id_lote = l.Id_lote,
            Id_producto = l.Id_producto,
            Fecha_ingreso = l.Fecha_ingreso,
            Fecha_vencimiento = l.Fecha_vencimiento,
            Cantidad_lote = l.Cantidad_lote,
            Costo_unitario = l.Costo_unitario
        }).ToList();
    }
    public async Task<InventarioLotesResponse> ActualizarInventarioLotesAsync(int id, InventarioLotesRequest inventarioLotesRequest)
    {
        InventarioLotes? inventarioLotesExistente = _repositoryInventarioLotes.BuscarInventarioLotesPorId(id);
        if ( inventarioLotesExistente == null){throw new RecursoNoEncontradoException($"No se encontro el inventario lotes con el ID: {id}");};
        inventarioLotesExistente.Id_producto = inventarioLotesRequest.Id_producto;
        inventarioLotesExistente.Fecha_ingreso = inventarioLotesRequest.Fecha_ingreso;
        inventarioLotesExistente.Fecha_vencimiento = inventarioLotesRequest.Fecha_vencimiento;
        inventarioLotesExistente.Cantidad_lote = inventarioLotesRequest.Cantidad_lote;
        inventarioLotesExistente.Costo_unitario = inventarioLotesRequest.Costo_unitario;
        await _repositoryInventarioLotes.ActualizarInventarioLotesAsync(inventarioLotesExistente);
        return new InventarioLotesResponse
        {
            Id_lote = inventarioLotesExistente.Id_lote,
            Id_producto = inventarioLotesExistente.Id_producto,
            Fecha_ingreso = inventarioLotesExistente.Fecha_ingreso,
            Fecha_vencimiento = inventarioLotesExistente.Fecha_vencimiento,
            Cantidad_lote = inventarioLotesExistente.Cantidad_lote,
            Costo_unitario = inventarioLotesExistente.Costo_unitario
        };
    }
    public bool EliminarInventarioLotes(int id)
    {
        InventarioLotes? inventarioLotesExistente = _repositoryInventarioLotes.BuscarInventarioLotesPorId(id);
        if ( inventarioLotesExistente == null){throw new RecursoNoEncontradoException($"No se encontro el inventario lotes con el ID: {id}");};
        return _repositoryInventarioLotes.EliminarInventarioLotesPorId(id);
    }
}