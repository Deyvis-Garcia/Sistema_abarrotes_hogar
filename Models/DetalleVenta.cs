namespace AbarrotesHogar.Models;
public class DetalleVenta
{
    public int Id_detalle_venta{get; private set;}
    public int Id_venta{get;set;}
    public int Id_producto{get;set;}
    public int Cantidad{get;set;}
    public decimal Precio_unitario{get;set;}
    public decimal Subtotal{get;set;}
}