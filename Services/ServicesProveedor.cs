using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Repository.Interfaces;
using AbarrotesHogar.Services.Interfaces;
using AbarrotesHogar.Models;
using AbarrotesHogar.Excepciones;
using AbarrotesHogar.Repository;

namespace AbarrotesHogar.Services;
public class ServicesProveedor : IServicesProveedor
{
    public readonly IRepositoryProveedores _repositoryProveedores;
    public ServicesProveedor(IRepositoryProveedores repositoryProveedores)
    {
        _repositoryProveedores = repositoryProveedores;
    }
    public ProveedorResponse CrearProveedor(ProveedorRequest proveedorRequest)
    {
        Proveedores nuevoProveedor = new Proveedores
        {
            Nombre = proveedorRequest.Nombre,
            Ruc = proveedorRequest.Ruc,
            Telefono = proveedorRequest.Telefono,
            Direccion = proveedorRequest.Direccion,
            Correo = proveedorRequest.Correo,
            Estado = true
        };
        _repositoryProveedores.CrearProveedor(nuevoProveedor);
        ProveedorResponse proveedorResponse = new ProveedorResponse
        {
            Id_proveedor = nuevoProveedor.Id_proveedor,
            Nombre = nuevoProveedor.Nombre,
            Ruc = nuevoProveedor.Ruc,
            Telefono = nuevoProveedor.Telefono,
            Direccion = nuevoProveedor.Direccion,
            Correo = nuevoProveedor.Correo,
            Estado = nuevoProveedor.Estado
        };
        return proveedorResponse;
    }
    public ProveedorResponse? BuscarProveedorPorId(int id)
    {
        Proveedores? proveedorExistente = _repositoryProveedores.BuscarProveedorPorId(id);
        if(proveedorExistente == null){throw new RecursoNoEncontradoException($"No se encontro el proveedor con el ID: {id}");};
        return new ProveedorResponse
        {
            Id_proveedor = proveedorExistente.Id_proveedor,
            Nombre = proveedorExistente.Nombre,
            Ruc = proveedorExistente.Ruc,
            Telefono = proveedorExistente.Telefono,
            Direccion = proveedorExistente.Direccion,
            Correo = proveedorExistente.Correo,
            Estado = proveedorExistente.Estado
        };
    }
    public List<ProveedorResponse> ListarTodosProveedor()
    {
        List<Proveedores> proveedores = _repositoryProveedores.ListarTodosProvedores();
        return proveedores.Select(p => new ProveedorResponse
        {
            Id_proveedor = p.Id_proveedor,
            Nombre = p.Nombre,
            Ruc = p.Ruc,
            Telefono = p.Telefono,
            Direccion = p.Direccion,
            Correo = p.Correo,
            Estado = p.Estado
        }).ToList();
    }
    public List<ProveedorResponse> ListarTodosProveedorEliminados()
    {
        List<Proveedores> proveedoresEliminados = _repositoryProveedores.ListarTodosProvedoresEliminados();
        return proveedoresEliminados.Select(p => new ProveedorResponse
        {
            Id_proveedor = p.Id_proveedor,
            Nombre = p.Nombre,
            Ruc = p.Ruc,
            Telefono = p.Telefono,
            Direccion = p.Direccion,
            Correo = p.Correo,
            Estado = p.Estado
        }).ToList();
    }
    public async Task<ProveedorResponse> ActualizarProveedor(int id,ProveedorRequest proveedorRequest)
    {
        Proveedores? proveedorExistente = _repositoryProveedores.BuscarProveedorPorId(id);
        if(proveedorExistente == null){throw new RecursoNoEncontradoException($"No se encontro el proveedor con el ID: {id}");};
        proveedorExistente.Nombre = proveedorRequest.Nombre;
        proveedorExistente.Ruc = proveedorRequest.Ruc;
        proveedorExistente.Telefono = proveedorRequest.Telefono;
        proveedorExistente.Direccion = proveedorRequest.Direccion;
        proveedorExistente.Correo = proveedorRequest.Correo;
        proveedorExistente.Estado = proveedorRequest.Estado;
        await _repositoryProveedores.ActualizarProveedoresAsync(proveedorExistente);
        return new ProveedorResponse
        {
            Id_proveedor = proveedorExistente.Id_proveedor,
            Nombre = proveedorExistente.Nombre,
            Ruc = proveedorExistente.Ruc,
            Telefono = proveedorExistente.Telefono,
            Direccion = proveedorExistente.Direccion,
            Correo = proveedorExistente.Correo,
            Estado = proveedorExistente.Estado
        };
    }
    public bool EliminarProvedorPorId(int id)
    {
        Proveedores? proveedorExistente = _repositoryProveedores.BuscarProveedorPorId(id);
        if(proveedorExistente == null){throw new RecursoNoEncontradoException($"No se encontro el proveedor con el ID: {id}");};
        return _repositoryProveedores.EliminarProveedorePorId(id);
    }
}