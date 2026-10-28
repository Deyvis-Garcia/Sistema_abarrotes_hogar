namespace AbarrotesHogar.Dtos.Response;
public class DetalleVentaResponse
{
    public int Id_detalle_venta{ get; set; }
    public int Id_venta{get;set;}
    public int Id_producto{get;set;}
    public int Cantidad{get;set;}
    public decimal Precio_unitario{get;set;}
    public decimal Subtotal{get;set;}
}