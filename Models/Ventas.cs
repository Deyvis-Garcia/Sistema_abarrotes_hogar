namespace AbarrotesHogar.Models;
public class Ventas
{
    public int Id_venta{get;private set;}
    public int Id_usuario{get;set;}
    public DateTime Fecha_venta{get;set;}
    public decimal Total{get;set;}
    public string? Observaciones{get;set;}
}