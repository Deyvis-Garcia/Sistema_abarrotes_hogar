namespace AbarrotesHogar.Models;
public class Proveedores
{
    public int Id_proveedor{get;private set;}
    public string? Nombre{get;set;}
    public string? Ruc{get;set;}
    public string? Telefono{get;set;}
    public string? Direccion{get;set;}
    public string? Correo{get;set;}
    public bool Estado {get; set;}
}