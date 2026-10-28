namespace AbarrotesHogar.Dtos.Response;
public class VentasResponse
{
    public int Id_venta{get;set;}
    public int Id_usuario{get;set;}
    public DateTime Fecha_venta{get;set;}
    public decimal Total{get;set;}
    public string? Observaciones{get;set;}
}