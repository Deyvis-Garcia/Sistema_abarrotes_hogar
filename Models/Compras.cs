namespace AbarrotesHogar.Models;
public class Compras
{
    public int Id_compra { get; private set;}
    public int Id_proveedor { get; set; }
    public int Id_usuario { get; set; }
    public DateTime Fecha_compra { get; set; }
    public decimal Total { get; set; }
    public string? Observaciones { get; set; }
}