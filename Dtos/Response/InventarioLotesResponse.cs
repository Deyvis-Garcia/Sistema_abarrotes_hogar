namespace AbarrotesHogar.Dtos.Response;
public class InventarioLotesResponse
{
    public int Id_lote{get; set;}
    public int Id_producto{get;set;}
    public DateTime Fecha_ingreso{get;set;}
    public DateTime Fecha_vencimiento{get;set;}
    public decimal Cantidad_lote{get;set;}
    public decimal Costo_unitario{get;set;}
}