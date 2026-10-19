using Microsoft.Identity.Client;

namespace AbarrotesHogar.Models;
public class InventarioLotes
{
    public int Id_lote{get;}
    public int Id_producto{get;set;}
    public DateTime Fecha_ingreso{get;set;}
    public DateTime Fecha_vencimiento{get;set;}
    public decimal Cantidad_lote{get;set;}
    public decimal Costo_unitario{get;set;}
    public bool Estado{get;set;}
}