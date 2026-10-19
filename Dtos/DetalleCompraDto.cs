namespace AbarrotesHogar.Dtos;
public class DetalleCompraDto
{
    public int Id_detalle_compra{get; set;}
    public int Id_compra{get;set;}
    public int Id_producto{get;set;}
    public int Cantidad {get;set;}
    public decimal Precio_unitario{get;set;}
    public decimal Subtotal {get;set;} 
}