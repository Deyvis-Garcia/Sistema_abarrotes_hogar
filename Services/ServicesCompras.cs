using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Repository.Interfaces;
using AbarrotesHogar.Services.Interfaces;
using AbarrotesHogar.Models;
using AbarrotesHogar.Excepciones;
using AbarrotesHogar.Repository;

namespace AbarrotesHogar.Services;
public class ServicesCompras : IServicesCompras
{
    public readonly IRepositoryCompras _repositoryCompras;
    public ServicesCompras(IRepositoryCompras repositoryCompras)
    {
        _repositoryCompras = repositoryCompras;
    }
    public ComprasResponse CrearCompra(ComprasRequest comprasRequest)
    {
        Compras nuevaCompra = new Compras
        {
            Id_proveedor = comprasRequest.Id_proveedor,
            Id_usuario = comprasRequest.Id_usuario,
            Fecha_compra = DateTime.Now,
            Total = comprasRequest.Total,
            Observaciones = comprasRequest.Observaciones
        };
        _repositoryCompras.CrearCompra(nuevaCompra);
        ComprasResponse response = new ComprasResponse
        {
            Id_compra = nuevaCompra.Id_compra,
            Id_proveedor = nuevaCompra.Id_proveedor,
            Id_usuario = nuevaCompra.Id_usuario,
            Fecha_compra = nuevaCompra.Fecha_compra,
            Total = nuevaCompra.Total,
            Observaciones = nuevaCompra.Observaciones
        };
        return response;
    }
    public ComprasResponse?  BuscarCompraPorId(int id)
    {
        Compras? compra = _repositoryCompras.BuscarCompraPorId(id);
        if(compra == null){throw new RecursoNoEncontradoException($"No se encontro la compra con el ID: {id}");};
        return new ComprasResponse
        {
            Id_compra = compra.Id_compra,
            Id_proveedor = compra.Id_proveedor,
            Id_usuario = compra.Id_usuario,
            Fecha_compra = compra.Fecha_compra,
            Total = compra.Total,
            Observaciones = compra.Observaciones
        };
    }
    public List<ComprasResponse> ListarTodosCompras()
    {
        List<Compras> compras = _repositoryCompras.ListarTodos();
        return compras.Select( c => new ComprasResponse
        {
            Id_compra = c.Id_compra,
            Id_proveedor = c.Id_proveedor,
            Id_usuario = c.Id_usuario,
            Fecha_compra = c.Fecha_compra,
            Total = c.Total,
            Observaciones = c.Observaciones
        }).ToList();
    }
    public async Task<ComprasResponse> ActualizarComprasAsync(int id, ComprasRequest request)
    {
        Compras? compraExistente = _repositoryCompras.BuscarCompraPorId(id);
        
        if (compraExistente == null)
        {
            throw new RecursoNoEncontradoException($"No se encontro la compra con el ID: {id}");
        }

        compraExistente.Id_proveedor = request.Id_proveedor;
        compraExistente.Id_usuario = request.Id_usuario;
        compraExistente.Total = request.Total;
        compraExistente.Observaciones = request.Observaciones;
        
        await _repositoryCompras.ActualizarComprasAsync(compraExistente);

        return new ComprasResponse
        {
            Id_compra = compraExistente.Id_compra,
            Id_proveedor = compraExistente.Id_proveedor,
            Id_usuario = compraExistente.Id_usuario,
            Fecha_compra = compraExistente.Fecha_compra,
            Total = compraExistente.Total,
            Observaciones = compraExistente.Observaciones
        };
    }
    public bool EliminarCompraPorId(int id)
    {
        Compras? compraExistente = _repositoryCompras.BuscarCompraPorId(id);
        if (compraExistente == null)
        {
            throw new RecursoNoEncontradoException($"No se encontro la compra con el ID: {id}");
        }
        return _repositoryCompras.EliminarCompraPorId(id);
    }
}
