namespace AbarrotesHogar.Models;
public class Productos
{
    public int Id_producto{get; private set;}
    public string? Nombre{get;set;}
    public string? Descripcion{get;set;}
    public decimal precio_venta{get;set;}
    public int stock_actual{get;set;}
    public int stock_minimo{get;set;}
    public bool Estado {get;set;} = true;
}
