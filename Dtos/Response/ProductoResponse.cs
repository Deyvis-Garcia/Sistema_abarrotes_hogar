namespace AbarrotesHogar.Dtos.Response;
public class ProductoResponse
{
    public int Id_producto{get;set;}
    public string? Nombre{get;set;}
    public string? Descripcion{get;set;}
    public decimal precio_venta{get;set;}
    public int stock_actual{get;set;}
    public int stock_minimo{get;set;}
    public bool Estado {get;set;}
}